using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using RiotNet.Models;
using RiotNet.Tests.Properties;

namespace RiotNet.Tests
{
    [TestFixture]
    public class StaticDataTests : TestBase
    {
        #region Champions

        [Test]
        public async Task GetStaticChampionsAsyncTest()
        {
            IRiotClient client = new RiotClient();
            var championList = await client.GetStaticChampionsAsync(champListData: new[] { "all" });

            Assert.That(championList.Data.Count, Is.GreaterThan(0));
            Assert.That(championList.Format, Is.Not.Null.And.Not.Empty);
            Assert.That(championList.Keys.Count, Is.GreaterThan(0));
            Assert.That(championList.Type, Is.Not.Null.And.Not.Empty);
            Assert.That(championList.Version, Is.Not.Null.And.Not.Empty);

            // The key should NOT be an integer
            var key = championList.Data.Keys.First();
            int id;
            var isInteger = int.TryParse(key, out id);
            Assert.That(isInteger, Is.False, "Champs are listed by ID, but should be listed by key.");
        }

        [Test]
        public async Task GetStaticChampionsAsyncTest_IndexedById()
        {
            IRiotClient client = new RiotClient();
            var championList = await client.GetStaticChampionsAsync(dataById: true, champListData: new[] { "AllyTips", "Blurb" });

            Assert.That(championList.Data.Count, Is.GreaterThan(0));

            var champion = championList.Data.Values.First();
            Assert.That(champion.AllyTips, Is.Not.Null.And.No.Empty);
            Assert.That(champion.Blurb, Is.Not.Null.And.No.Empty);
            Assert.That(champion.EnemyTips, Is.Null.Or.Empty);
        }

        [Test]
        public async Task GetStaticChampionsAsyncTest_WithSelectedFields()
        {
            IRiotClient client = new RiotClient();
            var championList = await client.GetStaticChampionsAsync(champListData: new[] { "all" });

            Assert.That(championList.Data.Count, Is.GreaterThan(0));
            Assert.That(championList.Format, Is.Not.Null.And.Not.Empty);
            Assert.That(championList.Keys.Count, Is.GreaterThan(0));
            Assert.That(championList.Type, Is.Not.Null.And.Not.Empty);
            Assert.That(championList.Version, Is.Not.Null.And.Not.Empty);

            // The key should NOT be an integer
            var key = championList.Data.Keys.First();
            int id;
            var isInteger = int.TryParse(key, out id);
            Assert.That(isInteger, Is.False, "Champs are listed by ID, but should be listed by key.");
        }

        [Test]
        public async Task GetStaticChampionByIdAsyncTest()
        {
            IRiotClient client = new RiotClient();
            // 43 = Karma
            var champion = await client.GetStaticChampionByIdAsync(43, champData: new[] { "all" });

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

        [Test]
        public async Task GetStaticChampionByIdAsyncTest_WithSelectedFields()
        {
            IRiotClient client = new RiotClient();
            // 43 = Karma
            var champion = await client.GetStaticChampionByIdAsync(43, champData: new[] { "EnemyTips", "Lore" });

            Assert.That(champion.AllyTips, Is.Null.Or.Empty);
            Assert.That(champion.EnemyTips, Is.Not.Null.And.No.Empty);
            Assert.That(champion.Lore, Is.Not.Null.And.No.Empty);
        }

        #endregion

        #region Items

        [Test]
        public async Task GetStaticItemsAsyncTest()
        {
            IRiotClient client = new RiotClient();
            var itemList = await client.GetStaticItemsAsync(itemListData: new[] { "all" });

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
        public async Task GetStaticItemsAsyncTest_WithSelectedFields()
        {
            IRiotClient client = new RiotClient();
            var itemList = await client.GetStaticItemsAsync(itemListData: new[] { "Maps", "SanitizedDescription" });

            Assert.That(itemList.Data, Is.Not.Null);
            Assert.That(itemList.Data.Count, Is.GreaterThan(0));
            var item = itemList.Data.Values.First();
            Assert.That(item.Maps, Is.Not.Null.And.Not.Empty);
            Assert.That(item.SanitizedDescription, Is.Not.Null.And.Not.Empty);
            Assert.That(item.Image.Full, Is.Null.Or.Empty);
        }
        
        [Test]
        public async Task StaticItemDefaultsTest()
        {
            // Test that the hard-coded default values are correct.
            IRiotClient client = new RiotClient();
            var itemList = await client.GetStaticItemsAsync(itemListData: new[] { "all" });
            var defaultItem = new StaticItem();
            AssertObjectEqualityRecursive(defaultItem, itemList.Basic, true);
        }

        #endregion

        #region Languages

        [Test]
        public async Task GetStaticLanguagesAsyncTest()
        {
            IRiotClient client = new RiotClient();
            var languages = await client.GetStaticLanguagesAsync();

            Assert.That(languages, Is.Not.Null.And.Not.Empty);
            var language = languages.First();
            Assert.That(language, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public async Task GetStaticLanguageStringsAsyncTest()
        {
            IRiotClient client = new RiotClient();
            var languageStrings = await client.GetStaticLanguageStringsAsync();

            Assert.That(languageStrings, Is.Not.Null);
            Assert.That(languageStrings.Data, Is.Not.Null.And.Not.Empty);
            Assert.That(languageStrings.Type, Is.Not.Null.And.Not.Empty);
            Assert.That(languageStrings.Version, Is.Not.Null.And.Not.Empty);
        }

        #endregion

        #region Map

        [Test]
        public async Task GetStaticMapsAsyncTest()
        {
            IRiotClient client = new RiotClient();
            var mapList = await client.GetStaticMapsAsync();

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
        
        #region Masteries

        [Test]
        public async Task GetStaticMasteriesAsyncTest()
        {
            IRiotClient client = new RiotClient();
            var masteryList = await client.GetStaticMasteriesAsync(masteryListData: new[] { "all" });

            Assert.That(masteryList.Data.Count, Is.GreaterThan(0));
            Assert.That(masteryList.Tree, Is.Not.Null);
            Assert.That(masteryList.Type, Is.Not.Null.And.Not.Empty);
            Assert.That(masteryList.Version, Is.Not.Null.And.Not.Empty);

            var mastery = masteryList.Data.Values.First();
            Assert.That(mastery.Id, Is.GreaterThan(0));
            Assert.That(mastery.Description, Is.Not.Null.And.Not.Empty);
            Assert.That(mastery.Image, Is.Not.Null);
            Assert.That(masteryList.Data.Values.Any(m => m.MasteryTree == MastertyTreeType.Cunning));
            Assert.That(mastery.Name, Is.Not.Null.And.Not.Empty);
            // Season 6 does not have any masteries with prereqs.
            //Assert.That(masteryList.Data.Values.Any(m => m.Prereq > 0));
            Assert.That(mastery.Ranks, Is.GreaterThan(0));
            Assert.That(mastery.SanitizedDescription, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public async Task GetStaticMasteriesAsyncTest_WithSelectedFields()
        {
            IRiotClient client = new RiotClient();
            var masteryList = await client.GetStaticMasteriesAsync(masteryListData: new[] { "Tree", "MasteryTree" });

            Assert.That(masteryList.Data.Count, Is.GreaterThan(0));
            Assert.That(masteryList.Tree, Is.Not.Null);

            Assert.That(masteryList.Data.Values.Any(m => m.MasteryTree != MastertyTreeType.Ferocity));
            Assert.That(masteryList.Data.Values.All(m => m.Ranks == 0));
        }

        [Test]
        public async Task GetStaticMasteryByIdAsyncTest()
        {
            IRiotClient client = new RiotClient();
            var mastery = await client.GetStaticMasteryByIdAsync(6121, masteryData: new[] { "all" });

            Assert.That(mastery, Is.Not.Null);
            Assert.That(mastery.Ranks, Is.GreaterThan(0));
        }

        [Test]
        public async Task GetStaticMasteryByIdAsyncTest_WithSelectedFields()
        {
            IRiotClient client = new RiotClient();
            var mastery = await client.GetStaticMasteryByIdAsync(6121, masteryData: new[] { "MasteryTree", "Ranks" });

            Assert.That(mastery.MasteryTree != MastertyTreeType.Resolve);
            Assert.That(mastery.Ranks, Is.GreaterThan(0));
            Assert.That(mastery.SanitizedDescription, Is.Null.Or.Empty);
        }

        [Test]
        public void DeserializeMasteryTest()
        {
            var mastery = JsonConvert.DeserializeObject<StaticMastery>(Resources.SampleStaticMastery, RiotClient.JsonSettings);

            AssertNonDefaultValuesRecursive(mastery);
        }

        #endregion

        #region Realm

        [Test]
        public async Task GetStaticRealmAsyncTest()
        {
            IRiotClient client = new RiotClient();
            var realm = await client.GetStaticRealmAsync();

            Assert.That(realm, Is.Not.Null);
            Assert.That(realm.Cdn, Is.Not.Null.And.Not.Empty);
            Assert.That(realm.Css, Is.Not.Null.And.Not.Empty);
            Assert.That(realm.Dd, Is.Not.Null.And.Not.Empty);
            Assert.That(realm.L, Is.Not.Null.And.Not.Empty);
            Assert.That(realm.Lg, Is.Not.Null.And.Not.Empty);
            Assert.That(realm.N, Is.Not.Null.And.Not.Empty);
            Assert.That(realm.ProfileIconMax, Is.GreaterThan(0));
            Assert.That(realm.V, Is.Not.Null.And.Not.Empty);
        }

        #endregion

        #region Runes

        [Test]
        public async Task GetStaticRunesAsyncTest()
        {
            IRiotClient client = new RiotClient();
            var runeList = await client.GetStaticRunesAsync(runeListData: new[] { "all" });

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
        public async Task GetStaticRunesAsyncTest_WithSelectedFields()
        {
            IRiotClient client = new RiotClient();
            var runeList = await client.GetStaticRunesAsync(runeListData: new[] { "Basic", "Image", "SanitizedDescription" });

            Assert.That(runeList.Basic, Is.Not.Null);
            Assert.That(runeList.Data.Count, Is.GreaterThan(0));
            var rune = runeList.Data.Values.First();
            Assert.That(rune.Image.Full, Is.Not.Null.And.Not.Empty);
            Assert.That(rune.SanitizedDescription, Is.Not.Null.And.Not.Empty);
            Assert.That(rune.Tags, Is.Null.Or.Empty);
        }

        [Test]
        public async Task GetStaticRuneByIdAsyncTest()
        {
            IRiotClient client = new RiotClient();

            // 8020 = Greater Quintessence of the Deadly Wreath (armor pen).
            var rune = await client.GetStaticRuneByIdAsync(8020, runeData: new[] { "all" });
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
        public async Task GetStaticRuneByIdAsyncTest_WithSelectedFields()
        {
            IRiotClient client = new RiotClient();
            // 8020 = Greater Quintessence of the Deadly Wreath (armor pen).
            var rune = await client.GetStaticRuneByIdAsync(8020, runeData: new[] { "Image", "SanitizedDescription" });

            Assert.That(rune.Image.Full, Is.Not.Null.And.Not.Empty);
            Assert.That(rune.SanitizedDescription, Is.Not.Null.And.Not.Empty);
            Assert.That(rune.Tags, Is.Null.Or.Empty);
        }

        [Test]
        public async Task StaticRuneDefaultsTest()
        {
            // Test that the hard-coded default values are correct.
            IRiotClient client = new RiotClient();
            var runeList = await client.GetStaticRunesAsync(runeListData: new[] { "all" });
            var defaultRune = new StaticRune();
            AssertObjectEqualityRecursive(defaultRune, runeList.Basic, true);
        }

        #endregion

        #region Summoner Spells

        [Test]
        public async Task GetStaticSummonerSpellsAsyncTest()
        {
            IRiotClient client = new RiotClient();
            var spellList = await client.GetStaticSummonerSpellsAsync(spellListData: new[] { "all" });

            Assert.That(spellList.Data.Count, Is.GreaterThan(0));
            Assert.That(spellList.Type, Is.Not.Null.And.Not.Empty);
            Assert.That(spellList.Version, Is.Not.Null.And.Not.Empty);

            var spell = spellList.Data.Values.First();
            Assert.That(spell.Id, Is.GreaterThan(0));
            Assert.That(spell.Cooldown, Is.Not.Null.And.Not.Empty);
            foreach (var cooldown in spell.Cooldown)
                Assert.That(cooldown, Is.GreaterThan(0));
            Assert.That(spell.CooldownBurn, Is.Not.Null.And.Not.Empty);
            Assert.That(spell.Cost, Is.Not.Null.And.Not.Empty);
            Assert.That(spell.CostBurn, Is.Not.Null.And.Not.Empty);
            Assert.That(spell.CostType, Is.Not.Null.And.Not.Empty);
            Assert.That(spell.Description, Is.Not.Null.And.Not.Empty);
            Assert.That(spellList.Data.Values.Any(s => s.Effect != null && s.Effect.Count > 0));
            Assert.That(spellList.Data.Values.Any(s => s.EffectBurn != null && s.EffectBurn.Count > 0));
            Assert.That(spell.Image, Is.Not.Null);
            Assert.That(spell.Key, Is.Not.Null.And.Not.Empty);
            Assert.That(spell.MaxRank, Is.GreaterThan(0));
            Assert.That(spell.Modes, Is.Not.Null.And.Not.Empty);
            Assert.That(spell.Modes.First(), Is.Not.Null.And.Not.Empty);
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

            // The key should NOT be an integer
            var key = spellList.Data.Keys.First();
            int id;
            var isInteger = int.TryParse(key, out id);
            Assert.That(isInteger, Is.False, "Champs are listed by ID, but should be listed by key.");
        }

        [Test]
        public async Task GetStaticSummonerSpellsAsyncTest_WithSelectedFields()
        {
            IRiotClient client = new RiotClient();
            var spellList = await client.GetStaticSummonerSpellsAsync(spellListData: new[] { "Cooldown", "CooldownBurn" });

            Assert.That(spellList.Data.Count, Is.GreaterThan(0));

            var spell = spellList.Data.Values.First();
            Assert.That(spell.Cooldown, Is.Not.Null.And.Not.Empty);
            Assert.That(spell.CooldownBurn, Is.Not.Null.And.Not.Empty);
            Assert.That(spell.Cost, Is.Null.Or.Empty);
        }

        [Test]
        public async Task GetStaticSummonerSpellAsyncTest_IndexedById()
        {
            IRiotClient client = new RiotClient();
            var spellList = await client.GetStaticSummonerSpellsAsync(dataById: true, spellListData: new[] { "all" });

            Assert.That(spellList.Data.Count, Is.GreaterThan(0));

            // The key should be an integer
            var key = spellList.Data.Keys.First();
            int id;
            var isInteger = int.TryParse(key, out id);
            Assert.That(isInteger, "Spells are not listed by ID.");
        }

        [Test]
        public async Task GetStaticSummonerSpellByIdAsyncTest()
        {
            IRiotClient client = new RiotClient();

            // 1 = Cleanse
            var spell = await client.GetStaticSummonerSpellByIdAsync(1, spellData: new[] { "all" });

            Assert.That(spell, Is.Not.Null);
            Assert.That(spell.Id, Is.EqualTo(1));
        }

        [Test]
        public async Task GetStaticSummonerSpellByIdAsyncTest_WithSelectedFields()
        {
            IRiotClient client = new RiotClient();
            var spell = await client.GetStaticSummonerSpellByIdAsync(1, spellData: new[] { "Cooldown", "CooldownBurn" });

            Assert.That(spell.Cooldown, Is.Not.Null.And.Not.Empty);
            Assert.That(spell.CooldownBurn, Is.Not.Null.And.Not.Empty);
            Assert.That(spell.Cost, Is.Null.Or.Empty);
        }

        #endregion

        #region Versions

        [Test]
        public async Task GetStaticVersionsAsyncTest()
        {
            IRiotClient client = new RiotClient();
            var versions = await client.GetVersionsAsync();

            Assert.That(versions, Is.Not.Null.And.Not.Empty);
        }

        #endregion

    }
}
