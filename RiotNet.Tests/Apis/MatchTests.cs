using Newtonsoft.Json;
using NUnit.Framework;
using RiotNet.Models;
using RiotNet.Tests.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            Match match = await client.GetMatchAsync(matchId);

            Assert.That(match, Is.Not.Null);
            Assert.That(match.GameId, Is.EqualTo(matchId));
            Assert.That(match.PlatformId, Is.EqualTo(client.PlatformId));
        }

        [Test]
        public async Task GetMatchTimelineAsyncTest()
        {
            IRiotClient client = new RiotClient();
            const long matchId = 2032332497L;
            MatchTimeline timeline = await client.GetMatchTimelineAsync(matchId);

            Assert.That(timeline, Is.Not.Null);
            Assert.That(timeline.Frames, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public async Task GetMatchListByAccountIdAsyncTest()
        {
            IRiotClient client = new RiotClient();
            MatchList matchList = await client.GetMatchListByAccountIdAsync(48555045L, beginIndex: 1, endIndex: 3);

            Assert.That(matchList, Is.Not.Null);
            Assert.That(matchList.Matches, Is.Not.Null.And.Not.Empty);
            var match = matchList.Matches.First();
            Assert.That(match.GameId, Is.GreaterThan(0));
            Assert.That(match.PlatformId, Is.EqualTo(client.PlatformId));

            Assert.That(matchList.StartIndex, Is.EqualTo(1));
            Assert.That(matchList.EndIndex, Is.EqualTo(3));
            Assert.That(matchList.TotalGames, Is.GreaterThan(0));
        }

        [Test]
        public async Task GetMatchListByAccountIdAsyncTest_WithFilters()
        {
            IRiotClient client = new RiotClient();
            IEnumerable<long> championIds = new[] { 113L, 154L }; // Sejuani, Zac
            IEnumerable<QueueType> rankedQueues = new[] { QueueType.RANKED_FLEX_SR, QueueType.RANKED_SOLO_5x5 };
            IEnumerable<Season> seasons = new[] { Season.PRESEASON2015, Season.SEASON2015 };
            MatchList matchList = await client.GetMatchListByAccountIdAsync(48555045L, championIds, rankedQueues, seasons);

            Assert.That(matchList, Is.Not.Null);
            Assert.That(matchList.Matches, Is.Not.Null.And.Not.Empty);
            Assert.That(matchList.Matches.All(m => championIds.Contains(m.Champion)));
            Assert.That(matchList.Matches.All(m => rankedQueues.Contains(m.Queue)));
            Assert.That(matchList.Matches.All(m => seasons.Contains(m.Season)));
        }

        [Test]
        public async Task GetMatchListByAccountIdAsyncTest_WithDateFilters()
        {
            // Note: this test currently fails, but it appears to be a bug in Riot's API.
            IRiotClient client = new RiotClient();
            var beginTime = new DateTime(2015, 6, 1, 0, 0, 0, DateTimeKind.Utc);
            var endTime = new DateTime(2015, 7, 1, 0, 0, 0, DateTimeKind.Utc);
            var matchList = await client.GetMatchListByAccountIdAsync(48555045L, beginTime: beginTime, endTime: endTime);

            Assert.That(matchList, Is.Not.Null);
            Assert.That(matchList.Matches, Is.Not.Null.And.Not.Empty);
            for (var i = 0; i < matchList.Matches.Count; ++i)
            {
                Assert.That(matchList.Matches[i].Timestamp, Is.GreaterThanOrEqualTo(beginTime), $"Match {i} was before the begin time.");
                Assert.That(matchList.Matches[i].Timestamp, Is.LessThanOrEqualTo(endTime), $"Match {i} was after the end time.");
            }
        }

        [Test]
        [Ignore("This test uses the Tournament API. You need a special tournament key to run this test.")]
        public async Task GetMatchIdsByTournamentCodeAsyncTest()
        {
            IRiotClient client = new RiotClient(TournamentApiKey);
            var matchIds = await client.GetMatchIdsByTournamentCodeAsync("NA0418d-8899c00a-45a9-4898-9b8a-75370a67b9a0", PlatformId.NA1);

            Assert.That(matchIds, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        [Ignore("This test uses the Tournament API. You need a special tournament key to run this test.")]
        public async Task GetMatchForTournamentAsyncTest()
        {
            IRiotClient client = new RiotClient(TournamentApiKey);
            const long matchId = 2035034934L;
            var match = await client.GetMatchForTournamentAsync(matchId, "NA0418d-8899c00a-45a9-4898-9b8a-75370a67b9a0", PlatformId.NA1);

            Assert.That(match, Is.Not.Null);
            Assert.That(match.GameId, Is.EqualTo(matchId));
            Assert.That(match.PlatformId, Is.EqualTo(client.PlatformId));
        }

        [Test]
        public void DeserializeMatchTest()
        {
            var match = JsonConvert.DeserializeObject<Match>(Resources.SampleMatch, RiotClient.JsonSettings);

            AssertNonDefaultValuesRecursive(match);
        }

        [Test]
        public void DeserializeMatchTimelineTest()
        {
            var match = JsonConvert.DeserializeObject<MatchTimeline>(Resources.SampleMatchTimeline, RiotClient.JsonSettings);

            AssertNonDefaultValuesRecursive(match);
        }

        [Test]
        public void DeserializeMatchReferenceTest()
        {
            var matchRef = JsonConvert.DeserializeObject<MatchReference>(Resources.SampleMatchReference, RiotClient.JsonSettings);

            AssertNonDefaultValuesRecursive(matchRef);
        }
    }
}
