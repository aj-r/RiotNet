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
    public class MatchTests : TestBase
    {
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
