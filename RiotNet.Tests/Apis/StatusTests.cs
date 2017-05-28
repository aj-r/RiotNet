using Newtonsoft.Json;
using NUnit.Framework;
using RiotNet.Models;
using RiotNet.Tests.Properties;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RiotNet.Tests
{
    [TestFixture]
    public class StatusTests : TestBase
    {
        [Test]
        public async Task GetShardDataAsyncTest_WithDefaultPlatformId()
        {
            RiotClient.DefaultPlatformId = PlatformId.EUN1;
            IRiotClient client = new RiotClient();
            ShardStatus shard = await client.GetShardDataAsync();

            Assert.That(shard, Is.Not.Null);
            Assert.That(shard.Name, Is.EqualTo("EU Nordic & East"));
            Assert.That(shard.Slug, Is.EqualTo("eune"));
            Assert.That(shard.RegionTag, Is.EqualTo("eun1"));
            Assert.That(shard.Hostname, Is.Not.Null.And.Not.Empty);
            Assert.That(shard.Services, Is.Not.Null.And.Not.Empty);
            Assert.That(shard.Locales, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public async Task GetShardDataAsyncTest_WithClientPlatformId()
        {
            IRiotClient client = new RiotClient(PlatformId.LA2);
            ShardStatus shard = await client.GetShardDataAsync();

            Assert.That(shard, Is.Not.Null);
            Assert.That(shard.Name, Is.EqualTo("Latin America South"));
            Assert.That(shard.Slug, Is.EqualTo("las"));
            Assert.That(shard.RegionTag, Is.EqualTo("la2"));
        }

        [Test]
        public async Task GetShardDataAsyncTest_WithPlatformIdParameter()
        {
            IRiotClient client = new RiotClient();
            ShardStatus shard = await client.GetShardDataAsync(PlatformId.KR);

            Assert.That(shard, Is.Not.Null);
            Assert.That(shard.Name, Is.EqualTo("Republic of Korea"));
            Assert.That(shard.Slug, Is.EqualTo("kr"));
            Assert.That(shard.RegionTag, Is.EqualTo("kr1"));
        }

        [Test]
        public void DeserializeShardStatusTest()
        {
            ShardStatus shard = JsonConvert.DeserializeObject<ShardStatus>(Resources.SampleShardStatus, RiotClient.JsonSettings);

            AssertNonDefaultValuesRecursive(shard);
            Incident incident = shard.Services.First().Incidents.First();
            Assert.That(incident.CreatedAt, Is.EqualTo(new DateTime(2015, 7, 19, 2, 23, 10, DateTimeKind.Utc)));
        }
    }
}
