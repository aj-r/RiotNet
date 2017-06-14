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
        /// Increments the request count, or if the rate limit is reached, gets the time (in UTC) until which the client should wait before sending a request.
        /// </summary>
        /// <param name="platformId">The platform ID of the default server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values.</param>
        /// <returns>The wait time, or DateTime.MinValue if no delay is required.</returns>
        /// <remarks>
        /// Implementations of this function must be thread-safe.
        /// </remarks>
        DateTime AddRequestOrGetDelay(string platformId);

        /// <summary>
        /// Updates the value of a request count based on data from the Riot API.
        /// </summary>
        /// <param name="platformId">The platform ID of the default server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values.</param>
        /// <param name="lastTenSeconds">The actual number of requests send in the last 10 seconds.</param>
        /// <param name="lastTenMinutes">The actual number of requests send in the last 10 minutes.</param>
        void UpdateRequestCount(string platformId, int lastTenSeconds, int lastTenMinutes);
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
        private readonly Func<string, RequestCount> tenSecondRequestCountFactory = (platformId) => new RequestCount(TimeSpan.FromSeconds(11.0));
        private readonly Func<string, RequestCount> tenMinuteRequestCountFactory = (platformId) => new RequestCount(TimeSpan.FromSeconds(601.0));

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
        /// Increments the request count, or if the rate limit is reached, gets the time (in UTC) until which the client should wait before sending a request.
        /// </summary>
        /// <param name="platformId">The platform ID of the default server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values.</param>
        /// <returns>The wait time, or DateTime.MinValue if no delay is required.</returns>
        public virtual DateTime AddRequestOrGetDelay(string platformId)
        {
            var now = DateTime.UtcNow;

            RequestCount lastTenSeconds = requestsInLastTenSeconds.GetOrAdd(platformId, tenSecondRequestCountFactory);
            DateTime time1 = GetRateLimitRuleDelay(lastTenSeconds, rateLimitPerTenSeconds, now);

            RequestCount lastTenMinutes = requestsInLastTenMinutes.GetOrAdd(platformId, tenMinuteRequestCountFactory);
            DateTime time2 = GetRateLimitRuleDelay(lastTenMinutes, rateLimitPerTenMinutes, now);
            return (time1 >= time2) ? time1 : time2;
        }

        /// <summary>
        /// Updates the value of a request count based on data from the Riot API.
        /// </summary>
        /// <param name="platformId">The platform ID of the default server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values.</param>
        /// <param name="lastTenSeconds">The actual number of requests send in the last 10 seconds.</param>
        /// <param name="lastTenMinutes">The actual number of requests send in the last 10 minutes.</param>
        public virtual void UpdateRequestCount(string platformId, int lastTenSeconds, int lastTenMinutes)
        {
            RequestCount lastTenSecondsEntry = requestsInLastTenSeconds.GetOrAdd(platformId, tenSecondRequestCountFactory);
            SetRequestCount(lastTenSecondsEntry, lastTenSeconds);

            RequestCount lastTenMinutesEntry = requestsInLastTenMinutes.GetOrAdd(platformId, tenMinuteRequestCountFactory);
            SetRequestCount(lastTenMinutesEntry, lastTenMinutes);
        }

        /// <summary>
        /// Gets the time to delay until for a single rate limit rule.
        /// </summary>
        /// <param name="requestCount">The RequestCount object for the current rule.</param>
        /// <param name="limit">The maximum number of requests allowed by the rule.</param>
        /// <param name="now">The current time in UTC.</param>
        /// <returns>The time to delay until.</returns>
        protected DateTime GetRateLimitRuleDelay(RequestCount requestCount, int limit, DateTime now)
        {
            lock (requestCount)
            {
                if (requestCount.ResetTime < now || requestCount.Count == 0)
                {
                    requestCount.ResetTime = now + requestCount.Period;
                    requestCount.Count = 1;
                    requestCount.LastServerCount = 1;
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
        /// Updates the value of a request count.
        /// </summary>
        /// <param name="requestCount">The RequestCount object for the current rule.</param>
        /// <param name="newValue">The actual number of requests sent so far for the rule.</param>
        protected void SetRequestCount(RequestCount requestCount, int newValue)
        {
            lock (requestCount)
            {
                if (newValue < requestCount.Count)
                {
                    if (newValue <= requestCount.LastServerCount)
                    {
                        // Count was reset
                        requestCount.ResetTime = DateTime.UtcNow + requestCount.Period;
                    }
                    else
                    {
                        // Count is probably lagging behind our locally tracked count. Ignore.
                        requestCount.LastServerCount = newValue;
                        return;
                    }
                }
                if (requestCount.Count != newValue)
                { }
                else
                { }
                requestCount.Count = newValue;
                requestCount.LastServerCount = newValue;
            }
        }

        /// <summary>
        /// Represents a request count for a rate limiting rule.
        /// </summary>
        protected class RequestCount
        {
            /// <summary>
            /// Creates a new <see cref="RequestCount"/> instance.
            /// </summary>
            /// <param name="period">The duration of the period before the count is reset.</param>
            public RequestCount(TimeSpan period)
            {
                Period = period;
            }

            /// <summary>
            /// The number of requests sent since the last reset.
            /// </summary>
            public int Count;

            /// <summary>
            /// The number of requests sent since the last reset (according to the server).
            /// </summary>
            public int LastServerCount;

            /// <summary>
            /// The time in UTC when the request count should reset.
            /// </summary>
            public DateTime ResetTime;

            /// <summary>
            /// The duration of the period before the count is reset.
            /// </summary>
            public readonly TimeSpan Period;
        }
    }
}
