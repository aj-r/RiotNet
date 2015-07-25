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
        public async Task GetMatchTaskAsyncTest()
        {
            IRiotClient client = new RiotClient();
            const long matchId = 1883925941L;
            var match = await client.GetMatchTaskAsync(matchId);

            Assert.That(match, Is.Not.Null);
            Assert.That(match.MatchId, Is.EqualTo(matchId));
            Assert.That(match.Region, Is.EqualTo(client.Region));
            AssertNonDefaultValuesRecursive(match);
        }

        [Test]
        public void DeserializeMatchTest()
        {
            var match = JsonConvert.DeserializeObject<MatchDetail>(Resources.SampleMatch, RiotClient.JsonSettings);

            AssertNonDefaultValuesRecursive(match);
        }
    }
}
