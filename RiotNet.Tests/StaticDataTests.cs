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
            var championList = await client.GetChampionsTaskAsync(champListData: new[] { "all" });

            Assert.That(championList.Keys.Count, Is.GreaterThan(0));
            Assert.That(championList.Data.Count, Is.GreaterThan(0));

            var champion = championList.Data["Aatrox"];
            Assert.That(champion.Tags, Contains.Item("Fighter"));
            Assert.That(champion.Stats, Is.Not.Null);
            Assert.That(champion.Stats.AttackDamage, Is.GreaterThan(0));
        }

        [Test]
        public static async Task GetChampionsAsyncTaskTest_IndexedById()
        {
            var client = new RiotClient();
            var championList = await client.GetChampionsTaskAsync(dataById: true, champListData: new[] { "all" });

            Assert.That(championList.Data.Count, Is.GreaterThan(0));

            // The key should be an integer
            var key = championList.Data.Keys.First();
            int id;
            var isInteger = int.TryParse(key, out id);
            Assert.That(isInteger, "Champs are not listed by ID.");
        }

        [Test]
        public static async Task GetChampionByIdAsyncTaskTest()
        {
            var client = new RiotClient();
            // 154 = Zac
            var champion = await client.GetChampionByIdTaskAsync(154, champData: new[] { "all" });

            Assert.That(champion, Is.Not.Null);
            Assert.That(champion.Tags, Contains.Item("Tank"));
            Assert.That(champion.Stats, Is.Not.Null);
            Assert.That(champion.Stats.Armor, Is.GreaterThan(0));
            Assert.That(champion.Stats.ArmorPerLevel, Is.GreaterThan(0));
            Assert.That(champion.Stats.AttackDamage, Is.GreaterThan(0));
            Assert.That(champion.Stats.AttackDamagePerLevel, Is.GreaterThan(0));
            Assert.That(champion.Stats.AttackRange, Is.GreaterThan(0));
            Assert.That(champion.Stats.AttackSpeedPerLevel, Is.GreaterThan(0));
            Assert.That(champion.Stats.SpellBlock, Is.GreaterThan(0));
            Assert.That(champion.Stats.SpellBlockPerLevel, Is.GreaterThan(0));
            Assert.That(champion.Stats.HP, Is.GreaterThan(0));
            Assert.That(champion.Stats.HPPerLevel, Is.GreaterThan(0));
            Assert.That(champion.Stats.HPRegen, Is.GreaterThan(0));
            Assert.That(champion.Stats.HPRegenPerLevel, Is.GreaterThan(0));
            Assert.That(champion.Stats.MoveSpeed, Is.GreaterThan(0));
        }
    }
}
