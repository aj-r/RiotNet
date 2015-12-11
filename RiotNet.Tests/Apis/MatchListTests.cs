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
    public class MatchListTests : TestBase
    {
        [Test]
        public async Task GetMatchListAsyncTest()
        {
            IRiotClient client = new RiotClient();
            var matchList = await client.GetMatchListAsync(35870943L, beginIndex: 1, endIndex: 3);

            Assert.That(matchList, Is.Not.Null);
            Assert.That(matchList.Matches, Is.Not.Null.And.Not.Empty);
            var match = matchList.Matches.First();
            Assert.That(match.MatchId, Is.GreaterThan(0));
            Assert.That(match.PlatformId, Is.EqualTo(client.PlatformId));

            Assert.That(matchList.StartIndex, Is.EqualTo(1));
            Assert.That(matchList.EndIndex, Is.EqualTo(3));
            Assert.That(matchList.TotalGames, Is.GreaterThan(0));
        }

        [Test]
        public async Task GetMatchListAsyncTest_WithFilters()
        {
            IRiotClient client = new RiotClient();
            var championIds = new[] { 113L, 154L }; // Sejuani, Zac
            var rankedQueues = new[] { RankedQueue.RANKED_TEAM_3x3, RankedQueue.RANKED_TEAM_5x5 };
            var seasons = new[] { Season.PRESEASON2015, Season.SEASON2015 };
            var matchList = await client.GetMatchListAsync(35870943L, championIds, rankedQueues, seasons);

            Assert.That(matchList, Is.Not.Null);
            Assert.That(matchList.Matches, Is.Not.Null.And.Not.Empty);
            Assert.That(matchList.Matches.All(m => championIds.Contains(m.Champion)));
            Assert.That(matchList.Matches.All(m => rankedQueues.Contains(m.Queue)));
            Assert.That(matchList.Matches.All(m => seasons.Contains(m.Season)));
        }

        [Test]
        public async Task GetMatchListAsyncTest_WithDateFilters()
        {
            // Note: this test currently fails, but it appears to be a bug in Riot's API.
            IRiotClient client = new RiotClient();
            var beginTime = new DateTime(2015, 6, 1, 0, 0, 0, DateTimeKind.Utc);
            var endTime = new DateTime(2015, 7, 1, 0, 0, 0, DateTimeKind.Utc);
            var matchList = await client.GetMatchListAsync(35870943L, beginTime: beginTime, endTime: endTime);

            Assert.That(matchList, Is.Not.Null);
            Assert.That(matchList.Matches, Is.Not.Null.And.Not.Empty);
            for (var i = 0; i < matchList.Matches.Count; ++i)
            {
                Assert.That(matchList.Matches[i].Timestamp, Is.GreaterThanOrEqualTo(beginTime), "Match " + i + " was before the begin time.");
                Assert.That(matchList.Matches[i].Timestamp, Is.LessThanOrEqualTo(endTime), "Match " + i + " was after the end time.");
            }
        }

        [Test]
        public void DeserializeMatchReferenceTest()
        {
            var matchRef = JsonConvert.DeserializeObject<MatchReference>(Resources.SampleMatchReference, RiotClient.JsonSettings);

            AssertNonDefaultValuesRecursive(matchRef);
        }
    }
}
