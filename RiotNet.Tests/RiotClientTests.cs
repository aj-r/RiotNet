using NUnit.Framework;
using RiotNet.Models;
using System.Threading.Tasks;

namespace RiotNet.Tests
{
    /// <summary>
    /// Tests non-request-related functionality of the <see cref="RiotClient"/>.
    /// </summary>
    [TestFixture]
    public class RiotClientTests : TestBase
    {
        string encryptedSummonerId;

        [OneTimeSetUp]
        public async Task TestOneTimeSetUp()
        {
            SetRiotClientSettings();
            IRiotClient client = new RiotClient();
            var summoner = await client.GetSummonerBySummonerNameAsync("KirkBerkley");
            encryptedSummonerId = summoner.Id;
        }

        [Test]
        public void ShouldCreateClientWithDefaultPlatformId()
        {
            RiotClient.DefaultPlatformId = PlatformId.EUN1;
            IRiotClient client = new RiotClient();

            Assert.That(client.PlatformId, Is.EqualTo(PlatformId.EUN1));
        }

        [Test]
        public void ShouldCreateClientWithDefaultSettings()
        {
            var apiKey = "46633DC8-0034-4691-A002-49E234D5D0E8"; // No, this is not a real API key. It's just used for this test.
            RiotClient.DefaultSettings = () => new RiotClientSettings
            {
                ApiKey = apiKey,
                RetryOnTimeout = true,
                RetryOnConnectionFailure = true,
                RetryOnRateLimitExceeded = true
            };

            IRiotClient client = new RiotClient();

            Assert.That(client.Settings.ApiKey, Is.EqualTo(apiKey));
            Assert.That(client.Settings.RetryOnTimeout);
            Assert.That(client.Settings.RetryOnConnectionFailure);
            Assert.That(client.Settings.RetryOnRateLimitExceeded);
        }

        [Test]
        public void ShouldCreateClientWithNonDefaultSettings()
        {
            var apiKey = "46633DC8-0034-4691-A002-49E234D5D0E8"; // No, this is not a real API key. It's just used for this test.

            IRiotClient client = new RiotClient(new RiotClientSettings
            {
                ApiKey = apiKey,
                RetryOnTimeout = true,
                RetryOnConnectionFailure = true,
                RetryOnRateLimitExceeded = true
            }, PlatformId.OC1);

            Assert.That(client.PlatformId, Is.EqualTo(PlatformId.OC1));
            Assert.That(client.Settings.ApiKey, Is.EqualTo(apiKey));
            Assert.That(client.Settings.RetryOnTimeout);
            Assert.That(client.Settings.RetryOnConnectionFailure);
            Assert.That(client.Settings.RetryOnRateLimitExceeded);
        }

        [Test]
        public void ShouldThrowErrorIfNoPlatformId()
        {
            RiotClient.DefaultPlatformId = null;
            IRiotClient client = new RiotClient();

            Assert.That(() => client.GetSummonerBySummonerIdAsync(encryptedSummonerId), Throws.InstanceOf<RestException>());
        }
    }
}
