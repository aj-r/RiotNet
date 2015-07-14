using System;
using System.Threading.Tasks;
using NUnit.Framework;
using RiotNet.Models;

namespace RiotNet.Tests
{
    [TestFixture]
    public class RequestTests
    {
        [Test]
        public async Task RateLimitTest_ShouldRetry()
        {
            var client = new RiotClient(Region.NA);
            client.Settings.RetryOnRateLimitExceeded = true;
            client.Settings.ThrowOnError = true;
            for (var i = 0; i < 12; ++i)
                await client.GetMasterLeaguesTaskAsync(RankedQueue.RANKED_SOLO_5x5);
        }

        [Test]
        [ExpectedException(typeof(RateLimitExceededException))]
        public async Task RateLimitTest_ShouldThrow()
        {
            var client = new RiotClient(Region.NA);
            client.Settings.RetryOnRateLimitExceeded = false;
            client.Settings.ThrowOnError = true;
            for (var i = 0; i < 12; ++i)
                await client.GetMasterLeaguesTaskAsync(RankedQueue.RANKED_SOLO_5x5);
        }

        [Test]
        public async Task RateLimitTest_ShouldReturnNull()
        {
            var client = new RiotClient(Region.NA);
            client.Settings.RetryOnRateLimitExceeded = false;
            client.Settings.ThrowOnError = false;
            for (var i = 0; i < 10; ++i)
                await client.GetMasterLeaguesTaskAsync(RankedQueue.RANKED_SOLO_5x5);

            var league = await client.GetMasterLeaguesTaskAsync(RankedQueue.RANKED_SOLO_5x5);

            Assert.That(league, Is.Null);
        }
    }
}
