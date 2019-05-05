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
        string encryptedAccountId;

        [OneTimeSetUp]
        public async Task TestOneTimeSetUp()
        {
            SetRiotClientSettings();
            IRiotClient client = new RiotClient();
            var summoner = await client.GetSummonerBySummonerNameAsync("LuckySkillz");
            encryptedAccountId = summoner.AccountId;
        }

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
            const long matchId = 2488397591L;
            MatchTimeline timeline = await client.GetMatchTimelineAsync(matchId);

            Assert.That(timeline, Is.Not.Null);
            Assert.That(timeline.Frames, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public async Task GetMatchListByAccountIdAsyncTest()
        {
            IRiotClient client = new RiotClient();
            MatchList matchList = await client.GetMatchListByAccountIdAsync(encryptedAccountId, beginIndex: 1, endIndex: 3);

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
            IEnumerable<long> championIds = new[] { 19L, 107L }; // Warwick, Rengar
            IEnumerable<QueueType> rankedQueues = new[] { QueueType.TEAM_BUILDER_DRAFT_UNRANKED_5x5, QueueType.TEAM_BUILDER_RANKED_SOLO };
            IEnumerable<Season> seasons = new[] { Season.PRESEASON2019, Season.SEASON2019 };
            MatchList matchList = await client.GetMatchListByAccountIdAsync(encryptedAccountId, championIds, rankedQueues, seasons);

            Assert.That(matchList, Is.Not.Null);
            Assert.That(matchList.Matches, Is.Not.Null.And.Not.Empty);
            Assert.That(matchList.Matches.All(m => championIds.Contains(m.Champion)), "Unexpected Champion ID: " + matchList.Matches.FirstOrDefault(m => !championIds.Contains(m.Champion))?.Champion);
            Assert.That(matchList.Matches.All(m => rankedQueues.Contains(m.Queue)), "Unexpected Queue ID: " + matchList.Matches.FirstOrDefault(m => !rankedQueues.Contains(m.Queue))?.Queue);
            Assert.That(matchList.Matches.All(m => seasons.Contains(m.Season)), "Unexpected Season ID: " + matchList.Matches.FirstOrDefault(m => !seasons.Contains(m.Season))?.Season);

            foreach(var id in championIds)
                Assert.That(matchList.Matches.Any(m => m.Champion == id), "Champion ID not found: " + id);
            foreach (var id in rankedQueues)
                Assert.That(matchList.Matches.Any(m => m.Queue == id), "Queue ID not found: " + id);
        }

        [Test]
        public async Task GetMatchListByAccountIdAsyncTest_WithDateFilters()
        {
            IRiotClient client = new RiotClient();
            var beginTime = new DateTime(2018, 12, 1, 0, 0, 0, DateTimeKind.Utc);
            var endTime = new DateTime(2018, 12, 3, 0, 0, 0, DateTimeKind.Utc);
            var matchList = await client.GetMatchListByAccountIdAsync(encryptedAccountId, beginTime: beginTime, endTime: endTime);

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
            Assert.That(match.Teams.Any(t => t.Win), "No team won!");
            Assert.That(match.Teams.Any(t => !t.Win), "No team lost!");
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
