using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using RiotNet.Models;

namespace RiotNet.Tests
{
    [TestFixture]
    public class StaticDataTests
    {
        #region Versions

        [Test]
        public async Task GetVersionsAsyncTaskTest()
        {
            var client = new RiotClient();
            var versions = await client.GetVersionsTaskAsync();

            Assert.That(versions, Is.Not.Null.And.Not.Empty);
        }

        #endregion

        #region Champions

        [Test]
        public async Task GetChampionsAsyncTaskTest()
        {
            var client = new RiotClient();
            var championList = await client.GetStaticChampionsTaskAsync(champListData: new[] { "all" });

            Assert.That(championList.Data.Count, Is.GreaterThan(0));
            Assert.That(championList.Format, Is.Not.Null.And.Not.Empty);
            Assert.That(championList.Keys.Count, Is.GreaterThan(0));
            Assert.That(championList.Type, Is.Not.Null.And.Not.Empty);
            Assert.That(championList.Version, Is.Not.Null.And.Not.Empty);

            var champion = championList.Data["Aatrox"];
            Assert.That(champion.Stats, Is.Not.Null);
            Assert.That(champion.Stats.AttackDamage, Is.GreaterThan(0));
            Assert.That(champion.Tags, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public async Task GetChampionsAsyncTaskTest_IndexedById()
        {
            var client = new RiotClient();
            var championList = await client.GetStaticChampionsTaskAsync(dataById: true, champListData: new[] { "all" });

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
            var champion = await client.GetStaticChampionByIdTaskAsync(43, champData: new[] { "all" });

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
            Assert.That(item.Id, Is.GreaterThan(0));
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

        #region Items

        [Test]
        public async Task GetItemsAsyncTaskTest()
        {
            var client = new RiotClient();
            var itemList = await client.GetItemsTaskAsync(itemListData: new[] { "all" });

            Assert.That(itemList.Basic, Is.Not.Null);
            Assert.That(itemList.Data.Count, Is.GreaterThan(0));
            Assert.That(itemList.Groups, Is.Not.Null.And.Not.Empty);
            var group = itemList.Groups.First();
            Assert.That(group.Key, Is.Not.Null.And.Not.Empty);
            Assert.That(itemList.Groups.Any(g =>
            {
                int n;
                return int.TryParse(g.MaxGroupOwnable, out n) && n > 1;
            }));
            Assert.That(itemList.Tree, Is.Not.Null.And.Not.Empty);
            var treeItem = itemList.Tree.First();
            Assert.That(treeItem.Header, Is.Not.Null.And.Not.Empty);
            Assert.That(treeItem.Tags, Is.Not.Null.And.Not.Empty);
            Assert.That(itemList.Type, Is.Not.Null.And.Not.Empty);
            Assert.That(itemList.Version, Is.Not.Null.And.Not.Empty);

            Assert.That(itemList.Data.Values.Any(i => !string.IsNullOrEmpty(i.Colloq)));
            Assert.That(itemList.Data.Values.Any(i => i.ConsumeOnFull));
            Assert.That(itemList.Data.Values.Any(i => i.Effect != null && i.Effect.Count > 0));
            Assert.That(itemList.Data.Values.Any(i => !string.IsNullOrEmpty(i.Group)));
            Assert.That(itemList.Data.Values.Any(i => i.HideFromAll));
            Assert.That(itemList.Data.Values.Any(i => !i.InStore));
            Assert.That(itemList.Data.Values.Any(i => i.Maps.Values.Any(m => m == false)));
            Assert.That(itemList.Data.Values.Any(i => !string.IsNullOrEmpty(i.RequiredChampion)));
            Assert.That(itemList.Data.Values.Any(i => i.SpecialRecipe > 0));
            Assert.That(itemList.Data.Values.Any(i => i.Stats.FlatArmorMod > 0));
            Assert.That(itemList.Data.Values.Any(i => i.Stats.FlatCritChanceMod > 0));
            Assert.That(itemList.Data.Values.Any(i => i.Stats.FlatHPPoolMod > 0));
            Assert.That(itemList.Data.Values.Any(i => i.Stats.FlatHPRegenMod > 0));
            Assert.That(itemList.Data.Values.Any(i => i.Stats.FlatMagicDamageMod > 0));
            Assert.That(itemList.Data.Values.Any(i => i.Stats.FlatMovementSpeedMod > 0));
            Assert.That(itemList.Data.Values.Any(i => i.Stats.FlatMPPoolMod > 0));
            Assert.That(itemList.Data.Values.Any(i => i.Stats.FlatMPRegenMod > 0));
            Assert.That(itemList.Data.Values.Any(i => i.Stats.FlatPhysicalDamageMod > 0));
            Assert.That(itemList.Data.Values.Any(i => i.Stats.FlatSpellBlockMod > 0));
            Assert.That(itemList.Data.Values.Any(i => i.Stats.PercentAttackSpeedMod > 0));
            Assert.That(itemList.Data.Values.Any(i => i.Stats.PercentLifeStealMod > 0));
            Assert.That(itemList.Data.Values.All(i => i.Gold != null));
        }

        [Test]
        public async Task GetItemByIdAsyncTaskTest()
        {
            var client = new RiotClient();

            // 3086 = Zeal
            var item = await client.GetItemByIdTaskAsync(3086, itemData: new[] { "all" });
            Assert.That(item, Is.Not.Null);
            Assert.That(item.Colloq, Is.EqualTo(string.Empty));
            Assert.That(item.ConsumeOnFull, Is.False);
            Assert.That(item.Consumed, Is.False);
            Assert.That(item.Depth, Is.GreaterThan(1));
            Assert.That(item.Description, Is.Not.Null.And.Not.Empty);
            Assert.That(item.From, Is.Not.Null.And.Not.Empty);
            Assert.That(item.Gold, Is.Not.Null);
            Assert.That(item.Gold.Base, Is.GreaterThan(0));
            Assert.That(item.Gold.Purchasable);
            Assert.That(item.Gold.Sell, Is.GreaterThan(0));
            Assert.That(item.Gold.Total, Is.GreaterThan(0));
            Assert.That(item.HideFromAll, Is.False);
            Assert.That(item.Id, Is.GreaterThan(0));
            Assert.That(item.Image, Is.Not.Null);
            Assert.That(item.InStore);
            Assert.That(item.Into, Is.Not.Null.And.Not.Empty);
            Assert.That(item.Maps, Is.Not.Null.And.Not.Empty);
            Assert.That(item.Name, Is.Not.Null.And.Not.Empty);
            Assert.That(item.PlainText, Is.Not.Null.And.Not.Empty);
            Assert.That(item.SanitizedDescription, Is.Not.Null.And.Not.Empty);
            Assert.That(item.Stacks, Is.EqualTo(1));
            Assert.That(item.Stats, Is.Not.Null);
            Assert.That(item.Tags, Is.Not.Null.And.Not.Empty);

            // 2004 = Mana potion
            item = await client.GetItemByIdTaskAsync(2004, itemData: new[] { "all" });
            Assert.That(item.Consumed);
            Assert.That(item.Stacks, Is.GreaterThan(1));
        }

        [Test]
        public async Task ItemDefaultsTest()
        {
            // Test that the hard-coded default values are correct.
            var client = new RiotClient();
            var itemList = await client.GetItemsTaskAsync(itemListData: new[] { "all" });
            var defaultItem = new Item();
            TestHelper.AssertObjectEqualityRecursive(defaultItem, itemList.Basic, true);
        }

        #endregion

        #region Languages

        [Test]
        public async Task GetLanguagesAsyncTaskTest()
        {
            var client = new RiotClient();
            var languages = await client.GetLanguagesTaskAsync();

            Assert.That(languages, Is.Not.Null.And.Not.Empty);
            var language = languages.First();
            Assert.That(language, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public async Task GetLanguageStringsAsyncTaskTest()
        {
            var client = new RiotClient();
            var languageStrings = await client.GetLanguageStringsTaskAsync();

            Assert.That(languageStrings, Is.Not.Null);
            Assert.That(languageStrings.Data, Is.Not.Null.And.Not.Empty);
            Assert.That(languageStrings.Type, Is.Not.Null.And.Not.Empty);
            Assert.That(languageStrings.Version, Is.Not.Null.And.Not.Empty);
        }

        #endregion

        #region Map

        [Test]
        public async Task GetMapsAsyncTaskTest()
        {
            var client = new RiotClient();
            var mapList = await client.GetMapsTaskAsync();

            Assert.That(mapList.Data, Is.Not.Null.And.Not.Empty);
            Assert.That(mapList.Type, Is.Not.Null.And.Not.Empty);
            Assert.That(mapList.Version, Is.Not.Null.And.Not.Empty);
            var map = mapList.Data.Values.First();
            Assert.That(map.Image, Is.Not.Null);
            Assert.That(map.MapId, Is.GreaterThan(0));
            Assert.That(map.MapName, Is.Not.Null.And.Not.Empty);
            Assert.That(map.UnpurchasableItemList, Is.Not.Null.And.Not.Empty);
        }

        #endregion

        #region Runes

        [Test]
        public async Task GetRunesAsyncTaskTest()
        {
            var client = new RiotClient();
            var runeList = await client.GetRunesTaskAsync(runeListData: new[] { "all" });

            Assert.That(runeList.Basic, Is.Not.Null);
            Assert.That(runeList.Data.Count, Is.GreaterThan(0));
            Assert.That(runeList.Type, Is.Not.Null.And.Not.Empty);
            Assert.That(runeList.Version, Is.Not.Null.And.Not.Empty);

            // All runes should have one non-zero stat. If a rune has all zero stats, then something is wrong.
            var statlessRune = runeList.Data.Values.FirstOrDefault(r =>
                r.Stats.FlatArmorMod == 0 &&
                r.Stats.FlatArmorModPerLevel == 0 &&
                r.Stats.FlatArmorPenetrationMod == 0 &&
                r.Stats.FlatArmorPenetrationModPerLevel == 0 &&
                r.Stats.FlatAttackSpeedMod == 0 &&
                r.Stats.FlatBlockMod == 0 &&
                r.Stats.FlatCritChanceMod == 0 &&
                r.Stats.FlatCritChanceModPerLevel == 0 &&
                r.Stats.FlatCritDamageMod == 0 &&
                r.Stats.FlatCritDamageModPerLevel == 0 &&
                r.Stats.FlatDodgeMod == 0 &&
                r.Stats.FlatDodgeModPerLevel == 0 &&
                r.Stats.FlatEnergyModPerLevel == 0 &&
                r.Stats.FlatEnergyPoolMod == 0 &&
                r.Stats.FlatEnergyRegenMod == 0 &&
                r.Stats.FlatEnergyRegenModPerLevel == 0 &&
                r.Stats.FlatEXPBonus == 0 &&
                r.Stats.FlatGoldPer10Mod == 0 &&
                r.Stats.FlatHPModPerLevel == 0 &&
                r.Stats.FlatHPPoolMod == 0 &&
                r.Stats.FlatHPRegenMod == 0 &&
                r.Stats.FlatHPRegenModPerLevel == 0 &&
                r.Stats.FlatMagicDamageMod == 0 &&
                r.Stats.FlatMagicDamageModPerLevel == 0 &&
                r.Stats.FlatMagicPenetrationMod == 0 &&
                r.Stats.FlatMagicPenetrationModPerLevel == 0 &&
                r.Stats.FlatMovementSpeedMod == 0 &&
                r.Stats.FlatMovementSpeedModPerLevel == 0 &&
                r.Stats.FlatMPModPerLevel == 0 &&
                r.Stats.FlatMPPoolMod == 0 &&
                r.Stats.FlatMPRegenMod == 0 &&
                r.Stats.FlatMPRegenModPerLevel == 0 &&
                r.Stats.FlatPhysicalDamageMod == 0 &&
                r.Stats.FlatPhysicalDamageModPerLevel == 0 &&
                r.Stats.FlatSpellBlockMod == 0 &&
                r.Stats.FlatSpellBlockModPerLevel == 0 &&
                r.Stats.FlatTimeDeadMod == 0 &&
                r.Stats.FlatTimeDeadModPerLevel == 0 &&
                r.Stats.PercentArmorMod == 0 &&
                r.Stats.PercentArmorPenetrationMod == 0 &&
                r.Stats.PercentArmorPenetrationModPerLevel == 0 &&
                r.Stats.PercentAttackSpeedMod == 0 &&
                r.Stats.PercentAttackSpeedModPerLevel == 0 &&
                r.Stats.PercentBlockMod == 0 &&
                r.Stats.PercentCooldownMod == 0 &&
                r.Stats.PercentCooldownModPerLevel == 0 &&
                r.Stats.PercentCritChanceMod == 0 &&
                r.Stats.PercentCritDamageMod == 0 &&
                r.Stats.PercentDodgeMod == 0 &&
                r.Stats.PercentEXPBonus == 0 &&
                r.Stats.PercentHPPoolMod == 0 &&
                r.Stats.PercentHPRegenMod == 0 &&
                r.Stats.PercentLifeStealMod == 0 &&
                r.Stats.PercentMagicDamageMod == 0 &&
                r.Stats.PercentMagicPenetrationMod == 0 &&
                r.Stats.PercentMagicPenetrationModPerLevel == 0 &&
                r.Stats.PercentMovementSpeedMod == 0 &&
                r.Stats.PercentMovementSpeedModPerLevel == 0 &&
                r.Stats.PercentMPPoolMod == 0 &&
                r.Stats.PercentMPRegenMod == 0 &&
                r.Stats.PercentPhysicalDamageMod == 0 &&
                r.Stats.PercentSpellBlockMod == 0 &&
                r.Stats.PercentSpellVampMod == 0 &&
                r.Stats.PercentTimeDeadMod == 0 &&
                r.Stats.PercentTimeDeadModPerLevel == 0);
            if (statlessRune != null)
                Assert.Fail("A rune had no stats: " + statlessRune.Name + " (ID: " + statlessRune.Id + ", Description: '" + statlessRune.Description + "')");
        }

        [Test]
        public async Task GetRuneByIdAsyncTaskTest()
        {
            var client = new RiotClient();

            // 8020 = Greater Quintessence of the Deadly Wreath (armor pen).
            var rune = await client.GetRuneByIdTaskAsync(8020, runeData: new[] { "all" });
            Assert.That(rune, Is.Not.Null);
            Assert.That(rune.Colloq, Is.EqualTo(string.Empty));
            Assert.That(rune.Description, Is.Not.Null.And.Not.Empty);
            Assert.That(rune.Id, Is.GreaterThan(0));
            Assert.That(rune.Image, Is.Not.Null);
            Assert.That(rune.Maps, Is.Not.Null.And.Not.Empty);
            Assert.That(rune.Name, Is.Not.Null.And.Not.Empty);
            Assert.That(rune.SanitizedDescription, Is.Not.Null.And.Not.Empty);
            Assert.That(rune.Stats, Is.Not.Null);
            Assert.That(rune.Tags, Is.Not.Null.And.Not.Empty);

            Assert.That(rune.Rune, Is.Not.Null);
            Assert.That(rune.Rune.IsRune);
            Assert.That(rune.Rune.Tier, Is.Not.Null.And.Not.Empty);
            Assert.That(rune.Rune.Type, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public async Task RuneDefaultsTest()
        {
            // Test that the hard-coded default values are correct.
            var client = new RiotClient();
            var runeList = await client.GetRunesTaskAsync(runeListData: new[] { "all" });
            var defaultRune = new StaticRune();
            TestHelper.AssertObjectEqualityRecursive(defaultRune, runeList.Basic, true);
        }

        #endregion
    }
}
