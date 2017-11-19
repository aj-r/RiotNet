using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace RiotNet
{
    /// <summary>
    /// Handles proactive rate limiting. You should only ever create one instance of this interface.
    /// </summary>
    public interface IRateLimiter
    {
        /// <summary>
        /// Adds application-level rate limiting rules if they have not been added already.
        /// </summary>
        /// <param name="rules">The list of rules.</param>
        /// <param name="platformId">The platform ID of the response that contained the rate limit definitions. The request count will automatically be incremented for this platform.</param>
        /// <param name="currentCounts">The current request counts for each rule. If unspecified, 1 request for each rule will be assumed.</param>
        void TrySetRules(IEnumerable<RateLimitRule> rules, string platformId, IEnumerable<RateLimitRule> currentCounts = null);

        /// <summary>
        /// Adds method-level rate limiting rules if they have not been added already.
        /// </summary>
        /// <param name="rules">The list of rules.</param>
        /// <param name="methodName">The name of the method that is executing.</param>
        /// <param name="platformId">The platform ID of the response that contained the rate limit definitions. The request count will automatically be incremented for this platform.</param>
        /// <param name="currentCounts">The current request counts for each rule. If unspecified, 1 request for each rule will be assumed.</param>
        void TrySetRules(IEnumerable<RateLimitRule> rules, string methodName, string platformId, IEnumerable<RateLimitRule> currentCounts = null);

        /// <summary>
        /// Gets whether the rate limiter has any application-level rules set.
        /// </summary>
        bool HasRules { get; }

        /// <summary>
        /// Increments the request count, or if the rate limit is reached, gets the time (in UTC) until which the client should wait before sending a request.
        /// </summary>
        /// <param name="methodName">The name of the method that is executing.</param>
        /// <param name="platformId">The platform ID of the default server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values.</param>
        /// <returns>The wait time, or DateTime.MinValue if no delay is required.</returns>
        /// <remarks>
        /// Implementations of this function must be thread-safe.
        /// </remarks>
        DateTime AddRequestOrGetDelay(string methodName, string platformId);
    }

    /// <summary>
    /// Represents a single rule of a rate limit.
    /// </summary>
    public class RateLimitRule
    {
        /// <summary>
        /// The duration of the rate limit, in seconds.
        /// </summary>
        public double Duration;

        /// <summary>
        /// The maximum number of requests that can be sent within the period.
        /// </summary>
        public int Limit;
    }

    /// <summary>
    /// Handles proactive rate limiting. You should only ever create one instance of this class.
    /// </summary>
    public class RateLimiter : IRateLimiter
    {
        private readonly ConcurrentDictionary<double, RateLimitTracker> appTrackers = new ConcurrentDictionary<double, RateLimitTracker>();
        private readonly ConcurrentDictionary<string, ConcurrentDictionary<double, RateLimitTracker>> methodTrackers = new ConcurrentDictionary<string, ConcurrentDictionary<double, RateLimitTracker>>();
        private static readonly Func<string, ConcurrentDictionary<double, RateLimitTracker>> addTrackerFactory = key => new ConcurrentDictionary<double, RateLimitTracker>();
        private static readonly Func<double, RateLimitTracker, RateLimitTracker> identityUpdateFactory = (key, oldValue) => oldValue;

        /// <summary>
        /// Creates a new <see cref="RateLimiter"/> instance.
        /// </summary>
        public RateLimiter()
        { }

        /// <summary>
        /// Creates a new <see cref="RateLimiter"/> instance.
        /// </summary>
        /// <param name="rateLimitPerTenSeconds">Your API key's rate limit per 10 seconds.</param>
        /// <param name="rateLimitPerTenMinutes">Your API key's rate limit per 10 minutes.</param>
        [Obsolete("Use the default constructor, and let the RiotClient automatically determine the rate limit")]
        public RateLimiter(int rateLimitPerTenSeconds, int rateLimitPerTenMinutes)
        {
            var rules = new List<RateLimitRule>();
            if (rateLimitPerTenSeconds > 0)
                rules.Add(new RateLimitRule { Duration = 10, Limit = rateLimitPerTenSeconds });
            if (rateLimitPerTenMinutes > 0)
                rules.Add(new RateLimitRule { Duration = 600, Limit = rateLimitPerTenMinutes });
            TrySetRules(rules);
        }

        /// <summary>
        /// Adds application-level rate limiting rules if they have not been added already.
        /// </summary>
        /// <param name="rules">The list of rules.</param>
        /// <param name="platformId">The platform ID of the response that contained the rate limit definitions. The request count will automatically be incremented for this platform.</param>
        /// <param name="currentCounts">The current request counts for each rule. If unspecified, 1 request for each rule will be assumed.</param>
        public virtual void TrySetRules(IEnumerable<RateLimitRule> rules, string platformId = null, IEnumerable<RateLimitRule> currentCounts = null)
        {
            var now = DateTime.UtcNow;
            foreach (var rule in rules)
            {
                appTrackers.AddOrUpdate(rule.Duration, (duration) =>
                {
                    var newTracker = new RateLimitTracker { Rule = rule };
                    if (platformId != null)
                    {
                        var currentCount = currentCounts?.FirstOrDefault(c => c.Duration == duration)?.Limit ?? 1;
                        RequestCount requestCount = newTracker.RequestCounts.GetOrAdd(platformId, (pid) => new RequestCount());
                        // Wait a little longer than the reset time in case there's a bit of lag when talking to the server
                        requestCount.ResetTime = now + TimeSpan.FromSeconds(duration + 0.75);
                        requestCount.Count = currentCount;
                    }
                    return newTracker;
                }, identityUpdateFactory);
            }
        }

        /// <summary>
        /// Adds method-level rate limiting rules if they have not been added already.
        /// </summary>
        /// <param name="rules">The list of rules.</param>
        /// <param name="methodName">The name of the method that is executing.</param>
        /// <param name="platformId">The platform ID of the response that contained the rate limit definitions. The request count will automatically be incremented for this platform.</param>
        /// <param name="currentCounts">The current request counts for each rule. If unspecified, 1 request for each rule will be assumed.</param>
        public virtual void TrySetRules(IEnumerable<RateLimitRule> rules, string methodName, string platformId, IEnumerable<RateLimitRule> currentCounts = null)
        {
            var now = DateTime.UtcNow;
            foreach (var rule in rules)
            {
                var currentMethodTrackers = methodTrackers.GetOrAdd(methodName, addTrackerFactory);
                currentMethodTrackers.AddOrUpdate(rule.Duration, (duration) =>
                {
                    var newTracker = new RateLimitTracker { Rule = rule };
                    if (platformId != null)
                    {
                        var currentCount = currentCounts?.FirstOrDefault(c => c.Duration == duration)?.Limit ?? 1;
                        RequestCount requestCount = newTracker.RequestCounts.GetOrAdd(platformId, (pid) => new RequestCount());
                        // Wait a little longer than the reset time in case there's a bit of lag when talking to the server
                        requestCount.ResetTime = now + TimeSpan.FromSeconds(duration + 0.75);
                        requestCount.Count = currentCount;
                    }
                    return newTracker;
                }, identityUpdateFactory);
            }
        }

        /// <summary>
        /// Gets whether the rate limiter has any rules set.
        /// </summary>
        /// <returns>True if any rules have been added, otherwise false.</returns>
        public virtual bool HasRules => appTrackers.Count > 0;

        /// <summary>
        /// Increments the request count, or if the rate limit is reached, gets the time (in UTC) until which the client should wait before sending a request.
        /// </summary>
        /// <param name="methodName">The name of the method that is executing.</param>
        /// <param name="platformId">The platform ID of the default server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values.</param>
        /// <returns>The wait time, or DateTime.MinValue if no delay is required.</returns>
        public virtual DateTime AddRequestOrGetDelay(string methodName, string platformId)
        {
            var now = DateTime.UtcNow;
            DateTime maxTime = now;

            // Static data calls don't count toward application limits
            if (!methodName.Contains("static-data/"))
            {
                foreach (var rateLimitTracker in appTrackers.Values)
                {
                    DateTime t = rateLimitTracker.GetDelayTime(platformId, now);
                    if (t > maxTime)
                        maxTime = t;
                }
            }
            var currentMethodTrackers = methodTrackers.GetOrAdd(methodName, addTrackerFactory);
            foreach (var rateLimitTracker in currentMethodTrackers.Values)
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
            /// The rule being tracked.
            /// </summary>
            public RateLimitRule Rule;

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
                        // Wait a little longer than the reset time in case there's a bit of lag when talking to the server
                        requestCount.ResetTime = now + TimeSpan.FromSeconds(Rule.Duration + 0.75);
                        requestCount.Count = 1;
                    }
                    else if (requestCount.Count < Rule.Limit)
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
