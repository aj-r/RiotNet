using NUnit.Framework;
using RiotNet.Models;
using System.Threading;
using System.Threading.Tasks;

namespace RiotNet.Tests
{
    /// <summary>
    /// Tests non-request-related functionality of the <see cref="RiotClient"/>.
    /// </summary>
    [TestFixture]
    public class RiotClientTests : TestBase
    {
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
        public async Task ShouldCancelRequest()
        {
            RiotClientSettings settings = RiotClient.DefaultSettings();
            settings.RetryOnTimeout = false;
            settings.ThrowOnError = false;
            IRiotClient client = new RiotClient(settings);

            bool cancelled = false;
            client.RequestTimedOut += (sender, e) =>
            {
                e.Retry = false;
                cancelled = true;
            };

            var cts = new CancellationTokenSource();
            Task<ShardStatus> task = client.GetShardStatusAsync(token: cts.Token);
            cts.Cancel();

            await task;
            Assert.That(cancelled, Is.True);
        }

        [Test]
        public void ShouldCancelRequest_AndThrowException()
        {
            RiotClientSettings settings = RiotClient.DefaultSettings();
            settings.RetryOnTimeout = false;
            settings.ThrowOnError = true;
            IRiotClient client = new RiotClient(settings);

            var cts = new CancellationTokenSource();
            Task<ShardStatus> task = client.GetShardStatusAsync(token: cts.Token);
            cts.Cancel();

            Assert.That((AsyncTestDelegate)(() => task), Throws.InstanceOf<RestTimeoutException>());
        }
    }
}
