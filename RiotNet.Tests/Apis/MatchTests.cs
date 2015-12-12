using Newtonsoft.Json;
using NUnit.Framework;
using RiotNet.Models;
using RiotNet.Tests.Properties;
using System.Threading.Tasks;

namespace RiotNet.Tests
{
    [TestFixture]
    public class MatchTests : TestBase
    {
        [Test]
        public async Task GetMatchIdsByTournamentCodeAsyncTest()
        {
            IRiotClient client = new RiotClient(Region.NA, TournamentApiKey);
            var matchIds = await client.GetMatchIdsByTournamentCodeAsync("NA0418d-8899c00a-45a9-4898-9b8a-75370a67b9a0");

            Assert.That(matchIds, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public async Task GetMatchForTournamentAsyncTest()
        {
            IRiotClient client = new RiotClient(Region.NA, TournamentApiKey);
            const long matchId = 2035034934L;
            var match = await client.GetMatchForTournamentAsync(matchId, "NA0418d-8899c00a-45a9-4898-9b8a-75370a67b9a0");

            Assert.That(match, Is.Not.Null);
            Assert.That(match.MatchId, Is.EqualTo(matchId));
            Assert.That(match.Region, Is.EqualTo(client.Region));
        }

        [Test]
        public async Task GetMatchAsyncTest()
        {
            IRiotClient client = new RiotClient();
            const long matchId = 2032332497L;
            var match = await client.GetMatchAsync(matchId);

            Assert.That(match, Is.Not.Null);
            Assert.That(match.MatchId, Is.EqualTo(matchId));
            Assert.That(match.Region, Is.EqualTo(client.Region));
            Assert.That(match.Timeline, Is.Null);
        }

        [Test]
        public async Task GetMatchAsyncTest_WithTimeline()
        {
            IRiotClient client = new RiotClient();
            const long matchId = 2032332497L;
            var match = await client.GetMatchAsync(matchId, true);

            Assert.That(match, Is.Not.Null);
            Assert.That(match.MatchId, Is.EqualTo(matchId));
            Assert.That(match.Region, Is.EqualTo(client.Region));
            Assert.That(match.Timeline, Is.Not.Null);
            Assert.That(match.Timeline.Frames, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public void DeserializeMatchTest()
        {
            var match = JsonConvert.DeserializeObject<MatchDetail>(Resources.SampleMatch, RiotClient.JsonSettings);

            AssertNonDefaultValuesRecursive(match);
        }
    }
}
