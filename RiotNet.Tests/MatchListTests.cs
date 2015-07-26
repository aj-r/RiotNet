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
        public async Task GetMatchListTaskAsyncTest()
        {
            IRiotClient client = new RiotClient();
            var matches = await client.GetMatchListTaskAsync(35870943L, beginIndex: 1, endIndex: 3);

            Assert.That(matches, Is.Not.Null);
            Assert.That(matches.Matches, Is.Not.Null.And.Not.Empty);
            var match = matches.Matches.First();
            Assert.That(match.MatchId, Is.GreaterThan(0));
            Assert.That(match.PlatformId, Is.EqualTo(client.PlatformId));

            Assert.That(matches.StartIndex, Is.EqualTo(1));
            Assert.That(matches.EndIndex, Is.EqualTo(3));
            Assert.That(matches.TotalGames, Is.GreaterThan(0));
        }

        [Test]
        public void DeserializeMatchReferenceTest()
        {
            var matchRef = JsonConvert.DeserializeObject<MatchReference>(Resources.SampleMatchReference, RiotClient.JsonSettings);

            AssertNonDefaultValuesRecursive(matchRef);
        }
    }
}
