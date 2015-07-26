using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains champion data.
    /// </summary>
    public class StaticChampion
    {
        /// <summary>
        /// Creates a new <see cref="StaticChampion"/> instance.
        /// </summary>
        public StaticChampion()
        {
            // ComplexTypes CANNOT be null when saving to the database.
            AllyTips = new ListOfString();
            EnemyTips = new ListOfString();
            Image = new Image();
            Info = new StaticChampionInfo();
            Passive = new Passive();
            Stats = new Stats();
            Tags = new ListOfString();
        }

        /// <summary>
        /// Gets or sets a list of tips for how to play as this champion.
        /// </summary>
        [JsonProperty("allytips")]
        public ListOfString AllyTips { get; set; }

        /// <summary>
        /// Gets or sets the blurb describing the champion.
        /// </summary>
        public string Blurb { get; set; }

        /// <summary>
        /// Gets or sets a list of tips for how to play against this champion.
        /// </summary>
        [JsonProperty("enemytips")]
        public ListOfString EnemyTips { get; set; }

        /// <summary>
        /// Gets or sets the champion ID.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the champion image data.
        /// </summary>
        public Image Image { get; set; }

        /// <summary>
        /// Gets or sets the strength and difficulty information for the current champion.
        /// </summary>
        public StaticChampionInfo Info { get; set; }

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

        /// <summary>
        /// Gets or sets the type of resource this champion uses (e.g. Mana).
        /// </summary>
        [JsonProperty("partype")]
        public string ParType { get; set; }

        /// <summary>
        /// Gets or sets the champion's passive ability.
        /// </summary>
        public Passive Passive { get; set; }

        /// <summary>
        /// Gets or sets the champion's recommended item sets.
        /// </summary>
        public virtual List<Recommended> Recommended { get; set; }

        /// <summary>
        /// Gets or sets the available skins for the champion.
        /// </summary>
        public virtual List<Skin> Skins { get; set; }

        /// <summary>
        /// Gets or sets the champion's spells.
        /// </summary>
        public virtual List<StaticChampionSpell> Spells { get; set; }

        /// <summary>
        /// Gets or sets the champion's stats.
        /// </summary>
        public Stats Stats { get; set; }

        /// <summary>
        /// Gets or sets the champion's roles (e.g. Fighter, Tank).
        /// </summary>
        public ListOfString Tags { get; set; }

        /// <summary>
        /// Gets or sets the champion's title.
        /// </summary>
        public string Title { get; set; }
    }
}
