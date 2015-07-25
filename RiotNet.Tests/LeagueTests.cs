using System;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using RiotNet.Models;
using RiotNet.Tests.Properties;

namespace RiotNet.Tests
{
    [TestFixture]
    public class LeagueTests : TestBase
    {
        [Test]
        public async Task GetLeaguesBySummonerIdsTaskAsyncTest()
        {
            IRiotClient client = new RiotClient();
            var summonerIds = new[] { 35870943L, 34317083L };
            var leagues = await client.GetLeaguesBySummonerIdsTaskAsync(summonerIds);

            Assert.That(leagues, Is.Not.Null);
            foreach (var id in summonerIds)
                Assert.That(leagues.ContainsKey(id.ToString()));
            var league = leagues.Values.First().First();
            Assert.That(league.Entries.Count, Is.GreaterThan(1));
            Assert.That(league.Name, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public async Task GetLeagueEntriesBySummonerIdsTaskAsyncTest()
        {
            IRiotClient client = new RiotClient();
            var summonerIds = new[] { 35870943L, 34317083L };
            var leagues = await client.GetLeagueEntriesBySummonerIdsTaskAsync(summonerIds);

            Assert.That(leagues, Is.Not.Null);
            foreach (var id in summonerIds)
                Assert.That(leagues.ContainsKey(id.ToString()));
            var league = leagues.Values.First().First();
            Assert.That(league.Entries.Count, Is.EqualTo(1));
            Assert.That(league.Name, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public async Task GetLeaguesByTeamIdsTaskAsyncTest()
        {
            IRiotClient client = new RiotClient();
            var teamIds = new[] { "TEAM-3503e740-b492-11e3-809d-782bcb4d0bb2", "TEAM-2a88df50-da0d-11e3-b43f-782bcb4d1861" };
            var leagues = await client.GetLeaguesByTeamIdsTaskAsync(teamIds);

            Assert.That(leagues, Is.Not.Null);
            foreach (var id in teamIds)
                Assert.That(leagues.ContainsKey(id));
            var league = leagues.Values.First().First();
            Assert.That(league.Entries.Count, Is.GreaterThan(1));
            Assert.That(league.Name, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public async Task GetLeagueEntriesByTeamIdsTaskAsyncTest()
        {
            IRiotClient client = new RiotClient();
            var teamIds = new[] { "TEAM-3503e740-b492-11e3-809d-782bcb4d0bb2", "TEAM-2a88df50-da0d-11e3-b43f-782bcb4d1861" };
            var leagues = await client.GetLeagueEntriesByTeamIdsTaskAsync(teamIds);

            Assert.That(leagues, Is.Not.Null);
            foreach (var id in teamIds)
                Assert.That(leagues.ContainsKey(id));
            var league = leagues.Values.First().First();
            Assert.That(league.Entries.Count, Is.EqualTo(1));
            Assert.That(league.Name, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public async Task GetChallengerLeagueTaskAsyncTest()
        {
            IRiotClient client = new RiotClient();
            var league = await client.GetChallengerLeagueTaskAsync(RankedQueue.RANKED_SOLO_5x5);

            Assert.That(league, Is.Not.Null);
            Assert.That(league.Entries.Count, Is.GreaterThan(1));
            Assert.That(league.Name, Is.Not.Null.And.Not.Empty);
            Assert.That(league.Queue, Is.EqualTo(RankedQueue.RANKED_SOLO_5x5));
            Assert.That(league.Tier, Is.EqualTo(Tier.CHALLENGER));
        }

        [Test]
        public async Task GetMasterLeagueTaskAsyncTest()
        {
            IRiotClient client = new RiotClient();
            var league = await client.GetMasterLeagueTaskAsync(RankedQueue.RANKED_TEAM_3x3);

            Assert.That(league, Is.Not.Null);
            Assert.That(league.Entries.Count, Is.GreaterThan(1));
            Assert.That(league.Name, Is.Not.Null.And.Not.Empty);
            Assert.That(league.Queue, Is.EqualTo(RankedQueue.RANKED_TEAM_3x3));
            Assert.That(league.Tier, Is.EqualTo(Tier.MASTER));
        }

        [Test]
        public void DeserializeLeagueTest()
        {
            var league = JsonConvert.DeserializeObject<League>(Resources.SampleLeague, RiotClient.JsonSettings);

            AssertNonDefaultValuesRecursive(league);
        }
    }
}
