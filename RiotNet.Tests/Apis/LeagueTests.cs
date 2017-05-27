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
        [Test]
        public async Task GetLeaguesBySummonerIdAsyncTest()
        {
            IRiotClient client = new RiotClient();
            List<LeagueList> leagues = await client.GetLeaguesBySummonerIdAsync(35870943L);

            Assert.That(leagues, Is.Not.Null);
            var league = leagues.First();
            Assert.That(league.Entries.Count, Is.GreaterThan(1));
            Assert.That(league.Name, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public async Task GetLeaguePositionsBySummonerIdAsyncTest()
        {
            IRiotClient client = new RiotClient();
            List<LeaguePosition> leaguePositions = await client.GetLeaguePositionsBySummonerIdAsync(35870943L);

            Assert.That(leaguePositions, Is.Not.Null);
            var leaguePosition = leaguePositions.First();
            Assert.That(leaguePosition.LeagueName, Is.Not.Null.And.Not.Empty);
            Assert.That(leaguePosition.Tier, Is.Not.EqualTo(Tier.CHALLENGER));
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
