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
        #region Champion

        [Test]
        public async Task GetChampionsAsyncTaskTest()
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
        public async Task GetChampionsAsyncTaskTest_IndexedById()
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
        public async Task GetChampionByIdAsyncTaskTest()
        {
            var client = new RiotClient();
            // 43 = Karma
            var champion = await client.GetChampionByIdTaskAsync(43, champData: new[] { "all" });

            Assert.That(champion, Is.Not.Null);
            Assert.That(champion.AllyTips, Is.Not.Null.And.Not.Empty);
            Assert.That(champion.Blurb, Is.Not.Null.And.Not.Empty);
            Assert.That(champion.EnemyTips, Is.Not.Null.And.Not.Empty);
            Assert.That(champion.Key, Is.Not.Null.And.Not.Empty);
            Assert.That(champion.Lore, Is.Not.Null.And.Not.Empty);
            Assert.That(champion.Name, Is.Not.Null.And.Not.Empty);
            Assert.That(champion.ParType, Is.Not.Null.And.Not.Empty);
            Assert.That(champion.Tags, Is.Not.Null.And.Not.Empty);
            Assert.That(champion.Title, Is.Not.Null.And.Not.Empty);

            Assert.That(champion.Image, Is.Not.Null);
            Assert.That(champion.Image.Full, Is.Not.Null.And.Not.Empty);
            Assert.That(champion.Image.Group, Is.Not.Null.And.Not.Empty);
            Assert.That(champion.Image.Sprite, Is.Not.Null.And.Not.Empty);
            Assert.That(champion.Image.W, Is.GreaterThan(0));
            Assert.That(champion.Image.H, Is.GreaterThan(0));

            Assert.That(champion.Info, Is.Not.Null);
            Assert.That(champion.Info.Attack, Is.GreaterThan(0));
            Assert.That(champion.Info.Defense, Is.GreaterThan(0));
            Assert.That(champion.Info.Difficulty, Is.GreaterThan(0));
            Assert.That(champion.Info.Magic, Is.GreaterThan(0));

            Assert.That(champion.Passive, Is.Not.Null);
            Assert.That(champion.Passive.Description, Is.Not.Null.And.Not.Empty);
            Assert.That(champion.Passive.Image, Is.Not.Null);
            Assert.That(champion.Passive.Name, Is.Not.Null.And.Not.Empty);
            Assert.That(champion.Passive.SanitizedDescription, Is.Not.Null.And.Not.Empty);

            Assert.That(champion.Recommended, Is.Not.Null.And.Not.Empty);
            var recommendedItemSet = champion.Recommended.First();
            Assert.That(recommendedItemSet.Blocks, Is.Not.Null.And.Not.Empty);
            Assert.That(recommendedItemSet.Champion, Is.Not.Null.And.Not.Empty);
            Assert.That(recommendedItemSet.Map, Is.Not.Null.And.Not.Empty);
            Assert.That(recommendedItemSet.Mode, Is.Not.Null.And.Not.Empty);
            Assert.That(recommendedItemSet.Title, Is.Not.Null.And.Not.Empty);
            Assert.That(recommendedItemSet.Type, Is.Not.Null.And.Not.Empty);
            var block = recommendedItemSet.Blocks.First();
            Assert.That(block.Type, Is.Not.Null.And.Not.Empty);
            Assert.That(block.Items, Is.Not.Null.And.Not.Empty);
            var item = block.Items.First();
            Assert.That(item.ItemId, Is.GreaterThan(0));
            Assert.That(item.Count, Is.GreaterThan(0));

            Assert.That(champion.Skins, Is.Not.Null.And.Not.Empty);
            var skin = champion.Skins.Last(); // Use last so skin.Num != 0
            Assert.That(skin.Id, Is.GreaterThan(0));
            Assert.That(skin.Name, Is.Not.Null.And.Not.Empty);
            Assert.That(skin.Num, Is.GreaterThan(0));

            Assert.That(champion.Spells, Is.Not.Null.And.Not.Empty);
            var spell = champion.Spells.First();
            Assert.That(spell.AltImages, Is.Not.Null.And.Not.Empty);
            Assert.That(spell.Cooldown, Is.Not.Null.And.Not.Empty);
            foreach (var cooldown in spell.Cooldown)
                Assert.That(cooldown, Is.GreaterThan(0));
            Assert.That(spell.CooldownBurn, Is.Not.Null.And.Not.Empty);
            Assert.That(spell.Cost, Is.Not.Null.And.Not.Empty);
            foreach (var cost in spell.Cost)
                Assert.That(cost, Is.GreaterThan(0));
            Assert.That(spell.CostBurn, Is.Not.Null.And.Not.Empty);
            Assert.That(spell.CostType, Is.Not.Null.And.Not.Empty);
            Assert.That(spell.Description, Is.Not.Null.And.Not.Empty);
            Assert.That(spell.Effect, Is.Not.Null.And.Not.Empty);
            Assert.That(spell.EffectBurn, Is.Not.Null.And.Not.Empty);
            Assert.That(spell.Image, Is.Not.Null);
            Assert.That(spell.Key, Is.Not.Null.And.Not.Empty);
            Assert.That(spell.LevelTip, Is.Not.Null);
            Assert.That(spell.LevelTip.Effect, Is.Not.Null.And.Not.Empty);
            foreach (var effect in spell.LevelTip.Effect)
                Assert.That(effect, Is.Not.Null.And.Not.Empty);
            Assert.That(spell.LevelTip.Label, Is.Not.Null.And.Not.Empty);
            foreach (var label in spell.LevelTip.Label)
                Assert.That(label, Is.Not.Null.And.Not.Empty);
            Assert.That(spell.MaxRank, Is.GreaterThan(0));
            Assert.That(spell.Name, Is.Not.Null.And.Not.Empty);
            Assert.That(spell.Range, Is.Not.Null.And.Not.Empty);
            Assert.That(spell.RangeBurn, Is.Not.Null.And.Not.Empty);
            Assert.That(spell.Resource, Is.Not.Null.And.Not.Empty);
            Assert.That(spell.SanitizedDescription, Is.Not.Null.And.Not.Empty);
            Assert.That(spell.SanitizedTooltip, Is.Not.Null.And.Not.Empty);
            Assert.That(spell.Tooltip, Is.Not.Null.And.Not.Empty);
            Assert.That(spell.Vars, Is.Not.Null);
            var spellVar = spell.Vars.First();
            Assert.That(spellVar.Coeff, Is.Not.Null.And.Not.Empty);
            Assert.That(spellVar.Key, Is.Not.Null.And.Not.Empty);
            Assert.That(spellVar.Link, Is.Not.Null.And.Not.Empty);

            Assert.That(champion.Stats, Is.Not.Null);
            Assert.That(champion.Stats.Armor, Is.GreaterThan(0));
            Assert.That(champion.Stats.ArmorPerLevel, Is.GreaterThan(0));
            Assert.That(champion.Stats.AttackDamage, Is.GreaterThan(0));
            Assert.That(champion.Stats.AttackDamagePerLevel, Is.GreaterThan(0));
            Assert.That(champion.Stats.AttackRange, Is.GreaterThan(0));
            Assert.That(champion.Stats.AttackSpeedPerLevel, Is.GreaterThan(0));
            Assert.That(champion.Stats.SpellBlock, Is.GreaterThan(0));
            Assert.That(champion.Stats.HP, Is.GreaterThan(0));
            Assert.That(champion.Stats.HPPerLevel, Is.GreaterThan(0));
            Assert.That(champion.Stats.HPRegen, Is.GreaterThan(0));
            Assert.That(champion.Stats.HPRegenPerLevel, Is.GreaterThan(0));
            Assert.That(champion.Stats.MoveSpeed, Is.GreaterThan(0));
        }

        #endregion
    }
}
