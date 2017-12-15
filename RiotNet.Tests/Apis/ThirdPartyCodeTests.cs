using NUnit.Framework;
using RiotNet.Models;
using System.Threading.Tasks;

namespace RiotNet.Tests
{
    [TestFixture]
    public class ThirdPartyCodeTests : TestBase
    {
        [Test]
        public async Task GetThirdPartyCodeAsyncTest()
        {
            IRiotClient client = RiotClient.ForPlatform(PlatformId.NA1);
            string code = await client.GetThirdPartyCodeAsync(34172230);

            Assert.That(code, Is.Not.Null.And.Not.Empty);
        }
    }
}
