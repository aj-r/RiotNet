using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

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
        [JsonProperty(nameof(FlatArmorMod))]
        public double FlatArmorMod { get; set; }

        /// <summary>
        /// Gets the flat attack speed added to the target's stats.
        /// </summary>
        [JsonProperty(nameof(FlatAttackSpeedMod))]
        public double FlatAttackSpeedMod { get; set; }

        /// <summary>
        /// Gets the flat block chance added to the target's stats.
        /// </summary>
        [JsonProperty(nameof(FlatBlockMod))]
        public double FlatBlockMod { get; set; }

        /// <summary>
        /// Gets the flat critical strike chance added to the target's stats.
        /// </summary>
        [JsonProperty(nameof(FlatCritChanceMod))]
        public double FlatCritChanceMod { get; set; }

        /// <summary>
        /// Gets the flat critical strike damage added to the target's stats.
        /// </summary>
        [JsonProperty(nameof(FlatCritDamageMod))]
        public double FlatCritDamageMod { get; set; }

        /// <summary>
        /// Gets the flat experience bonus added to the target's stats.
        /// </summary>
        [JsonProperty(nameof(FlatEXPBonus))]
        public double FlatEXPBonus { get; set; }

        /// <summary>
        /// Gets the flat energy added to the target's stats.
        /// </summary>
        [JsonProperty(nameof(FlatEnergyPoolMod))]
        public double FlatEnergyPoolMod { get; set; }

        /// <summary>
        /// Gets the flat enery regeneration added to the target's stats.
        /// </summary>
        [JsonProperty(nameof(FlatEnergyRegenMod))]
        public double FlatEnergyRegenMod { get; set; }

        /// <summary>
        /// Gets the flat health added to the target's stats.
        /// </summary>
        [JsonProperty(nameof(FlatHPPoolMod))]
        public double FlatHPPoolMod { get; set; }

        /// <summary>
        /// Gets the flat health regeneration added to the target's stats.
        /// </summary>
        [JsonProperty(nameof(FlatHPRegenMod))]
        public double FlatHPRegenMod { get; set; }

        /// <summary>
        /// Gets the flat mana modifiacation to the target's stats.
        /// </summary>
        [JsonProperty(nameof(FlatMPPoolMod))]
        public double FlatMPPoolMod { get; set; }

        /// <summary>
        /// Gets the flat mana regeneration added to the target's stats.
        /// </summary>
        [JsonProperty(nameof(FlatMPRegenMod))]
        public double FlatMPRegenMod { get; set; }

        /// <summary>
        /// Gets the flat ability power added to the target's stats.
        /// </summary>
        [JsonProperty(nameof(FlatMagicDamageMod))]
        public double FlatMagicDamageMod { get; set; }

        /// <summary>
        /// Gets the flat movement speed added to the target's stats.
        /// </summary>
        [JsonProperty(nameof(FlatMovementSpeedMod))]
        public double FlatMovementSpeedMod { get; set; }

        /// <summary>
        /// Gets the flat attack damage added to the target's stats.
        /// </summary>
        [JsonProperty(nameof(FlatPhysicalDamageMod))]
        public double FlatPhysicalDamageMod { get; set; }

        /// <summary>
        /// Gets the flat spell block added to the target's stats.
        /// </summary>
        [JsonProperty(nameof(FlatSpellBlockMod))]
        public double FlatSpellBlockMod { get; set; }

        /// <summary>
        /// Gets the percent armor added to the target's stats.
        /// </summary>
        [JsonProperty(nameof(PercentArmorMod))]
        public double PercentArmorMod { get; set; }

        /// <summary>
        /// Gets the percent attack speed added to the target's stats.
        /// </summary>
        [JsonProperty(nameof(PercentAttackSpeedMod))]
        public double PercentAttackSpeedMod { get; set; }

        /// <summary>
        /// Gets the percent block added to the target's stats.
        /// </summary>
        [JsonProperty(nameof(PercentBlockMod))]
        public double PercentBlockMod { get; set; }

        /// <summary>
        /// Gets the percent ctritical strike chance added to the target's stats.
        /// </summary>
        [JsonProperty(nameof(PercentCritChanceMod))]
        public double PercentCritChanceMod { get; set; }

        /// <summary>
        /// Gets the percent critical strike damage added to the target's stats.
        /// </summary>
        [JsonProperty(nameof(PercentCritDamageMod))]
        public double PercentCritDamageMod { get; set; }

        /// <summary>
        /// Gets the percent dodge added to the target's stats.
        /// </summary>
        [JsonProperty(nameof(PercentDodgeMod))]
        public double PercentDodgeMod { get; set; }

        /// <summary>
        /// Gets the percent experience bonus added to the target's stats.
        /// </summary>
        [JsonProperty(nameof(PercentEXPBonus))]
        public double PercentEXPBonus { get; set; }

        /// <summary>
        /// Gets the percent health added to the target's stats.
        /// </summary>
        [JsonProperty(nameof(PercentHPPoolMod))]
        public double PercentHPPoolMod { get; set; }

        /// <summary>
        /// Gets the percent health regeneration added to the target's stats.
        /// </summary>
        [JsonProperty(nameof(PercentHPRegenMod))]
        public double PercentHPRegenMod { get; set; }

        /// <summary>
        /// Gets the percent life steal added to the target's stats.
        /// </summary>
        [JsonProperty(nameof(PercentLifeStealMod))]
        public double PercentLifeStealMod { get; set; }

        /// <summary>
        /// Gets the percent mana added to the target's stats.
        /// </summary>
        [JsonProperty(nameof(PercentMPPoolMod))]
        public double PercentMPPoolMod { get; set; }

        /// <summary>
        /// Gets the percent mana regeneration added to the target's stats.
        /// </summary>
        [JsonProperty(nameof(PercentMPRegenMod))]
        public double PercentMPRegenMod { get; set; }

        /// <summary>
        /// Gets the percent ability power added to the target's stats.
        /// </summary>
        [JsonProperty(nameof(PercentMagicDamageMod))]
        public double PercentMagicDamageMod { get; set; }

        /// <summary>
        /// Gets the percent movement speed added to the target's stats.
        /// </summary>
        [JsonProperty(nameof(PercentMovementSpeedMod))]
        public double PercentMovementSpeedMod { get; set; }

        /// <summary>
        /// Gets the percent attack damage added to the target's stats.
        /// </summary>
        [JsonProperty(nameof(PercentPhysicalDamageMod))]
        public double PercentPhysicalDamageMod { get; set; }

        /// <summary>
        /// Gets the percent spell block added to the target's stats.
        /// </summary>
        [JsonProperty(nameof(PercentSpellBlockMod))]
        public double PercentSpellBlockMod { get; set; }

        /// <summary>
        /// Gets the percent spell vamp added to the target's stats.
        /// </summary>
        [JsonProperty(nameof(PercentSpellVampMod))]
        public double PercentSpellVampMod { get; set; }
    }
}
