using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace RiotNet.Tests
{
    [TestFixture]
    public class StaticDataTests
    {
        [Test]
        public static async Task GetChampionsAsyncTaskTest()
        {
            var client = new RiotClient();
            var champions = await client.GetChampionsTaskAsync(champListData: new[] { "all" });

            Assert.That(champions.Data.Count, Is.GreaterThan(0));
        }

        [Test]
        public static async Task GetChampionsAsyncTaskTest_IndexedById()
        {
            var client = new RiotClient();
            var champions = await client.GetChampionsTaskAsync(dataById: true, champListData: new[] { "all" });

            Assert.That(champions.Data.Count, Is.GreaterThan(0));

            // The key should be an integer
            var key = champions.Data.Keys.First();
            int id;
            var isInteger = int.TryParse(key, out id);
            Assert.That(isInteger, "Champs are not listed by ID.");
        }

        [Test]
        public static async Task GetChampionByIdAsyncTaskTest()
        {
            var client = new RiotClient();
            var champion = await client.GetChampionByIdTaskAsync(12, champData: new[] { "all" });

            Assert.That(champion, Is.Not.Null);
        }
    }
}
