using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace RiotNet.Tests
{
    [TestFixture]
    public class StaticDataTests
    {
        [Test]
        public static async Task GetChampionsTest()
        {
            var client = new RiotClient();
            var champions = await client.GetChampionsTaskAsync(champListData: new[] { "all" });

            Assert.That(champions.Data.Count, Is.GreaterThan(0));
        }

        [Test]
        public static async Task GetChampionsTest_IndexedById()
        {
            var client = new RiotClient();
            var champions = await client.GetChampionsTaskAsync(dataById: true, champListData: new[] { "all" });

            Assert.That(champions.Data.Count, Is.GreaterThan(0));
        }
    }
}
