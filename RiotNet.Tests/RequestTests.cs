using System;
using System.Threading.Tasks;
using NUnit.Framework;
using RiotNet.Models;

namespace RiotNet.Tests
{
    [TestFixture]
    [Explicit("These tests are desgned to max out the rate limit, and can only be run if explicitly selected.")]
    public class RequestTests : TestBase
    {
        [Test]
        public async Task RateLimitTest_Async_ShouldRetry()
        {
            IRiotClient client = new RiotClient();
            client.Settings.RetryOnRateLimitExceeded = true;
            client.Settings.ThrowOnError = true;
            for (var i = 0; i < 12; ++i)
            {
                var league = await client.GetMasterLeagueTaskAsync(RankedQueue.RANKED_SOLO_5x5);
                Assert.That(league, Is.Not.Null);
            }
        }

        [Test]
        public void RateLimitTest_Sync_ShouldRetry()
        {
            IRiotClient client = new RiotClient();
            client.Settings.RetryOnRateLimitExceeded = true;
            client.Settings.ThrowOnError = true;
            for (var i = 0; i < 12; ++i)
            {
                var league = client.GetMasterLeague(RankedQueue.RANKED_SOLO_5x5);
                Assert.That(league, Is.Not.Null);
            }
        }

        [Test]
        [ExpectedException(typeof(RateLimitExceededException))]
        public async Task RateLimitTest_Async_ShouldThrow()
        {
            IRiotClient client = new RiotClient();
            client.Settings.RetryOnRateLimitExceeded = false;
            client.Settings.ThrowOnError = true;
            for (var i = 0; i < 12; ++i)
                await client.GetMasterLeagueTaskAsync(RankedQueue.RANKED_SOLO_5x5);
        }

        [Test]
        [ExpectedException(typeof(RateLimitExceededException))]
        public void RateLimitTest_Sync_ShouldThrow()
        {
            IRiotClient client = new RiotClient();
            client.Settings.RetryOnRateLimitExceeded = false;
            client.Settings.ThrowOnError = true;
            for (var i = 0; i < 12; ++i)
                client.GetMasterLeague(RankedQueue.RANKED_SOLO_5x5);
        }

        [Test]
        public async Task RateLimitTest_Async_ShouldReturnNull()
        {
            IRiotClient client = new RiotClient();
            client.Settings.RetryOnRateLimitExceeded = false;
            client.Settings.ThrowOnError = false;
            for (var i = 0; i < 10; ++i)
                await client.GetMasterLeagueTaskAsync(RankedQueue.RANKED_SOLO_5x5);

            var league = await client.GetMasterLeagueTaskAsync(RankedQueue.RANKED_SOLO_5x5);

            Assert.That(league, Is.Null);
        }

        [Test]
        public void RateLimitTest_Sync_ShouldReturnNull()
        {
            IRiotClient client = new RiotClient();
            client.Settings.RetryOnRateLimitExceeded = false;
            client.Settings.ThrowOnError = false;
            for (var i = 0; i < 10; ++i)
                client.GetMasterLeague(RankedQueue.RANKED_SOLO_5x5);

            var league = client.GetMasterLeague(RankedQueue.RANKED_SOLO_5x5);

            Assert.That(league, Is.Null);
        }
    }
}
