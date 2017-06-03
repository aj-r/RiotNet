using Newtonsoft.Json;

namespace RiotNet.Models
{
    /// <summary>
    /// Represents stats of a rune.
    /// </summary>
    public class RuneDataStats : BasicDataStats
    {
        /// <summary>
        /// Gets the flat armor added per level to the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty(nameof(FlatArmorModPerLevel))]
        public double FlatArmorModPerLevel { get; set; }

        /// <summary>
        /// Gets the flat armor penetration added to the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty(nameof(FlatArmorPenetrationMod))]
        public double FlatArmorPenetrationMod { get; set; }

        /// <summary>
        /// Gets the flat armor added per level to the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty(nameof(FlatArmorPenetrationModPerLevel))]
        public double FlatArmorPenetrationModPerLevel { get; set; }

        /// <summary>
        /// Gets the flat critical strike chance per level added to the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty(nameof(FlatCritChanceModPerLevel))]
        public double FlatCritChanceModPerLevel { get; set; }

        /// <summary>
        /// Gets the flat critical strike damage per level added to the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty(nameof(FlatCritDamageModPerLevel))]
        public double FlatCritDamageModPerLevel { get; set; }

        /// <summary>
        /// Gets the flat dodge chance added to the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty(nameof(FlatDodgeMod))]
        public double FlatDodgeMod { get; set; }

        /// <summary>
        /// Gets the flat dodge chance per level added to the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty(nameof(FlatDodgeModPerLevel))]
        public double FlatDodgeModPerLevel { get; set; }

        /// <summary>
        /// Gets the flat energy per level added to the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty(nameof(FlatEnergyModPerLevel))]
        public double FlatEnergyModPerLevel { get; set; }

        /// <summary>
        /// Gets the flat energy regeneration per level added to the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty(nameof(FlatEnergyRegenModPerLevel))]
        public double FlatEnergyRegenModPerLevel { get; set; }

        /// <summary>
        /// Gets the gold per 10 seconds added to the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty(nameof(FlatGoldPer10Mod))]
        public double FlatGoldPer10Mod { get; set; }

        /// <summary>
        /// Gets the flat health per level added to the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty(nameof(FlatHPModPerLevel))]
        public double FlatHPModPerLevel { get; set; }

        /// <summary>
        /// Gets the flat health regen per level added to the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty(nameof(FlatHPRegenModPerLevel))]
        public double FlatHPRegenModPerLevel { get; set; }

        /// <summary>
        /// Gets the flat mana per level added to the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty(nameof(FlatMPModPerLevel))]
        public double FlatMPModPerLevel { get; set; }

        /// <summary>
        /// Gets the flat mana regeneration per level added to the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty(nameof(FlatMPRegenModPerLevel))]
        public double FlatMPRegenModPerLevel { get; set; }

        /// <summary>
        /// Gets the flat ability power per level added to the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty(nameof(FlatMagicDamageModPerLevel))]
        public double FlatMagicDamageModPerLevel { get; set; }

        /// <summary>
        /// Gets the flat magic penetration added to the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty(nameof(FlatMagicPenetrationMod))]
        public double FlatMagicPenetrationMod { get; set; }

        /// <summary>
        /// Gets the flat magic penetration per level added to the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty(nameof(FlatMagicPenetrationModPerLevel))]
        public double FlatMagicPenetrationModPerLevel { get; set; }

        /// <summary>
        /// Gets the flat movement speed per level added to the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty(nameof(FlatMovementSpeedModPerLevel))]
        public double FlatMovementSpeedModPerLevel { get; set; }

        /// <summary>
        /// Gets the flat attack damage per level added to the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty(nameof(FlatPhysicalDamageModPerLevel))]
        public double FlatPhysicalDamageModPerLevel { get; set; }

        /// <summary>
        /// Gets the flat spell block per level added to the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty(nameof(FlatSpellBlockModPerLevel))]
        public double FlatSpellBlockModPerLevel { get; set; }

        /// <summary>
        /// Gets the flat time spent dead subtracted from the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty(nameof(FlatTimeDeadMod))]
        public double FlatTimeDeadMod { get; set; }

        /// <summary>
        /// Gets the flat time spent dead per level subtracted from the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty(nameof(FlatTimeDeadModPerLevel))]
        public double FlatTimeDeadModPerLevel { get; set; }

        /// <summary>
        /// Gets the percent armor penetration per level added to the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty(nameof(PercentArmorPenetrationMod))]
        public double PercentArmorPenetrationMod { get; set; }

        /// <summary>
        /// Gets the percent armor penetration per level added to the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty(nameof(PercentArmorPenetrationModPerLevel))]
        public double PercentArmorPenetrationModPerLevel { get; set; }

        /// <summary>
        /// Gets the percent attack speed per level added to the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty(nameof(PercentAttackSpeedModPerLevel))]
        public double PercentAttackSpeedModPerLevel { get; set; }

        /// <summary>
        /// Gets the percent cooldown reduction added to the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty(nameof(PercentCooldownMod))]
        public double PercentCooldownMod { get; set; }

        /// <summary>
        /// Gets the percent cooldown reduction per level added to the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty(nameof(PercentCooldownModPerLevel))]
        public double PercentCooldownModPerLevel { get; set; }

        /// <summary>
        /// Gets the percent magic penetration added to the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty(nameof(PercentMagicPenetrationMod))]
        public double PercentMagicPenetrationMod { get; set; }

        /// <summary>
        /// Gets the percent magic penetration per level added to the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty(nameof(PercentMagicPenetrationModPerLevel))]
        public double PercentMagicPenetrationModPerLevel { get; set; }

        /// <summary>
        /// Gets the percent movement speed per level added to the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty(nameof(PercentMovementSpeedModPerLevel))]
        public double PercentMovementSpeedModPerLevel { get; set; }

        /// <summary>
        /// Gets the percent time spent dead subtracted from the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty(nameof(PercentTimeDeadMod))]
        public double PercentTimeDeadMod { get; set; }

        /// <summary>
        /// Gets the percent time spent per level dead subtracted from the target's stats. This value is only set for runes.
        /// </summary>
        [JsonProperty(nameof(PercentTimeDeadModPerLevel))]
        public double PercentTimeDeadModPerLevel { get; set; }
    }
}
