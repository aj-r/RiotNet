using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using RiotNet.Models;
using RiotNet.Tests.Properties;

namespace RiotNet.Tests
{
    [TestFixture]
    public class StatusTests : TestBase
    {
        [Test]
        public async Task GetShardsAsyncTest()
        {
            IRiotClient client = new RiotClient();
            var shards = await client.GetShardsAsync();

            Assert.That(shards, Is.Not.Null.And.Not.Empty);
            var shard = shards.First();
            Assert.That(shard.Name, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public async Task GetShardStatusAsyncTest()
        {
            IRiotClient client = new RiotClient();
            var shard = await client.GetShardStatusAsync();

            Assert.That(shard, Is.Not.Null);
            Assert.That(shard.Name, Is.Not.Null.And.Not.Empty);
            Assert.That(shard.Slug, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public void DeseializeShardStatusTest()
        {
            var shard = JsonConvert.DeserializeObject<ShardStatus>(Resources.SampleShardStatus, RiotClient.JsonSettings);

            AssertNonDefaultValuesRecursive(shard);
            var incident = shard.Services.First().Incidents.First();
            Assert.That(incident.CreatedAt, Is.EqualTo(new DateTime(2015, 7, 19, 2, 23, 10, DateTimeKind.Utc)));
        }
    }
}
