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
            DateTime time1 = GetRateLimitRuleDelay(lastTenSeconds, rateLimitPerTenSeconds, 10.1, now);

            RequestCount lastTenMinutes = requestsInLastTenMinutes.GetOrAdd(platformId, requestCountFactory);
            DateTime time2 = GetRateLimitRuleDelay(lastTenMinutes, rateLimitPerTenMinutes, 600.1, now);
            return (time1 >= time2) ? time1 : time2;
        }

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
            return DateTime.MinValue;
        }

        protected class RequestCount
        {
            public int Count;
            public DateTime ResetTime;
        }
    }
}
