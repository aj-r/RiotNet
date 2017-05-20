using NUnit.Framework;
using RiotNet.Models;
using System.Threading.Tasks;

namespace RiotNet.Tests.Apis
{
    [TestFixture]
    public class RunesTests : TestBase
    {
        [Test]
        public async Task GetSummonerMasteriesBySummonerIdsAsyncTest()
        {
            IRiotClient client = new RiotClient();
            RunePages runePages = await client.GetRunesBySummonerIdAsync(34172230L);

            AssertNonDefaultValuesRecursive(runePages);
        }
    }
}
