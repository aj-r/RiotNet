using NUnit.Framework;
using RiotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotNet.Tests
{
    [TestFixture]
    public class RateLimiterTests
    {
        [Test]
        public void RateLimiter_ShouldNotThrottle()
        {
            IRateLimiter rateLimiter = new RateLimiter(2, 1000);
            rateLimiter.AddRequestOrGetDelay(PlatformId.NA1);
            DateTime targetDate = rateLimiter.AddRequestOrGetDelay(PlatformId.NA1);

            Assert.That(targetDate.Kind, Is.EqualTo(DateTimeKind.Utc));
            Assert.That(targetDate, Is.AtMost(DateTime.UtcNow));
        }

        [Test]
        public void RateLimiter_ShouldNotThrottle_DifferentPlatforms()
        {
            IRateLimiter rateLimiter = new RateLimiter(2, 1000);

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
            IRateLimiter rateLimiter = new RateLimiter(2, 1000);
            rateLimiter.AddRequestOrGetDelay(PlatformId.NA1);
            rateLimiter.AddRequestOrGetDelay(PlatformId.NA1);
            DateTime targetDate = rateLimiter.AddRequestOrGetDelay(PlatformId.NA1);

            Assert.That(targetDate.Kind, Is.EqualTo(DateTimeKind.Utc));
            Assert.That(targetDate, Is.GreaterThan(DateTime.UtcNow));
        }

        [Test]
        public void RateLimiter_ShouldThrottle_ForSecondLimit()
        {
            IRateLimiter rateLimiter = new RateLimiter(10, 5);
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
            IRateLimiter rateLimiter = new RateLimiter(2, 10);
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
            IRateLimiter rateLimiter = new RateLimiter(5, 100);

            var tasks = new List<Task<DateTime>>();
            for (var i = 0; i < 20; ++i)
                tasks.Add(Task.Run(() => rateLimiter.AddRequestOrGetDelay(PlatformId.NA1)));
            for (var i = 0; i < 20; ++i)
                tasks[i].Start();

            DateTime[] dates = await Task.WhenAll(tasks);
            var unthrottled = dates.Where(d => d <= DateTime.UtcNow).ToList();
            Assert.That(unthrottled, Is.EqualTo(5), "Wrong number of dates were unthrottled");
        }
    }
}
