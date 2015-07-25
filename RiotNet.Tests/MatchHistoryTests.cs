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
    public class MatchHistoryTests : TestBase
    {
        [Test]
        public async Task GetMatchHistoryTaskAsyncTest()
        {
            IRiotClient client = new RiotClient();
            var matches = await client.GetMatchHistoryTaskAsync(35870943L);

            Assert.That(matches, Is.Not.Null);
            Assert.That(matches.Matches, Is.Not.Null.And.Not.Empty);
            var match = matches.Matches.First();
            Assert.That(match.MatchId, Is.GreaterThan(0));
            Assert.That(match.Region, Is.EqualTo(client.Region));
        }

        [Test]
        public void DeserializeMatchSummaryTest()
        {
            var matchSummary = JsonConvert.DeserializeObject<MatchSummary>(Resources.SampleMatchSummary, RiotClient.JsonSettings);

            AssertNonDefaultValuesRecursive(matchSummary);
        }
    }
}
