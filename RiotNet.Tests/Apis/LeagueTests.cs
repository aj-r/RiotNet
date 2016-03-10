using System;
using System.Globalization;
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
        public async Task GetLeaguesBySummonerIdsAsyncTest()
        {
            IRiotClient client = new RiotClient();
            var summonerIds = new[] { 35870943L, 34172230L };
            var leagues = await client.GetLeaguesBySummonerIdsAsync(summonerIds);

            Assert.That(leagues, Is.Not.Null);
            foreach (var id in summonerIds)
                Assert.That(leagues.ContainsKey(id.ToString(CultureInfo.InvariantCulture)));
            var league = leagues.Values.First().First();
            Assert.That(league.Entries.Count, Is.GreaterThan(1));
            Assert.That(league.Name, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public async Task GetLeagueEntriesBySummonerIdsAsyncTest()
        {
            IRiotClient client = new RiotClient();
            var summonerIds = new[] { 35870943L, 34172230L };
            var leagues = await client.GetLeagueEntriesBySummonerIdsAsync(summonerIds);

            Assert.That(leagues, Is.Not.Null);
            foreach (var id in summonerIds)
                Assert.That(leagues.ContainsKey(id.ToString(CultureInfo.InvariantCulture)));
            var league = leagues.Values.First().First();
            Assert.That(league.Entries.Count, Is.EqualTo(1));
            Assert.That(league.Name, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        [Explicit("Teams aren't really a thing anymore (except 3v3), so these teams might not even have a league entry.")]
        public async Task GetLeaguesByTeamIdsAsyncTest()
        {
            IRiotClient client = new RiotClient();
            var teamIds = new[] { "TEAM-3503e740-b492-11e3-809d-782bcb4d0bb2", "TEAM-2a88df50-da0d-11e3-b43f-782bcb4d1861" };
            var leagues = await client.GetLeaguesByTeamIdsAsync(teamIds);

            Assert.That(leagues, Is.Not.Null);
            foreach (var id in teamIds)
                Assert.That(leagues.ContainsKey(id));
            var league = leagues.Values.First().First();
            Assert.That(league.Entries.Count, Is.GreaterThan(1));
            Assert.That(league.Name, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        [Explicit("Teams aren't really a thing anymore (except 3v3), so these teams might not even have a league entry.")]
        public async Task GetLeagueEntriesByTeamIdsAsyncTest()
        {
            IRiotClient client = new RiotClient();
            var teamIds = new[] { "TEAM-3503e740-b492-11e3-809d-782bcb4d0bb2", "TEAM-2a88df50-da0d-11e3-b43f-782bcb4d1861" };
            var leagues = await client.GetLeagueEntriesByTeamIdsAsync(teamIds);

            Assert.That(leagues, Is.Not.Null);
            foreach (var id in teamIds)
                Assert.That(leagues.ContainsKey(id));
            var league = leagues.Values.First().First();
            Assert.That(league.Entries.Count, Is.EqualTo(1));
            Assert.That(league.Name, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public async Task GetChallengerLeagueAsyncTest()
        {
            IRiotClient client = new RiotClient();
            var league = await client.GetChallengerLeagueAsync(RankedQueue.RANKED_SOLO_5x5);

            Assert.That(league, Is.Not.Null);
            Assert.That(league.Entries.Count, Is.GreaterThan(1));
            Assert.That(league.Name, Is.Not.Null.And.Not.Empty);
            Assert.That(league.Queue, Is.EqualTo(RankedQueue.RANKED_SOLO_5x5));
            Assert.That(league.Tier, Is.EqualTo(Tier.CHALLENGER));
        }

        [Test]
        public async Task GetMasterLeagueAsyncTest()
        {
            IRiotClient client = new RiotClient();
            var league = await client.GetMasterLeagueAsync(RankedQueue.RANKED_SOLO_5x5);

            Assert.That(league, Is.Not.Null);
            Assert.That(league.Entries.Count, Is.GreaterThan(1));
            Assert.That(league.Name, Is.Not.Null.And.Not.Empty);
            Assert.That(league.Queue, Is.EqualTo(RankedQueue.RANKED_SOLO_5x5));
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
