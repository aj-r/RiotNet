using NUnit.Framework;
using RiotNet.Models;
using System.Threading.Tasks;

namespace RiotNet.Tests
{
    [TestFixture]
    [Ignore("These tests are desgned to max out the rate limit, and can only be run if explicitly selected.")]
    public class RequestTests : TestBase
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
                Assert.That(league, Is.Not.Null);
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

        private async Task MaxOutRateLimit(IRiotClient client)
        {
            for (var i = 0; i < 11; ++i)
                await client.GetMasterLeagueAsync(RankedQueue.RANKED_SOLO_5x5);
        }
    }
}
