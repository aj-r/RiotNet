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
            // TODO: create a match to test this
            IRiotClient client = new RiotClient();
            var matchIds = await client.GetMatchIdsByTournamentCodeAsync("NA0418c-d541d70b-2865-4489-89bd-1d26b72b2edf");

            Assert.That(matchIds, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public async Task GetMatchForTournamentAsyncTest()
        {
            // TODO: create a match to test this
            IRiotClient client = new RiotClient();
            const long matchId = 2032332497L;
            var match = await client.GetMatchForTournamentAsync(matchId, "NA0418c-d541d70b-2865-4489-89bd-1d26b72b2edf");

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
