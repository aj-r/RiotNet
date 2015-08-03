using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace RiotNet.Models
{
    /// <summary>
    /// Represents stats, or buffs, of an object.
    /// </summary>
    [ComplexType]
    public class BasicDataStats
    {
        /// <summary>
        /// Gets the flat armor added to the target's stats.
        /// </summary>
        public double FlatArmorMod { get; set; }

        /// <summary>
        /// Gets the flat attack speed added to the target's stats.
        /// </summary>
        public double FlatAttackSpeedMod { get; set; }

        /// <summary>
        /// Gets the flat block chance added to the target's stats.
        /// </summary>
        public double FlatBlockMod { get; set; }

        /// <summary>
        /// Gets the flat critical strike chance added to the target's stats.
        /// </summary>
        public double FlatCritChanceMod { get; set; }

        /// <summary>
        /// Gets the flat critical strike damage added to the target's stats.
        /// </summary>
        public double FlatCritDamageMod { get; set; }

        /// <summary>
        /// Gets the flat experience bonus added to the target's stats.
        /// </summary>
        public double FlatEXPBonus { get; set; }

        /// <summary>
        /// Gets the flat energy added to the target's stats.
        /// </summary>
        public double FlatEnergyPoolMod { get; set; }

        /// <summary>
        /// Gets the flat enery regeneration added to the target's stats.
        /// </summary>
        public double FlatEnergyRegenMod { get; set; }

        /// <summary>
        /// Gets the flat health added to the target's stats.
        /// </summary>
        public double FlatHPPoolMod { get; set; }

        /// <summary>
        /// Gets the flat health regeneration added to the target's stats.
        /// </summary>
        public double FlatHPRegenMod { get; set; }

        /// <summary>
        /// Gets the flat mana modifiacation to the target's stats.
        /// </summary>
        public double FlatMPPoolMod { get; set; }

        /// <summary>
        /// Gets the flat mana regeneration added to the target's stats.
        /// </summary>
        public double FlatMPRegenMod { get; set; }

        /// <summary>
        /// Gets the flat ability power added to the target's stats.
        /// </summary>
        public double FlatMagicDamageMod { get; set; }

        /// <summary>
        /// Gets the flat movement speed added to the target's stats.
        /// </summary>
        public double FlatMovementSpeedMod { get; set; }

        /// <summary>
        /// Gets the flat attack damage added to the target's stats.
        /// </summary>
        public double FlatPhysicalDamageMod { get; set; }

        /// <summary>
        /// Gets the flat spell block added to the target's stats.
        /// </summary>
        public double FlatSpellBlockMod { get; set; }

        /// <summary>
        /// Gets the percent armor added to the target's stats.
        /// </summary>
        public double PercentArmorMod { get; set; }

        /// <summary>
        /// Gets the percent attack speed added to the target's stats.
        /// </summary>
        public double PercentAttackSpeedMod { get; set; }

        /// <summary>
        /// Gets the percent block added to the target's stats.
        /// </summary>
        public double PercentBlockMod { get; set; }

        /// <summary>
        /// Gets the percent ctritical strike chance added to the target's stats.
        /// </summary>
        public double PercentCritChanceMod { get; set; }

        /// <summary>
        /// Gets the percent critical strike damage added to the target's stats.
        /// </summary>
        public double PercentCritDamageMod { get; set; }

        /// <summary>
        /// Gets the percent dodge added to the target's stats.
        /// </summary>
        public double PercentDodgeMod { get; set; }

        /// <summary>
        /// Gets the percent experience bonus added to the target's stats.
        /// </summary>
        public double PercentEXPBonus { get; set; }

        /// <summary>
        /// Gets the percent health added to the target's stats.
        /// </summary>
        public double PercentHPPoolMod { get; set; }

        /// <summary>
        /// Gets the percent health regeneration added to the target's stats.
        /// </summary>
        public double PercentHPRegenMod { get; set; }

        /// <summary>
        /// Gets the percent life steal added to the target's stats.
        /// </summary>
        public double PercentLifeStealMod { get; set; }

        /// <summary>
        /// Gets the percent mana added to the target's stats.
        /// </summary>
        public double PercentMPPoolMod { get; set; }

        /// <summary>
        /// Gets the percent mana regeneration added to the target's stats.
        /// </summary>
        public double PercentMPRegenMod { get; set; }

        /// <summary>
        /// Gets the percent ability power added to the target's stats.
        /// </summary>
        public double PercentMagicDamageMod { get; set; }

        /// <summary>
        /// Gets the percent movement speed added to the target's stats.
        /// </summary>
        public double PercentMovementSpeedMod { get; set; }

        /// <summary>
        /// Gets the percent attack damage added to the target's stats.
        /// </summary>
        public double PercentPhysicalDamageMod { get; set; }

        /// <summary>
        /// Gets the percent spell block added to the target's stats.
        /// </summary>
        public double PercentSpellBlockMod { get; set; }

        /// <summary>
        /// Gets the percent spell vamp added to the target's stats.
        /// </summary>
        public double PercentSpellVampMod { get; set; }


        /// <summary>
        /// Gets the flat armor added per level to the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty("rFlatArmorModPerLevel")]
        public double FlatArmorModPerLevel { get; set; }

        /// <summary>
        /// Gets the flat armor penetration added to the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty("rFlatArmorPenetrationMod")]
        public double FlatArmorPenetrationMod { get; set; }

        /// <summary>
        /// Gets the flat armor added per level to the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty("rFlatArmorPenetrationModPerLevel")]
        public double FlatArmorPenetrationModPerLevel { get; set; }

        /// <summary>
        /// Gets the flat critical strike chance per level added to the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty("rFlatCritChanceModPerLevel")]
        public double FlatCritChanceModPerLevel { get; set; }

        /// <summary>
        /// Gets the flat critical strike damage per level added to the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty("rFlatCritDamageModPerLevel")]
        public double FlatCritDamageModPerLevel { get; set; }

        /// <summary>
        /// Gets the flat dodge chance added to the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty("rFlatDodgeMod")]
        public double FlatDodgeMod { get; set; }

        /// <summary>
        /// Gets the flat dodge chance per level added to the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty("rFlatDodgeModPerLevel")]
        public double FlatDodgeModPerLevel { get; set; }

        /// <summary>
        /// Gets the flat energy per level added to the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty("rFlatEnergyModPerLevel")]
        public double FlatEnergyModPerLevel { get; set; }

        /// <summary>
        /// Gets the flat energy regeneration per level added to the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty("rFlatEnergyRegenModPerLevel")]
        public double FlatEnergyRegenModPerLevel { get; set; }

        /// <summary>
        /// Gets the gold per 10 seconds added to the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty("rFlatGoldPer10Mod")]
        public double FlatGoldPer10Mod { get; set; }

        /// <summary>
        /// Gets the flat health per level added to the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty("rFlatHPModPerLevel")]
        public double FlatHPModPerLevel { get; set; }

        /// <summary>
        /// Gets the flat health regen per level added to the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty("rFlatHPRegenModPerLevel")]
        public double FlatHPRegenModPerLevel { get; set; }

        /// <summary>
        /// Gets the flat mana per level added to the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty("rFlatMPModPerLevel")]
        public double FlatMPModPerLevel { get; set; }

        /// <summary>
        /// Gets the flat mana regeneration per level added to the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty("rFlatMPRegenModPerLevel")]
        public double FlatMPRegenModPerLevel { get; set; }

        /// <summary>
        /// Gets the flat ability power per level added to the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty("rFlatMagicDamageModPerLevel")]
        public double FlatMagicDamageModPerLevel { get; set; }

        /// <summary>
        /// Gets the flat magic penetration added to the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty("rFlatMagicPenetrationMod")]
        public double FlatMagicPenetrationMod { get; set; }

        /// <summary>
        /// Gets the flat magic penetration per level added to the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty("rFlatMagicPenetrationModPerLevel")]
        public double FlatMagicPenetrationModPerLevel { get; set; }

        /// <summary>
        /// Gets the flat movement speed per level added to the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty("rFlatMovementSpeedModPerLevel")]
        public double FlatMovementSpeedModPerLevel { get; set; }

        /// <summary>
        /// Gets the flat attack damage per level added to the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty("rFlatPhysicalDamageModPerLevel")]
        public double FlatPhysicalDamageModPerLevel { get; set; }

        /// <summary>
        /// Gets the flat spell block per level added to the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty("rFlatSpellBlockModPerLevel")]
        public double FlatSpellBlockModPerLevel { get; set; }

        /// <summary>
        /// Gets the flat time spent dead subtracted from the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty("rFlatTimeDeadMod")]
        public double FlatTimeDeadMod { get; set; }

        /// <summary>
        /// Gets the flat time spent dead per level subtracted from the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty("rFlatTimeDeadModPerLevel")]
        public double FlatTimeDeadModPerLevel { get; set; }

        /// <summary>
        /// Gets the percent armor penetration per level added to the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty("rPercentArmorPenetrationMod")]
        public double PercentArmorPenetrationMod { get; set; }

        /// <summary>
        /// Gets the percent armor penetration per level added to the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty("rPercentArmorPenetrationModPerLevel")]
        public double PercentArmorPenetrationModPerLevel { get; set; }

        /// <summary>
        /// Gets the percent attack speed per level added to the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty("rPercentAttackSpeedModPerLevel")]
        public double PercentAttackSpeedModPerLevel { get; set; }

        /// <summary>
        /// Gets the percent cooldown reduction added to the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty("rPercentCooldownMod")]
        public double PercentCooldownMod { get; set; }

        /// <summary>
        /// Gets the percent cooldown reduction per level added to the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty("rPercentCooldownModPerLevel")]
        public double PercentCooldownModPerLevel { get; set; }

        /// <summary>
        /// Gets the percent magic penetration added to the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty("rPercentMagicPenetrationMod")]
        public double PercentMagicPenetrationMod { get; set; }

        /// <summary>
        /// Gets the percent magic penetration per level added to the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty("rPercentMagicPenetrationModPerLevel")]
        public double PercentMagicPenetrationModPerLevel { get; set; }

        /// <summary>
        /// Gets the percent movement speed per level added to the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty("rPercentMovementSpeedModPerLevel")]
        public double PercentMovementSpeedModPerLevel { get; set; }

        /// <summary>
        /// Gets the percent time spent dead subtracted from the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty("rPercentTimeDeadMod")]
        public double PercentTimeDeadMod { get; set; }

        /// <summary>
        /// Gets the percent time spent per level dead subtracted from the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty("rPercentTimeDeadModPerLevel")]
        public double PercentTimeDeadModPerLevel { get; set; }
    }
}
