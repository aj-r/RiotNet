using Newtonsoft.Json;
using NUnit.Framework;
using RiotNet.Models;
using RiotNet.Tests.Properties;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiotNet.Tests
{
    [TestFixture]
    public class LeagueTests : TestBase
    {
        string encryptedSummonerId;

        [OneTimeSetUp]
        public async Task TestOneTimeSetUp()
        {
            SetRiotClientSettings();
            IRiotClient client = new RiotClient();
            var summoner = await client.GetSummonerBySummonerNameAsync("Abou222");
            encryptedSummonerId = summoner.Id;
        }

        [Test]
        public async Task GetLeagueByIdAsyncTest()
        {
            IRiotClient client = new RiotClient();
            LeagueList league = await client.GetLeagueByIdAsync("a681d5d0-430e-11e8-a82d-c81f66cf2333");

            Assert.That(league, Is.Not.Null);
            Assert.That(league.Entries.Count, Is.GreaterThan(1));
            Assert.That(league.Name, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public async Task GetLeagueEntriesBySummonerIdAsync()
        {
            IRiotClient client = new RiotClient();
            List<LeagueEntry> leagueEntries = await client.GetLeagueEntriesBySummonerIdAsync(encryptedSummonerId);

            Assert.That(leagueEntries, Is.Not.Null);
            var leagueEntry = leagueEntries.First();
            Assert.That(leagueEntry.LeagueId, Is.Not.Null.And.Not.Empty);
            Assert.That(leagueEntry.QueueType, Is.Not.Null.And.Not.Empty);
            Assert.That(leagueEntry.Tier, Is.Not.EqualTo(Tier.CHALLENGER));
            Assert.That(leagueEntry.Rank, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public async Task GetLeagueEntriesAsync()
        {
            IRiotClient client = new RiotClient();
            List<LeagueEntry> leagueEntries = await client.GetLeagueEntriesAsync(RankedQueue.RANKED_SOLO_5x5, Tier.PLATINUM, Division.IV, 2);

            Assert.That(leagueEntries, Is.Not.Null);
            var leagueEntry = leagueEntries.First();
            Assert.That(leagueEntry.QueueType, Is.Not.Null.And.Not.Empty);
            Assert.That(leagueEntry.Tier, Is.Not.EqualTo(Tier.CHALLENGER));
            Assert.That(leagueEntry.Rank, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public async Task GetChallengerLeagueAsyncTest()
        {
            IRiotClient client = new RiotClient();
            LeagueList league = await client.GetChallengerLeagueAsync(RankedQueue.RANKED_SOLO_5x5);

            Assert.That(league, Is.Not.Null);
            Assert.That(league.Entries.Count, Is.GreaterThan(1));
            Assert.That(league.Name, Is.Not.Null.And.Not.Empty);
            Assert.That(league.Queue, Is.EqualTo(RankedQueue.RANKED_SOLO_5x5));
            Assert.That(league.Tier, Is.EqualTo(Tier.CHALLENGER));
        }

        [Test]
        public async Task GetGrandmasterLeagueAsyncTest()
        {
            IRiotClient client = new RiotClient();
            LeagueList league = await client.GetGrandmasterLeagueAsync(RankedQueue.RANKED_SOLO_5x5);

            Assert.That(league, Is.Not.Null);
            Assert.That(league.Entries.Count, Is.GreaterThan(1));
            Assert.That(league.Name, Is.Not.Null.And.Not.Empty);
            Assert.That(league.Queue, Is.EqualTo(RankedQueue.RANKED_SOLO_5x5));
            Assert.That(league.Tier, Is.EqualTo(Tier.GRANDMASTER));
        }

        [Test]
        public async Task GetMasterLeagueAsyncTest()
        {
            IRiotClient client = new RiotClient();
            LeagueList league = await client.GetMasterLeagueAsync(RankedQueue.RANKED_SOLO_5x5);

            Assert.That(league, Is.Not.Null);
            Assert.That(league.Entries.Count, Is.GreaterThan(1));
            Assert.That(league.Name, Is.Not.Null.And.Not.Empty);
            Assert.That(league.Queue, Is.EqualTo(RankedQueue.RANKED_SOLO_5x5));
            Assert.That(league.Tier, Is.EqualTo(Tier.MASTER));
        }

        [Test]
        public void DeserializeLeagueTest()
        {
            var league = JsonConvert.DeserializeObject<LeagueList>(Resources.SampleLeague, RiotClient.JsonSettings);

            AssertNonDefaultValuesRecursive(league);
        }
    }
}
