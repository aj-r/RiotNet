using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains champion data.
    /// </summary>
    public class Champion
    {
        [JsonProperty("allytips")]
        public List<string> AllyTips { get; set; }

        /// <summary>
        /// Gets or sets the blurb describing the champion.
        /// </summary>
        public string Blurb { get; set; }

        [JsonProperty("enemytips")]
        public List<string> EnemyTips { get; set; }

        /// <summary>
        /// Gets or sets the champion ID.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the champion image data.
        /// </summary>
        public Image Image { get; set; }

        /// <summary>
        /// Gets or sets the strength and difficulty information for the current champion.
        /// </summary>
        public ChampionInfo Info { get; set; }

        /// <summary>
        /// Gets or sets the champion key.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets the champion's lore text.
        /// </summary>
        public string Lore { get; set; }

        /// <summary>
        /// Gets or sets the champion name.
        /// </summary>
        public string Name { get; set; }

        [JsonProperty("partype")]
        public string ParType { get; set; }

        /// <summary>
        /// Gets or sets the champion's passive ability.
        /// </summary>
        public Passive Passive { get; set; }

        /// <summary>
        /// Gets or sets the champion's recommended item sets.
        /// </summary>
        public List<Recommended> Recommended { get; set; }

        /// <summary>
        /// Gets or sets the available skins for the champion.
        /// </summary>
        public List<Skin> Skins { get; set; }

        /// <summary>
        /// Gets or sets the champion's spells.
        /// </summary>
        public List<ChampionSpell> Spells { get; set; }

        /// <summary>
        /// Gets or sets the champion's stats.
        /// </summary>
        public Stats Stats { get; set; }

        /// <summary>
        /// Gets or sets the champion's tags.
        /// </summary>
        public List<string> Tags { get; set; }

        /// <summary>
        /// Gets or sets the champion's title.
        /// </summary>
        public string Title { get; set; }
    }
}
