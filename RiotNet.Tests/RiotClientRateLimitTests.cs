using NUnit.Framework;
using RiotNet.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RiotNet.Tests
{
    // Note: these tests assume you have a development API key with a limit of 10 requests per second.
    [TestFixture]
    public class RateLimitTests : TestBase
    {
        [Test]
        public async Task RateLimitTest_ShouldRetry()
        {
            IRiotClient client = new RiotClient();
            client.Settings.MaxRequestAttempts = 2;
            client.Settings.RetryOnRateLimitExceeded = true;
            client.Settings.ThrowOnError = true;
            for (var i = 0; i < 11; ++i)
            {
                var league = await client.GetMasterLeagueAsync(RankedQueue.RANKED_SOLO_5x5);
                Assert.That(league, Is.Not.Null, "Failed to get league: " + i);
            }
        }

        [Test]
        public void RateLimitTest_ShouldThrow()
        {
            IRiotClient client = new RiotClient();
            client.Settings.RetryOnRateLimitExceeded = false;
            client.Settings.ThrowOnError = true;
            Assert.ThrowsAsync<RateLimitExceededException>(() => MaxOutRateLimit(client));
        }

        [Test]
        public async Task RateLimitTest_ShouldReturnNull()
        {
            IRiotClient client = new RiotClient();
            client.Settings.RetryOnRateLimitExceeded = false;
            client.Settings.ThrowOnError = false;
            await MaxOutRateLimit(client);

            var league = await client.GetMasterLeagueAsync(RankedQueue.RANKED_SOLO_5x5);

            Assert.That(league, Is.Null);
        }

        [Test]
        public async Task RateLimitTest_ShouldDelayFutureRequests()
        {
            IRiotClient client = new RiotClient();
            client.Settings.MaxRequestAttempts = 2;
            client.Settings.RetryOnRateLimitExceeded = true;

            var tasks = new List<Task<LeagueList>>();
            for (var i = 0; i < 11; ++i)
            {
                tasks.Add(client.GetMasterLeagueAsync(RankedQueue.RANKED_SOLO_5x5));
            }
            IRiotClient client2 = new RiotClient(client.Settings);
            bool rateLimitExceeded = false;
            client2.RateLimitExceeded += (o, e) => rateLimitExceeded = true;
            tasks.Add(client2.GetMasterLeagueAsync(RankedQueue.RANKED_SOLO_5x5));
            var leagues = await Task.WhenAll(tasks);

            Assert.That(rateLimitExceeded, Is.False, "Rate limit was exceeded! Proactive rate limiting failed.");
            for (var i = 0; i < 11; ++i)
                Assert.That(leagues[i], Is.Not.Null, "Failed to get league: " + i);
        }

        [Test]
        public async Task RateLimitTest_ShouldApplyRateLimiter_FromStaticProperty()
        {
            RiotClient.RateLimiter = new RateLimiter(10, 600);
            IRiotClient client = new RiotClient();
            client.Settings.RetryOnRateLimitExceeded = true;

            bool rateLimitExceeded = false;
            client.RateLimitExceeded += (o, e) =>
            {
                if (e.Response != null)
                    rateLimitExceeded = true;
            };

            for (var i = 0; i < 12; ++i)
            {
                var league = await client.GetMasterLeagueAsync(RankedQueue.RANKED_SOLO_5x5);
                Assert.That(league, Is.Not.Null, "Failed to get league: " + i);
            }
            Assert.That(rateLimitExceeded, Is.False, "Rate limit was exceeded! Proactive rate limiting failed.");
        }

        [Test]
        public async Task RateLimitTest_ShouldApplyRateLimiter_WithConcurrentRequests()
        {
            RiotClient.RateLimiter = new RateLimiter(10, 600);
            bool rateLimitExceeded = false;
            RetryEventHandler onRateLimitExceeded = (o, e) =>
            {
                if (e.Response != null)
                    rateLimitExceeded = true;
            };

            var tasks = new List<Task<LeagueList>>();
            for (var i = 0; i < 20; ++i)
            {
                tasks.Add(Task.Run(() =>
                {
                    IRiotClient client = new RiotClient();
                    client.Settings.RetryOnRateLimitExceeded = true;
                    client.RateLimitExceeded += onRateLimitExceeded;

                    return client.GetMasterLeagueAsync(RankedQueue.RANKED_SOLO_5x5);
                }));
            }

            var leagues = await Task.WhenAll(tasks);

            Assert.That(rateLimitExceeded, Is.False, "Rate limit was exceeded! Proactive rate limiting failed.");
            for (var i = 0; i < 20; ++i)
                Assert.That(leagues[i], Is.Not.Null, "Failed to get league: " + i);
        }

        [Test]
        public async Task RateLimitTest_ShouldApplyRateLimiter_FromConstructor()
        {
            IRiotClient client = new RiotClient(new RateLimiter(10, 600));
            client.Settings.RetryOnRateLimitExceeded = true;

            bool rateLimitExceeded = false;
            client.RateLimitExceeded += (o, e) =>
            {
                if (e.Response != null)
                    rateLimitExceeded = true;
            };

            for (var i = 0; i < 12; ++i)
            {
                var league = await client.GetMasterLeagueAsync(RankedQueue.RANKED_SOLO_5x5);
                Assert.That(league, Is.Not.Null, "Failed to get league: " + i);
            }
            Assert.That(rateLimitExceeded, Is.False, "Rate limit was exceeded! Proactive rate limiting failed.");
        }

        private async Task MaxOutRateLimit(IRiotClient client)
        {
            for (var i = 0; i < 11; ++i)
                await client.GetMasterLeagueAsync(RankedQueue.RANKED_SOLO_5x5);
        }
    }
}
