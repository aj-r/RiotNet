using NUnit.Framework;
using RiotNet.Models;
using System;

namespace RiotNet.Tests
{
    /// <summary>
    /// Tests non-request-related functionality of the <see cref="RiotClient"/>.
    /// </summary>
    [TestFixture]
    public class RiotClientTests : TestBase
    {
        [Test]
        public void GetPlatformId_ShouldGetCorrectValue()
        {
            var platformId = RiotClient.GetPlatformId(Region.NA);
            Assert.That(platformId, Is.EqualTo("NA1"));
        }

        [Test]
        public void GetPlatformId_ShouldBeDefinedForAllRegions()
        {
            foreach (Region region in Enum.GetValues(typeof(Region)))
            {
                var platformId = RiotClient.GetPlatformId(region);
                Assert.That(platformId, Is.Not.Null.And.Not.Empty);
            }
        }

        [Test]
        public void PlatformId_Property_ShouldBeCorrectForAllRegions()
        {
            foreach (Region region in Enum.GetValues(typeof(Region)))
            {
                IRiotClient client = new RiotClient(region);
                var expectedPlatformId = RiotClient.GetPlatformId(region);
                Assert.That(client.PlatformId, Is.EqualTo(expectedPlatformId));
            }
        }

        [Test]
        public void GetServerName_ShouldGetCorrectValue()
        {
            var server = RiotClient.GetServerName(Region.NA);
            Assert.That(server, Is.EqualTo("na.api.pvp.net"));
        }

        [Test]
        public void GetServerName_ShouldBeDefinedForAllRegions()
        {
            foreach (Region region in Enum.GetValues(typeof(Region)))
            {
                var server = RiotClient.GetServerName(region);
                Assert.That(server, Is.Not.Null.And.Not.Empty);
            }
        }

        [Test]
        public void ShouldCreateClientWithDefaultRegion()
        {
            RiotClient.DefaultRegion = Region.EUNE;
            IRiotClient client = new RiotClient();

            Assert.That(client.Region, Is.EqualTo(Region.EUNE));
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

            IRiotClient client = new RiotClient(Region.OCE, new RiotClientSettings
            {
                ApiKey = apiKey,
                RetryOnTimeout = true,
                RetryOnConnectionFailure = true,
                RetryOnRateLimitExceeded = true
            });

            Assert.That(client.Region, Is.EqualTo(Region.OCE));
            Assert.That(client.Settings.ApiKey, Is.EqualTo(apiKey));
            Assert.That(client.Settings.RetryOnTimeout);
            Assert.That(client.Settings.RetryOnConnectionFailure);
            Assert.That(client.Settings.RetryOnRateLimitExceeded);
        }
    }
}
