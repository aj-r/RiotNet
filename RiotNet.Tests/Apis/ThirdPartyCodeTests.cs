using NUnit.Framework;
using RiotNet.Models;
using System.Threading.Tasks;

namespace RiotNet.Tests
{
    [TestFixture]
    public class ThirdPartyCodeTests : TestBase
    {
        string encryptedSummonerId;

        [OneTimeSetUp]
        public async Task TestOneTimeSetUp()
        {
            SetRiotClientSettings();
            IRiotClient client = new RiotClient();
            var summoner = await client.GetSummonerBySummonerNameAsync("dfernandezramos", PlatformId.EUW1);
            encryptedSummonerId = summoner.Id;
        }

        [Test]
        public async Task GetThirdPartyCodeAsyncTest()
        {
            IRiotClient client = RiotClient.ForPlatform(PlatformId.EUW1);
            string code = await client.GetThirdPartyCodeAsync(encryptedSummonerId);

            Assert.That(code, Is.Not.Null.And.Not.Empty);
        }
    }
}
