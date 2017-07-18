using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace RiotNet
{
    /// <summary>
    /// Handles proactive rate limiting. You should only ever create one instance of this interface.
    /// </summary>
    public interface IRateLimiter
    {
        /// <summary>
        /// Increments the request count, or if the rate limit is reached, gets the time (in UTC) until which the client should wait before sending a request.
        /// </summary>
        /// <param name="platformId">The platform ID of the default server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values.</param>
        /// <returns>The wait time, or DateTime.MinValue if no delay is required.</returns>
        /// <remarks>
        /// Implementations of this function must be thread-safe.
        /// </remarks>
        DateTime AddRequestOrGetDelay(string platformId);
    }

    /// <summary>
    /// Handles proactive rate limiting. You should only ever create one instance of this class.
    /// </summary>
    public class RateLimiter : IRateLimiter
    {
        private readonly List<RateLimitTracker> rateLimits = new List<RateLimitTracker>();

        /// <summary>
        /// Informs the RiotClient of your API key's rate limit, and enables proactive rate limiting.
        /// </summary>
        /// <param name="rateLimitPerTenSeconds">Your API key's rate limit per 10 seconds.</param>
        /// <param name="rateLimitPerTenMinutes">Your API key's rate limit per 10 minutes.</param>
        public RateLimiter(int rateLimitPerTenSeconds, int rateLimitPerTenMinutes)
            : this(0, rateLimitPerTenSeconds, 0, rateLimitPerTenMinutes)
        { }

        /// <summary>
        /// Informs the RiotClient of your API key's rate limit, and enables proactive rate limiting.
        /// </summary>
        /// <param name="rateLimitPerSecond">Your API key's rate limit per 1 second.</param>
        /// <param name="rateLimitPerTenSeconds">Your API key's rate limit per 10 seconds.</param>
        /// <param name="rateLimitPerTwoMinutes">Your API key's rate limit per 2 minutes.</param>
        /// <param name="rateLimitPerTenMinutes">Your API key's rate limit per 10 minutes.</param>
        public RateLimiter(int rateLimitPerSecond, int rateLimitPerTenSeconds, int rateLimitPerTwoMinutes, int rateLimitPerTenMinutes)
        {
            if (rateLimitPerSecond > 0)
                rateLimits.Add(new RateLimitTracker { PeriodInSeconds = 1.5, Limit = rateLimitPerSecond });
            if (rateLimitPerTenSeconds > 0)
                rateLimits.Add(new RateLimitTracker { PeriodInSeconds = 11, Limit = rateLimitPerTenSeconds });
            if (rateLimitPerTwoMinutes > 0)
                rateLimits.Add(new RateLimitTracker { PeriodInSeconds = 121, Limit = rateLimitPerTwoMinutes });
            if (rateLimitPerTenMinutes > 0)
                rateLimits.Add(new RateLimitTracker { PeriodInSeconds = 601, Limit = rateLimitPerTenMinutes });
        }

        /// <summary>
        /// Increments the request count, or if the rate limit is reached, gets the time (in UTC) until which the client should wait before sending a request.
        /// </summary>
        /// <param name="platformId">The platform ID of the default server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values.</param>
        /// <returns>The wait time, or DateTime.MinValue if no delay is required.</returns>
        public virtual DateTime AddRequestOrGetDelay(string platformId)
        {
            var now = DateTime.UtcNow;
            DateTime maxTime = now;

            foreach (var rateLimitTracker in rateLimits)
            {
                DateTime t = rateLimitTracker.GetDelayTime(platformId, now);
                if (t > maxTime)
                    maxTime = t;
            }
            return maxTime;
        }

        /// <summary>
        /// Represents a request count for a rate limiting rule.
        /// </summary>
        protected class RequestCount
        {
            /// <summary>
            /// The number of requests sent since the last reset.
            /// </summary>
            public int Count;

            /// <summary>
            /// The time in UTC when the request count should reset.
            /// </summary>
            public DateTime ResetTime;
        }

        /// <summary>
        /// Represents a request count for a rate limiting rule.
        /// </summary>
        protected class RateLimitTracker
        {
            private static readonly Func<string, RequestCount> requestCountFactory = (platformId) => new RequestCount();

            /// <summary>
            /// The period of the rate limit, in seconds.
            /// </summary>
            public double PeriodInSeconds;

            /// <summary>
            /// The maximum number of requests that can be sent in the period.
            /// </summary>
            public int Limit;

            /// <summary>
            /// The list of recent request counts for each PlatformId.
            /// </summary>
            public ConcurrentDictionary<string, RequestCount> RequestCounts = new ConcurrentDictionary<string, RequestCount>();


            /// <summary>
            /// Gets the time to delay until for a single rate limit rule.
            /// </summary>
            /// <param name="platformId">The platform ID of the default server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values.</param>
            /// <param name="now">The current time in UTC.</param>
            /// <returns>The time to delay until.</returns>
            public DateTime GetDelayTime(string platformId, DateTime now)
            {
                RequestCount requestCount = RequestCounts.GetOrAdd(platformId, requestCountFactory);
                lock (requestCount)
                {
                    if (requestCount.ResetTime < now || requestCount.Count == 0)
                    {
                        requestCount.ResetTime = now + TimeSpan.FromSeconds(PeriodInSeconds);
                        requestCount.Count = 1;
                    }
                    else if (requestCount.Count < Limit)
                    {
                        ++requestCount.Count;
                    }
                    else
                    {
                        return requestCount.ResetTime;
                    }
                }
                return now;
            }
        }
    }
}
