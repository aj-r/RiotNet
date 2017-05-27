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
        public async Task GetShardDataAsyncTest()
        {
            IRiotClient client = new RiotClient();
            ShardStatus shard = await client.GetShardDataAsync();

            Assert.That(shard, Is.Not.Null);
            Assert.That(shard.Name, Is.Not.Null.And.Not.Empty);
            Assert.That(shard.Slug, Is.Not.Null.And.Not.Empty);
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
