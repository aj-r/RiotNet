using NUnit.Framework;
using RiotNet.Models;
using System.Threading.Tasks;

namespace RiotNet.Tests
{
    [TestFixture]
    public class SummonerTests : TestBase
    {
        [Test]
        public async Task GetSummonerByAccountIdAsyncTest()
        {
            IRiotClient client = new RiotClient();
            Summoner summoner = await client.GetSummonerByAccountIdAsync(34172230L);

            AssertNonDefaultValuesRecursive(summoner);
        }

        [Test]
        public async Task GetSummonerBySummonerIdAsyncTest()
        {
            IRiotClient client = new RiotClient();
            Summoner summoner = await client.GetSummonerBySummonerIdAsync(34172230L);

            AssertNonDefaultValuesRecursive(summoner);
        }

        [Test]
        public async Task GetSummonerBySummonerNameAsyncTest()
        {
            IRiotClient client = new RiotClient();
            Summoner summoner = await client.GetSummonerBySummonerNameAsync("KirkBerkley");

            AssertNonDefaultValuesRecursive(summoner);
        }
    }
}
