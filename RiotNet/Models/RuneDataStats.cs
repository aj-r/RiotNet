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
