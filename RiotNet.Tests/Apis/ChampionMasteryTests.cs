using Newtonsoft.Json;
using NUnit.Framework;
using RiotNet.Models;
using RiotNet.Tests.Properties;
using System;
using System.Threading.Tasks;

namespace RiotNet.Tests
{
    [TestFixture]
    public class ChampionMasteryTests : TestBase
    {
        [Test]
        public async Task GetChampionMasteryAsyncTest()
        {
            IRiotClient client = new RiotClient();
            var championMastery = await client.GetChampionMasteryAsync(34172230L, 412L); // Thresh

            Assert.That(championMastery, Is.Not.Null);
            Assert.That(championMastery.ChampionId, Is.EqualTo(412L));
            Assert.That(championMastery.LastPlayTime.Kind, Is.EqualTo(DateTimeKind.Utc));
            Assert.That(championMastery.LastPlayTime, Is.GreaterThan(new DateTime(2015, 1, 1, 0, 0, 0, DateTimeKind.Utc)).And.LessThanOrEqualTo(DateTime.UtcNow));
            Assert.That(championMastery.ChampionLevel, Is.AtLeast(1), "Invalid champion level.");
            Assert.That(championMastery.ChampionPoints, Is.AtLeast(1), "Invalid number of champion points.");
            Assert.That(championMastery.PlayerId, Is.EqualTo(34172230L));
        }

        [Test]
        public async Task GetChampionMasteriesAsyncTest()
        {
            IRiotClient client = new RiotClient();
            var championMasteries = await client.GetChampionMasteriesAsync(34172230L);

            Assert.That(championMasteries, Is.Not.Null.And.Not.Empty);
            foreach (var championMastery in championMasteries)
            {
                Assert.That(championMastery, Is.Not.Null);
                Assert.That(championMastery.ChampionId, Is.AtLeast(1), "Invalid champion ID.");
                Assert.That(championMastery.LastPlayTime, Is.GreaterThan(new DateTime(2015, 1, 1, 0, 0, 0, DateTimeKind.Utc)).And.LessThanOrEqualTo(DateTime.UtcNow));
                Assert.That(championMastery.ChampionLevel, Is.AtLeast(1), "Invalid champion level (champion ID: " + championMastery.ChampionId + ".");
                Assert.That(championMastery.ChampionPoints, Is.AtLeast(1), "Invalid number of champion points (champion ID: " + championMastery.ChampionId + ".");
                Assert.That(championMastery.PlayerId, Is.EqualTo(34172230L));
            }
        }

        [Test]
        public async Task GetChampionMasteryScoreAsyncTest()
        {
            IRiotClient client = new RiotClient();
            var score = await client.GetChampionMasteryScoreAsync(34172230L);

            Assert.That(score, Is.AtLeast(1));
        }

        [Test]
        public async Task GetChampionMasteryTopChampionsAsyncTest()
        {
            IRiotClient client = new RiotClient();
            var championMasteries = await client.GetChampionMasteryTopChampionsAsync(34172230L, 4);

            Assert.That(championMasteries, Is.Not.Null.And.Not.Empty);
            Assert.That(championMasteries.Count, Is.EqualTo(4), "Wrong number of entries.");
            foreach (var championMastery in championMasteries)
            {
                Assert.That(championMastery, Is.Not.Null);
                Assert.That(championMastery.ChampionId, Is.AtLeast(1), "Invalid champion ID.");
                Assert.That(championMastery.LastPlayTime, Is.GreaterThan(new DateTime(2015, 1, 1, 0, 0, 0, DateTimeKind.Utc)).And.LessThanOrEqualTo(DateTime.UtcNow));
                Assert.That(championMastery.ChampionLevel, Is.AtLeast(1), "Invalid champion level (champion ID: " + championMastery.ChampionId + ".");
                Assert.That(championMastery.ChampionPoints, Is.AtLeast(1), "Invalid number of champion points (champion ID: " + championMastery.ChampionId + ".");
                Assert.That(championMastery.PlayerId, Is.EqualTo(34172230L));
            }
        }

        [Test]
        public void DeserializeChampionMasteryTest()
        {
            var championMastery = JsonConvert.DeserializeObject<ChampionMastery>(Resources.SampleChampionMastery, RiotClient.JsonSettings);

            AssertNonDefaultValuesRecursive(championMastery);
        }
    }
}
