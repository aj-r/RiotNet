using System;
using System.Threading.Tasks;
using NUnit.Framework;
using RiotNet.Models;

namespace RiotNet.Tests
{
    [TestFixture]
    public class LeagueTests : TestBase
    {
        [Test]
        public async Task GetMasterLeagueTest()
        {
            var client = new RiotClient();
            var league = await client.GetMasterLeagueTaskAsync(RankedQueue.RANKED_TEAM_3x3);

            Assert.That(league.Entries.Count, Is.GreaterThan(0));
            Assert.That(league.Name, Is.Not.Null.And.Not.Empty);
            Assert.That(league.Queue, Is.EqualTo(RankedQueue.RANKED_TEAM_3x3));
            Assert.That(league.Tier, Is.EqualTo(Tier.MASTER));
        }
    }
}
