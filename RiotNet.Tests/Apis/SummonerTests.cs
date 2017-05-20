using NUnit.Framework;
using System.Globalization;
using System.Threading.Tasks;

namespace RiotNet.Tests
{
    [TestFixture]
    public class SummonerTests : TestBase
    {
        [Test]
        public async Task GetSummonersBySummonerIdsAsyncTest()
        {
            IRiotClient client = new RiotClient();
            var summonerIds = new[] { 34172230L, 35870943L };
            var summoners = await client.GetSummonersBySummonerIdsAsync(summonerIds);

            AssertNonDefaultValuesRecursive(summoners);
            foreach (var summonerId in summonerIds)
                Assert.That(summoners.ContainsKey(summonerId.ToString(CultureInfo.InvariantCulture)), "Summoner was not included in results: " + summonerId);
        }

        [Test]
        public async Task GetSummonerBySummonerIdAsyncTest()
        {
            IRiotClient client = new RiotClient();
            var summoner = await client.GetSummonerBySummonerIdAsync(34172230L);

            AssertNonDefaultValuesRecursive(summoner);
        }

        [Test]
        public async Task GetSummonersBySummonerNamesAsyncTest()
        {
            IRiotClient client = new RiotClient();
            var summonerNames = new[] { "KirkBerkley", "RndmInternetMan" };
            var summoners = await client.GetSummonersBySummonerNamesAsync(summonerNames);

            AssertNonDefaultValuesRecursive(summoners);
            foreach (var summonerName in summonerNames)
                Assert.That(summoners.ContainsKey(summonerName), "Summoner was not included in results: " + summonerName);
        }

        [Test]
        public async Task GetSummonerBySummonerNameAsyncTest()
        {
            IRiotClient client = new RiotClient();
            var summoner = await client.GetSummonerBySummonerNameAsync("KirkBerkley");

            AssertNonDefaultValuesRecursive(summoner);
        }

        [Test]
        public async Task GetSummonerNamesBySummonerIdsAsyncTest()
        {
            IRiotClient client = new RiotClient();
            var summonerIds = new[] { 34172230L, 35870943L };
            var names = await client.GetSummonerNamesBySummonerIdsAsync(summonerIds);

            AssertNonDefaultValuesRecursive(names);
            foreach (var summonerId in summonerIds)
                Assert.That(names.ContainsKey(summonerId.ToString(CultureInfo.InvariantCulture)), "Summoner was not included in results: " + summonerId);
        }
    }
}
