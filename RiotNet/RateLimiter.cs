using System;
using System.Collections.Concurrent;

namespace RiotNet
{
    /// <summary>
    /// Handles proactive rate limiting. You should only ever create one instance of this interface.
    /// </summary>
    public interface IRateLimiter
    {
        /// <summary>
        /// Incremented the request count, or if the rate limit is reached, gets the time (in UTC) until which the client should wait before sending a request.
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
        private readonly int rateLimitPerTenSeconds;
        private readonly int rateLimitPerTenMinutes;

        private readonly ConcurrentDictionary<string, RequestCount> requestsInLastTenSeconds = new ConcurrentDictionary<string, RequestCount>();
        private readonly ConcurrentDictionary<string, RequestCount> requestsInLastTenMinutes = new ConcurrentDictionary<string, RequestCount>();
        private readonly Func<string, RequestCount> requestCountFactory = (platformId) => new RequestCount();

        /// <summary>
        /// Informs the RiotClient of your API key's rate limit, and enables proactive rate limiting.
        /// </summary>
        /// <param name="rateLimitPerTenSeconds">Your API key's rate limit per 10 seconds.</param>
        /// <param name="rateLimitPerTenMinutes">Your API key's rate limit per 10 minutes.</param>
        public RateLimiter(int rateLimitPerTenSeconds, int rateLimitPerTenMinutes)
        {
            this.rateLimitPerTenSeconds = rateLimitPerTenSeconds;
            this.rateLimitPerTenMinutes = rateLimitPerTenMinutes;
        }

        /// <summary>
        /// Incremented the request count, or if the rate limit is reached, gets the time (in UTC) until which the client should wait before sending a request.
        /// </summary>
        /// <param name="platformId">The platform ID of the default server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values.</param>
        /// <returns>The wait time, or DateTime.MinValue if no delay is required.</returns>
        public virtual DateTime AddRequestOrGetDelay(string platformId)
        {
            var now = DateTime.UtcNow;

            RequestCount lastTenSeconds = requestsInLastTenSeconds.GetOrAdd(platformId, requestCountFactory);
            DateTime time1 = GetRateLimitRuleDelay(lastTenSeconds, rateLimitPerTenSeconds, 11, now);

            RequestCount lastTenMinutes = requestsInLastTenMinutes.GetOrAdd(platformId, requestCountFactory);
            DateTime time2 = GetRateLimitRuleDelay(lastTenMinutes, rateLimitPerTenMinutes, 601, now);
            return (time1 >= time2) ? time1 : time2;
        }

        /// <summary>
        /// Gets the time to delay until for a single rate limit rule.
        /// </summary>
        /// <param name="requestCount">The RequestCount object for the current rule.</param>
        /// <param name="limit">The maximum number of requests allowed by the rule.</param>
        /// <param name="periodInSeconds">The total amount of time defined by the rule before the request count resets.</param>
        /// <param name="now">The current time in UTC.</param>
        /// <returns>The time to delay until.</returns>
        protected DateTime GetRateLimitRuleDelay(RequestCount requestCount, int limit, double periodInSeconds, DateTime now)
        {
            lock (requestCount)
            {
                if (requestCount.ResetTime < now || requestCount.Count == 0)
                {
                    requestCount.ResetTime = now + TimeSpan.FromSeconds(periodInSeconds);
                    requestCount.Count = 1;
                }
                else if (requestCount.Count < limit)
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
    }
}
