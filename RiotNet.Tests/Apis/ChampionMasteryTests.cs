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
        public async Task GetChampionMasteryAsyncTest()
        {
            IRiotClient client = new RiotClient();
            var championMastery = await client.GetChampionMasteryAsync(encryptedSummonerId, 412L); // Thresh

            Assert.That(championMastery, Is.Not.Null);
            Assert.That(championMastery.ChampionId, Is.EqualTo(412L));
            Assert.That(championMastery.LastPlayTime.Kind, Is.EqualTo(DateTimeKind.Utc));
            Assert.That(championMastery.LastPlayTime, Is.GreaterThan(new DateTime(2015, 1, 1, 0, 0, 0, DateTimeKind.Utc)).And.LessThanOrEqualTo(DateTime.UtcNow));
            Assert.That(championMastery.ChampionLevel, Is.AtLeast(1), "Invalid champion level.");
            Assert.That(championMastery.ChampionPoints, Is.AtLeast(1), "Invalid number of champion points.");
            // Riot is returning wrong data for no known reason. It returns the summoner id encrypted in a different way than the other endpoints. Check this when v4 is totally active and v3 deprectated
            //Assert.That(championMastery.SummonerId, Is.EqualTo(EncryptedSummonerId));
        }

        [Test]
        public async Task GetChampionMasteriesAsyncTest()
        {
            IRiotClient client = new RiotClient();
            var championMasteries = await client.GetChampionMasteriesAsync(encryptedSummonerId);

            Assert.That(championMasteries, Is.Not.Null.And.Not.Empty);
            foreach (var championMastery in championMasteries)
            {
                Assert.That(championMastery, Is.Not.Null);
                Assert.That(championMastery.ChampionId, Is.AtLeast(1), "Invalid champion ID.");
                Assert.That(championMastery.LastPlayTime, Is.GreaterThan(new DateTime(2015, 1, 1, 0, 0, 0, DateTimeKind.Utc)).And.LessThanOrEqualTo(DateTime.UtcNow));
                Assert.That(championMastery.ChampionLevel, Is.AtLeast(1), "Invalid champion level (champion ID: " + championMastery.ChampionId + ".");
                Assert.That(championMastery.ChampionPoints, Is.AtLeast(1), "Invalid number of champion points (champion ID: " + championMastery.ChampionId + ".");
                Assert.That(championMastery.SummonerId, Is.EqualTo(encryptedSummonerId));
            }
        }

        [Test]
        public async Task GetChampionMasteryScoreAsyncTest()
        {
            IRiotClient client = new RiotClient();
            var score = await client.GetChampionMasteryScoreAsync(encryptedSummonerId);

            Assert.That(score, Is.AtLeast(1));
        }

        [Test]
        public void DeserializeChampionMasteryTest()
        {
            var championMastery = JsonConvert.DeserializeObject<ChampionMastery>(Resources.SampleChampionMastery, RiotClient.JsonSettings);

            AssertNonDefaultValuesRecursive(championMastery);
        }
    }
}
