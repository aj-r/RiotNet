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
    public class StatsTests : TestBase
    {
        [Test]
        public async Task GetRankedStatsAsyncTest()
        {
            IRiotClient client = new RiotClient();
            var stats = await client.GetRankedStatsAsync(35870943L);

            Assert.That(stats, Is.Not.Null);
            Assert.That(stats.Champions, Is.Not.Null.And.Not.Empty);
            Assert.That(stats.SummonerId, Is.EqualTo(35870943L));
            Assert.That(stats.ModifyDate.Kind, Is.EqualTo(DateTimeKind.Utc));
            Assert.That(stats.ModifyDate, Is.GreaterThan(default(DateTime)).And.LessThan(DateTime.UtcNow));
            // There should be one entry with champion ID 0 that represents the combined stats for all champions.
            Assert.That(stats.Champions.Any(c => c.Id == 0));
        }

        [Test]
        public async Task GetRankedStatsAsyncTest_WithSeason()
        {
            IRiotClient client = new RiotClient();
            var stats = await client.GetRankedStatsAsync(35870943L, Season.SEASON2014);

            Assert.That(stats, Is.Not.Null);
            Assert.That(stats.Champions, Is.Not.Null.And.Not.Empty);
            Assert.That(stats.SummonerId, Is.EqualTo(35870943L));
            Assert.That(stats.ModifyDate.Kind, Is.EqualTo(DateTimeKind.Utc));
            Assert.That(stats.ModifyDate, Is.GreaterThan(default(DateTime)).And.LessThan(new DateTime(2015, 2, 1, 0, 0, 0, DateTimeKind.Utc)));
        }

        [Test]
        public void DeserializeRankedStatsTest()
        {
            var stats = JsonConvert.DeserializeObject<RankedStats>(Resources.SampleRankedStats, RiotClient.JsonSettings);

            AssertNonDefaultValuesRecursive(stats);
        }

        [Test]
        public async Task GetStatsSummaryAsyncTest()
        {
            IRiotClient client = new RiotClient();
            var stats = await client.GetStatsSummaryAsync(35870943L);

            Assert.That(stats, Is.Not.Null);
            Assert.That(stats.PlayerStatSummaries, Is.Not.Null.And.Not.Empty);
            Assert.That(stats.SummonerId, Is.EqualTo(35870943L));
        }

        [Test]
        public async Task GetStatsSummaryAsyncTest_WithSeason()
        {
            IRiotClient client = new RiotClient();
            var stats = await client.GetStatsSummaryAsync(35870943L, Season.SEASON2014);

            Assert.That(stats, Is.Not.Null);
            Assert.That(stats.PlayerStatSummaries, Is.Not.Null.And.Not.Empty);
            foreach (var summary in stats.PlayerStatSummaries)
                Assert.That(summary.ModifyDate, Is.LessThan(new DateTime(2015, 2, 1, 0, 0, 0, DateTimeKind.Utc)));
            Assert.That(stats.SummonerId, Is.EqualTo(35870943L));
        }

        [Test]
        public void DeserializePlayerStatsSummaryListTest()
        {
            var stats = JsonConvert.DeserializeObject<PlayerStatsSummaryList>(Resources.SampleStatsSummary, RiotClient.JsonSettings);

            AssertNonDefaultValuesRecursive(stats);
        }
    }
}
