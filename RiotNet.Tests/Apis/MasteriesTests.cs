using NUnit.Framework;
using RiotNet.Models;
using System.Threading.Tasks;

namespace RiotNet.Tests.Apis
{
    [TestFixture]
    public class MasteriesTests : TestBase
    {
        [Test]
        public async Task GetMasteriesBySummonerIdAsyncTest()
        {
            IRiotClient client = new RiotClient();
            MasteryPages masteryPages = await client.GetMasteriesBySummonerIdAsync(34172230L);

            AssertNonDefaultValuesRecursive(masteryPages);
        }
    }
}
