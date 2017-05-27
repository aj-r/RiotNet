using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains champion stats data.
    /// </summary>
    [ComplexType]
    public class Stats
    {
        /// <summary>
        /// Gets or sets the champion's base armor.
        /// </summary>
        public double Armor { get; set; }

        /// <summary>
        /// Gets or sets the champion's armor per level.
        /// </summary>
        [JsonProperty("armorperlevel")]
        public double ArmorPerLevel { get; set; }

        /// <summary>
        /// Gets or sets the champion's base attack damage.
        /// </summary>
        [JsonProperty("attackdamage")]
        public double AttackDamage { get; set; }

        /// <summary>
        /// Gets or sets the champion's attack damage per level.
        /// </summary>
        [JsonProperty("attackdamageperlevel")]
        public double AttackDamagePerLevel { get; set; }

        /// <summary>
        /// Gets or sets the champion's base attack range.
        /// </summary>
        [JsonProperty("attackrange")]
        public double AttackRange { get; set; }

        /// <summary>
        /// Gets or sets the champion's attack speed offset.
        /// </summary>
        [JsonProperty("attacspeedoffset")]
        public double AttackSpeedOffset { get; set; }

        /// <summary>
        /// Gets or sets the champion's attack speed per level.
        /// </summary>
        [JsonProperty("attackspeedperlevel")]
        public double AttackSpeedPerLevel { get; set; }

        /// <summary>
        /// Gets or sets the champion's base critical strike chance.
        /// </summary>
        public double Crit { get; set; }

        /// <summary>
        /// Gets or sets the champion's critical strike chance per level.
        /// </summary>
        [JsonProperty("critperlevel")]
        public double CritPerLevel { get; set; }

        /// <summary>
        /// Gets or sets the champion's base health.
        /// </summary>
        [JsonProperty("hp")]
        public double HP { get; set; }

        /// <summary>
        /// Gets or sets the champion's health per level.
        /// </summary>
        [JsonProperty("hpperlevel")]
        public double HPPerLevel { get; set; }

        /// <summary>
        /// Gets or sets the champion's base health regen.
        /// </summary>
        [JsonProperty("hpregen")]
        public double HPRegen { get; set; }

        /// <summary>
        /// Gets or sets the champion's health regen per level.
        /// </summary>
        [JsonProperty("hpregenperlevel")]
        public double HPRegenPerLevel { get; set; }

        /// <summary>
        /// Gets or sets the champion's base move speed.
        /// </summary>
        [JsonProperty("movespeed")]
        public double MoveSpeed { get; set; }

        /// <summary>
        /// Gets or sets the champion's base mana.
        /// </summary>
        [JsonProperty("mp")]
        public double MP { get; set; }

        /// <summary>
        /// Gets or sets the champion's mana per level.
        /// </summary>
        [JsonProperty("mpperlevel")]
        public double MPPerLevel { get; set; }

        /// <summary>
        /// Gets or sets the champion's base mana regen.
        /// </summary>
        [JsonProperty("mpregen")]
        public double MPRegen { get; set; }

        /// <summary>
        /// Gets or sets the champion's mana regen per level.
        /// </summary>
        [JsonProperty("mpregenperlevel")]
        public double MPRegenPerLevel { get; set; }

        /// <summary>
        /// Gets or sets the champion's base magic resist.
        /// </summary>
        [JsonProperty("spellblock")]
        public double SpellBlock { get; set; }

        /// <summary>
        /// Gets or sets the champion's magic resist per level.
        /// </summary>
        [JsonProperty("spellblockperlevel")]
        public double SpellBlockPerLevel { get; set; }
    }
}
