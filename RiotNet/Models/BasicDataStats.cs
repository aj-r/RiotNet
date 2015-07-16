using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace RiotNet.Models
{
    /// <summary>
    /// Represents stats, or buffs, of an object.
    /// </summary>
    public class BasicDataStats
    {
        /// <summary>
        /// Gets the flat armor modification to the target's stats.
        /// </summary>
        public double FlatArmorMod { get; set; }

        /// <summary>
        /// Gets the flat attack speed modification to the target's stats.
        /// </summary>
        public double FlatAttackSpeedMod { get; set; }

        /// <summary>
        /// Gets the flat block modification to the target's stats.
        /// </summary>
        public double FlatBlockMod { get; set; }

        /// <summary>
        /// Gets the flat critical strike chance modification to the target's stats.
        /// </summary>
        public double FlatCritChanceMod { get; set; }

        /// <summary>
        /// Gets the flat critical strike damage modification to the target's stats.
        /// </summary>
        public double FlatCritDamageMod { get; set; }

        /// <summary>
        /// Gets the flat experience bonus modification to the target's stats.
        /// </summary>
        public double FlatEXPBonus { get; set; }

        /// <summary>
        /// Gets the flat energy modification to the target's stats.
        /// </summary>
        public double FlatEnergyPoolMod { get; set; }

        /// <summary>
        /// Gets the flat enery regeneration modification to the target's stats.
        /// </summary>
        public double FlatEnergyRegenMod { get; set; }

        /// <summary>
        /// Gets the flat helth modification to the target's stats.
        /// </summary>
        public double FlatHPPoolMod { get; set; }

        /// <summary>
        /// Gets the flat health regeneration modification to the target's stats.
        /// </summary>
        public double FlatHPRegenMod { get; set; }

        /// <summary>
        /// Gets the flat mana modification to the target's stats.
        /// </summary>
        public double FlatMPPoolMod { get; set; }

        /// <summary>
        /// Gets the flat mana regeneration modification to the target's stats.
        /// </summary>
        public double FlatMPRegenMod { get; set; }

        /// <summary>
        /// Gets the flat ability power modification to the target's stats.
        /// </summary>
        public double FlatMagicDamageMod { get; set; }

        /// <summary>
        /// Gets the flat movement speed modification to the target's stats.
        /// </summary>
        public double FlatMovementSpeedMod { get; set; }

        /// <summary>
        /// Gets the flat attack damage modification to the target's stats.
        /// </summary>
        public double FlatPhysicalDamageMod { get; set; }

        /// <summary>
        /// Gets the flat spell block modification to the target's stats.
        /// </summary>
        public double FlatSpellBlockMod { get; set; }

        /// <summary>
        /// Gets the percent armor modification to the target's stats.
        /// </summary>
        public double PercentArmorMod { get; set; }

        /// <summary>
        /// Gets the percent attack speed modification to the target's stats.
        /// </summary>
        public double PercentAttackSpeedMod { get; set; }

        /// <summary>
        /// Gets the percent block modification to the target's stats.
        /// </summary>
        public double PercentBlockMod { get; set; }

        /// <summary>
        /// Gets the percent ctritical strike chance modification to the target's stats.
        /// </summary>
        public double PercentCritChanceMod { get; set; }

        /// <summary>
        /// Gets the percent critical strike damage modification to the target's stats.
        /// </summary>
        public double PercentCritDamageMod { get; set; }

        /// <summary>
        /// Gets the percent dodge modification to the target's stats.
        /// </summary>
        public double PercentDodgeMod { get; set; }

        /// <summary>
        /// Gets the percent experience bonus modification to the target's stats.
        /// </summary>
        public double PercentEXPBonus { get; set; }

        /// <summary>
        /// Gets the percent health modification to the target's stats.
        /// </summary>
        public double PercentHPPoolMod { get; set; }

        /// <summary>
        /// Gets the percent health regeneration modification to the target's stats.
        /// </summary>
        public double PercentHPRegenMod { get; set; }

        /// <summary>
        /// Gets the percent life steal modification to the target's stats.
        /// </summary>
        public double PercentLifeStealMod { get; set; }

        /// <summary>
        /// Gets the percent mana modification to the target's stats.
        /// </summary>
        public double PercentMPPoolMod { get; set; }

        /// <summary>
        /// Gets the percent mana regeneration modification to the target's stats.
        /// </summary>
        public double PercentMPRegenMod { get; set; }

        /// <summary>
        /// Gets the percent ability power modification to the target's stats.
        /// </summary>
        public double PercentMagicDamageMod { get; set; }

        /// <summary>
        /// Gets the percent movement speed modification to the target's stats.
        /// </summary>
        public double PercentMovementSpeedMod { get; set; }

        /// <summary>
        /// Gets the percent attack damage modification to the target's stats.
        /// </summary>
        public double PercentPhysicalDamageMod { get; set; }

        /// <summary>
        /// Gets the percent spell block modification to the target's stats.
        /// </summary>
        public double PercentSpellBlockMod { get; set; }

        /// <summary>
        /// Gets the percent spell vamp modification to the target's stats.
        /// </summary>
        public double PercentSpellVampMod { get; set; }


        /// <summary>
        /// Gets the flat armor modification per level to the target's stats.
        /// </summary>
        [JsonProperty("rFlatArmorModPerLevel")]
        public double FlatArmorModPerLevel { get; set; }

        /// <summary>
        /// Gets the flat armor penetration to the target's stats.
        /// </summary>
        [JsonProperty("rFlatArmorPenetrationMod")]
        public double FlatArmorPenetrationMod { get; set; }

        /// <summary>
        /// Gets the flat armor modification per level to the target's stats.
        /// </summary>
        [JsonProperty("rFlatArmorPenetrationModPerLevel")]
        public double FlatArmorPenetrationModPerLevel { get; set; }

        /// <summary>
        /// Gets the flat critical strike chance per level added to the target's stats.
        /// </summary>
        [JsonProperty("rFlatCritChanceModPerLevel")]
        public double FlatCritChanceModPerLevel { get; set; }

        /// <summary>
        /// Gets the flat critical strike damage per level added to the target's stats.
        /// </summary>
        [JsonProperty("rFlatCritDamageModPerLevel")]
        public double FlatCritDamageModPerLevel { get; set; }

        /// <summary>
        /// Gets the flat dodge added to the target's stats.
        /// </summary>
        [JsonProperty("rFlatDodgeMod")]
        public double FlatDodgeMod { get; set; }

        /// <summary>
        /// Gets the flat dodge per level added to the target's stats.
        /// </summary>
        [JsonProperty("rFlatDodgeModPerLevel")]
        public double FlatDodgeModPerLevel { get; set; }

        /// <summary>
        /// Gets the flat energy per level added to the target's stats.
        /// </summary>
        [JsonProperty("rFlatEnergyModPerLevel")]
        public double FlatEnergyModPerLevel { get; set; }

        /// <summary>
        /// Gets the flat energy regeneration per level added to the target's stats.
        /// </summary>
        [JsonProperty("rFlatEnergyRegenModPerLevel")]
        public double FlatEnergyRegenModPerLevel { get; set; }

        /// <summary>
        /// Gets the gold per 10 seconds added to the target's stats.
        /// </summary>
        [JsonProperty("rFlatGoldPer10Mod")]
        public double FlatGoldPer10Mod { get; set; }

        /// <summary>
        /// Gets the flat health per level added to the target's stats.
        /// </summary>
        [JsonProperty("rFlatHPModPerLevel")]
        public double FlatHPModPerLevel { get; set; }

        /// <summary>
        /// Gets the flat health regen per level added to the target's stats.
        /// </summary>
        [JsonProperty("rFlatHPRegenModPerLevel")]
        public double FlatHPRegenModPerLevel { get; set; }

        /// <summary>
        /// Gets the flat mana per level added to the target's stats.
        /// </summary>
        [JsonProperty("rFlatMPModPerLevel")]
        public double FlatMPModPerLevel { get; set; }

        /// <summary>
        /// Gets the flat mana regeneration per level added to the target's stats.
        /// </summary>
        [JsonProperty("rFlatMPRegenModPerLevel")]
        public double FlatMPRegenModPerLevel { get; set; }

        /// <summary>
        /// Gets the flat ability power per level added to the target's stats.
        /// </summary>
        [JsonProperty("rFlatMagicDamageModPerLevel")]
        public double FlatMagicDamageModPerLevel { get; set; }

        /// <summary>
        /// Gets the flat magic penetration added to the target's stats.
        /// </summary>
        [JsonProperty("rFlatMagicPenetrationMod")]
        public double FlatMagicPenetrationMod { get; set; }

        /// <summary>
        /// Gets the flat magic penetration per level added to the target's stats.
        /// </summary>
        [JsonProperty("rFlatMagicPenetrationModPerLevel")]
        public double FlatMagicPenetrationModPerLevel { get; set; }

        /// <summary>
        /// Gets the flat movement speed per level added to the target's stats.
        /// </summary>
        [JsonProperty("rFlatMovementSpeedModPerLevel")]
        public double FlatMovementSpeedModPerLevel { get; set; }

        /// <summary>
        /// Gets the flat attack damage per level added to the target's stats.
        /// </summary>
        [JsonProperty("rFlatPhysicalDamageModPerLevel")]
        public double FlatPhysicalDamageModPerLevel { get; set; }

        /// <summary>
        /// Gets the flat spell block per level added to the target's stats.
        /// </summary>
        [JsonProperty("rFlatSpellBlockModPerLevel")]
        public double FlatSpellBlockModPerLevel { get; set; }

        /// <summary>
        /// Gets the flat time spent dead subtracted from the target's stats.
        /// </summary>
        [JsonProperty("rFlatTimeDeadMod")]
        public double FlatTimeDeadMod { get; set; }

        /// <summary>
        /// Gets the flat time spent dead per level subtracted from the target's stats.
        /// </summary>
        [JsonProperty("rFlatTimeDeadModPerLevel")]
        public double FlatTimeDeadModPerLevel { get; set; }

        /// <summary>
        /// Gets the percent armor penetration per level added to the target's stats.
        /// </summary>
        [JsonProperty("rPercentArmorPenetrationMod")]
        public double PercentArmorPenetrationMod { get; set; }

        /// <summary>
        /// Gets the percent armor penetration per level added to the target's stats.
        /// </summary>
        [JsonProperty("rPercentArmorPenetrationModPerLevel")]
        public double PercentArmorPenetrationModPerLevel { get; set; }

        /// <summary>
        /// Gets the percent attack speed per level added to the target's stats.
        /// </summary>
        [JsonProperty("rPercentAttackSpeedModPerLevel")]
        public double PercentAttackSpeedModPerLevel { get; set; }

        /// <summary>
        /// Gets the percent cooldown reduction added to the target's stats.
        /// </summary>
        [JsonProperty("rPercentCooldownMod")]
        public double PercentCooldownMod { get; set; }

        /// <summary>
        /// Gets the percent cooldown reduction per level added to the target's stats.
        /// </summary>
        [JsonProperty("rPercentCooldownModPerLevel")]
        public double PercentCooldownModPerLevel { get; set; }

        /// <summary>
        /// Gets the percent magic penetration added to the target's stats.
        /// </summary>
        [JsonProperty("rPercentMagicPenetrationMod")]
        public double PercentMagicPenetrationMod { get; set; }

        /// <summary>
        /// Gets the percent magic penetration per level added to the target's stats.
        /// </summary>
        [JsonProperty("rPercentMagicPenetrationModPerLevel")]
        public double PercentMagicPenetrationModPerLevel { get; set; }

        /// <summary>
        /// Gets the percent movement speed per level added to the target's stats.
        /// </summary>
        [JsonProperty("rPercentMovementSpeedModPerLevel")]
        public double PercentMovementSpeedModPerLevel { get; set; }

        /// <summary>
        /// Gets the percent time spent dead subtracted from the target's stats.
        /// </summary>
        [JsonProperty("rPercentTimeDeadMod")]
        public double PercentTimeDeadMod { get; set; }

        /// <summary>
        /// Gets the percent time spent per level dead subtracted from the target's stats.
        /// </summary>
        [JsonProperty("rPercentTimeDeadModPerLevel")]
        public double PercentTimeDeadModPerLevel { get; set; }

#if DB_READY
        /// <summary>
        /// Gets or sets the ID of the <see cref="BasicDataStats"/>. This does NOT come from the Riot API; it is used as a key when storing this object in a database.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public long Id { get; set; }
#endif
    }
}
