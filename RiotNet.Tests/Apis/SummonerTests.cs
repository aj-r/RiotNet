using NUnit.Framework;
using RiotNet.Models;
using System.Threading.Tasks;

namespace RiotNet.Tests
{
    [TestFixture]
    public class SummonerTests : TestBase
    {
        string encryptedSummonerId;
        string encryptedAccountId;

        [OneTimeSetUp]
        public async Task TestOneTimeSetUp()
        {
            SetRiotClientSettings();
            IRiotClient client = new RiotClient();
            var summoner = await client.GetSummonerBySummonerNameAsync("KirkBerkley");
            encryptedSummonerId = summoner.Id;
            encryptedAccountId = summoner.AccountId;
        }

        [Test]
        public async Task GetSummonerByAccountIdAsyncTest()
        {
            IRiotClient client = new RiotClient();
            Summoner summoner = await client.GetSummonerByAccountIdAsync(encryptedAccountId);

            AssertNonDefaultValuesRecursive(summoner);
        }

        [Test]
        public async Task GetSummonerBySummonerIdAsyncTest()
        {
            IRiotClient client = new RiotClient();
            Summoner summoner = await client.GetSummonerBySummonerIdAsync(encryptedSummonerId);

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
