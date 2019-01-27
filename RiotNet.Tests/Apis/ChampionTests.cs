using Newtonsoft.Json;
using NUnit.Framework;
using RiotNet.Models;
using RiotNet.Tests.Properties;
using System.Threading.Tasks;

namespace RiotNet.Tests
{
    [TestFixture]
    public class ChampionTests : TestBase
    {
        [Test]
        [Ignore("This API is depreciated")]
        public async Task GetChampionsAsyncTest()
        {
            IRiotClient client = new RiotClient();
            var champions = await client.GetChampionsAsync();

            Assert.That(champions, Is.Not.Null);
            Assert.That(champions.Count, Is.GreaterThan(100));
        }

        [Test]
        [Ignore("This API is depreciated")]
        public async Task GetChampionsAsyncTest_FreeToPlay()
        {
            IRiotClient client = new RiotClient();
            var champions = await client.GetChampionsAsync(true);

            Assert.That(champions, Is.Not.Null);
            Assert.That(champions.Count, Is.LessThan(25));
        }

        [Test]
        [Ignore("This API is depreciated")]
        public async Task GetChampionByIdAsyncTest()
        {
            IRiotClient client = new RiotClient();
            var champion = await client.GetChampionByIdAsync(103);

            Assert.That(champion, Is.Not.Null);
            Assert.That(champion.Id, Is.EqualTo(103));
        }

        [Test]
        public void DeserializeChampionTest()
        {
            var champion = JsonConvert.DeserializeObject<Champion>(Resources.SampleChampion, RiotClient.JsonSettings);

            AssertNonDefaultValuesRecursive(champion);
        }
    }
}
