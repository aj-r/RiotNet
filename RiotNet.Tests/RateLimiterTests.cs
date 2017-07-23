using NUnit.Framework;
using RiotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiotNet.Tests
{
    [TestFixture]
    public class RateLimiterTests
    {
        [Test]
        public void RateLimiter_ShouldNotThrottle()
        {
            IRateLimiter rateLimiter = new RateLimiter();
            rateLimiter.TrySetRules(new[]
            {
                new RateLimitRule { Limit = 2, Duration = 10 },
                new RateLimitRule { Limit = 1000, Duration = 600 },
            }, null);
            rateLimiter.AddRequestOrGetDelay(PlatformId.NA1);
            DateTime targetDate = rateLimiter.AddRequestOrGetDelay(PlatformId.NA1);

            Assert.That(targetDate.Kind, Is.EqualTo(DateTimeKind.Utc));
            Assert.That(targetDate, Is.AtMost(DateTime.UtcNow));
        }

        [Test]
        public void RateLimiter_ShouldNotThrottle_DifferentPlatforms()
        {
            IRateLimiter rateLimiter = new RateLimiter();
            rateLimiter.TrySetRules(new[]
            {
                new RateLimitRule { Limit = 2, Duration = 10 },
                new RateLimitRule { Limit = 1000, Duration = 600 },
            }, null);

            foreach (string platformId in PlatformId.All)
            {
                rateLimiter.AddRequestOrGetDelay(platformId);
                DateTime targetDate = rateLimiter.AddRequestOrGetDelay(platformId);

                Assert.That(targetDate.Kind, Is.EqualTo(DateTimeKind.Utc));
                Assert.That(targetDate, Is.AtMost(DateTime.UtcNow));
            }
        }

        [Test]
        public void RateLimiter_ShouldThrottle_ForFirstLimit()
        {
            IRateLimiter rateLimiter = new RateLimiter();
            rateLimiter.TrySetRules(new[]
            {
                new RateLimitRule { Limit = 2, Duration = 10 },
                new RateLimitRule { Limit = 1000, Duration = 600 },
            }, null);
            rateLimiter.AddRequestOrGetDelay(PlatformId.NA1);
            rateLimiter.AddRequestOrGetDelay(PlatformId.NA1);
            DateTime targetDate = rateLimiter.AddRequestOrGetDelay(PlatformId.NA1);

            Assert.That(targetDate.Kind, Is.EqualTo(DateTimeKind.Utc));
            Assert.That(targetDate, Is.GreaterThan(DateTime.UtcNow));
        }

        [Test]
        public void RateLimiter_ShouldThrottle_ForSecondLimit()
        {
            IRateLimiter rateLimiter = new RateLimiter();
            rateLimiter.TrySetRules(new[]
            {
                new RateLimitRule { Limit = 2, Duration = 10 },
                new RateLimitRule { Limit = 5, Duration = 600 },
            }, null);
            rateLimiter.AddRequestOrGetDelay(PlatformId.NA1);
            rateLimiter.AddRequestOrGetDelay(PlatformId.NA1);
            rateLimiter.AddRequestOrGetDelay(PlatformId.NA1);
            rateLimiter.AddRequestOrGetDelay(PlatformId.NA1);
            rateLimiter.AddRequestOrGetDelay(PlatformId.NA1);
            DateTime targetDate = rateLimiter.AddRequestOrGetDelay(PlatformId.NA1);

            Assert.That(targetDate.Kind, Is.EqualTo(DateTimeKind.Utc));
            Assert.That(targetDate, Is.GreaterThan(DateTime.UtcNow));
        }

        [Test]
        public void RateLimiter_ShouldThrottle_Multiple()
        {
            IRateLimiter rateLimiter = new RateLimiter();
            rateLimiter.TrySetRules(new[]
            {
                new RateLimitRule { Limit = 2, Duration = 10 },
                new RateLimitRule { Limit = 10, Duration = 600 },
            }, null);
            rateLimiter.AddRequestOrGetDelay(PlatformId.NA1);
            rateLimiter.AddRequestOrGetDelay(PlatformId.NA1);

            for (int i = 0; i < 5; ++i)
            {
                DateTime targetDate = rateLimiter.AddRequestOrGetDelay(PlatformId.NA1);

                Assert.That(targetDate.Kind, Is.EqualTo(DateTimeKind.Utc));
                Assert.That(targetDate, Is.GreaterThan(DateTime.UtcNow));
            }
        }

        [Test]
        public async Task RateLimiter_ShouldThrottle_ConcurrentRequests()
        {
            IRateLimiter rateLimiter = new RateLimiter();
            rateLimiter.TrySetRules(new[]
            {
                new RateLimitRule { Limit = 5, Duration = 10 },
                new RateLimitRule { Limit = 100, Duration = 600 },
            }, null);

            var tasks = new List<Task<DateTime>>();
            for (var i = 0; i < 20; ++i)
                tasks.Add(Task.Run(() => rateLimiter.AddRequestOrGetDelay(PlatformId.NA1)));

            DateTime[] dates = await Task.WhenAll(tasks);
            var now = DateTime.UtcNow;
            var unthrottled = dates.Where(d => d <= now).ToList();
            Assert.That(unthrottled.Count, Is.EqualTo(5), "Wrong number of requests were sent");
        }

        [Test]
        public void RateLimiter_HasRules_ShouldBeTrueAfterSet()
        {
            IRateLimiter rateLimiter = new RateLimiter();

            Assert.That(rateLimiter.HasRules, Is.EqualTo(false), "Rules should not been set yet!");

            rateLimiter.TrySetRules(new[]
            {
                new RateLimitRule { Limit = 5, Duration = 10 },
                new RateLimitRule { Limit = 100, Duration = 600 },
            }, null);
            
            Assert.That(rateLimiter.HasRules, Is.EqualTo(true), "Rules should have been set!");
        }
    }
}
