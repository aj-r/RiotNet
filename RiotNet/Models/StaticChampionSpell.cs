using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using RiotNet.Converters;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains champion spell data.
    /// </summary>
    public class StaticChampionSpell
    {
        /// <summary>
        /// Gets or sets the alternate image data for the current ability.
        /// </summary>
        [JsonProperty("altimages")]
        public virtual List<Image> AltImages { get; set; }

        /// <summary>
        /// Gets or sets the cooldowns of this ability at each rank.
        /// </summary>
        public ListOfDouble Cooldown { get; set; }

        /// <summary>
        /// Gets or sets the cooldown at all ranks merged into a single string.
        /// </summary>
        public string CooldownBurn { get; set; }

        /// <summary>
        /// Gets or sets the mana (or other resource) cost of the ability.
        /// </summary>
        public ListOfInt Cost { get; set; }

        /// <summary>
        /// Gets or sets the cost at all ranks merged into a single string.
        /// </summary>
        public string CostBurn { get; set; }

        /// <summary>
        /// Gets or sets the type of resource that this ability costs.
        /// </summary>
        public string CostType { get; set; }

        /// <summary>
        /// Gets or sets the description of the ability.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the effect of the ability at each rank.
        /// </summary>
        public ListOfListOfDouble Effect { get; set; }

        /// <summary>
        /// Gets or sets the effects at all ranks, merged into a single string for each effect.
        /// </summary>
        public ListOfString EffectBurn { get; set; }

        /// <summary>
        /// Gets or sets the image data for the current ability.
        /// </summary>
        public virtual Image Image { get; set; }

        /// <summary>
        /// Gets or sets the key of the current ability.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets the level-up tooltip of the current ability.
        /// </summary>
        [JsonProperty("leveltip")]
        public LevelTip LevelTip { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of points that a player can put into this ability.
        /// </summary>
        [JsonProperty("maxrank")]
        public int MaxRank { get; set; }

        /// <summary>
        /// Gets or sets the name of the ability.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the range of the spell at each rank. A list with a single entry of 0 indicates that the spell is self-cast.
        /// </summary>
        [JsonConverter(typeof(RangeConverter))]
        public ListOfInt Range { get; set; }

        /// <summary>
        /// Gets or sets the range at all ranks merged into a single string.
        /// </summary>
        public string RangeBurn { get; set; }

        /// <summary>
        /// Gets or sets the cost and type of resource that the ability uses.
        /// </summary>
        public string Resource { get; set; }

        /// <summary>
        /// Gets or sets the sanitized descrption of the ability.
        /// </summary>
        public string SanitizedDescription { get; set; }

        /// <summary>
        /// Gets or sets the sanitized ability tooltip.
        /// </summary>
        public string SanitizedTooltip { get; set; }

        /// <summary>
        /// Gets or sets the ability tooltip.
        /// </summary>
        public string Tooltip { get; set; }

        /// <summary>
        /// Gets or sets the scaling coefficients of the spell.
        /// </summary>
        public virtual List<SpellVars> Vars { get; set; }

#if DB_READY
        /// <summary>
        /// Gets or sets the ID of the current <see cref="StaticChampionSpell"/>. This does NOT come from the Riot API; it is used as a key when storing this object in a database.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int DatabaseId { get; set; }
#endif
    }
}
