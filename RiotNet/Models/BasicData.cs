using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace RiotNet.Models
{
    /// <summary>
    /// Represents an item or rune.
    /// </summary>
    public class BasicData
    {
        public string Colloq { get; set; }

        public bool ConsumeOnFull { get; set; }

        public bool Consumed { get; set; }

        public int Depth { get; set; }

        /// <summary>
        /// Gets or sets the description of the item/rune.
        /// </summary>
        public string Description { get; set; }

        public List<string> From { get; set; }

        /// <summary>
        /// Gold cost information for the item. Does not apply to runes.
        /// </summary>
        public Gold Gold { get; set; }

        /// <summary>
        /// Gets or sets the group to which the item/rune belongs.
        /// </summary>
        public string Group { get; set; }

        public bool HideFromAll { get; set; }

        /// <summary>
        /// Gets or sets the ID of the item or rune.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the image data for the current item/rune.
        /// </summary>
        public Image Image { get; set; }

        /// <summary>
        /// Gets or sets whether the item/rune exists in the store.
        /// </summary>
        public bool InStore { get; set; }

        public List<string> Into { get; set; }

        public Dictionary<string, bool> Maps { get; set; }

        /// <summary>
        /// Gets or sets the name of the item/rune.
        /// </summary>
        public string Name { get; set; }

        public string Plaintext { get; set; }

        public string RequiredChampion { get; set; }

        /// <summary>
        /// Gets or sets the metadata for the rune.
        /// </summary>
        [JsonProperty("Rune")]
        public MetaData RuneMetaData { get; set; }

        /// <summary>
        /// Gets or sets the sanitized description of the item/rune.
        /// </summary>
        public string SanitizedDescription { get; set; }

        /// <summary>
        /// Gets or sets the special recipe for the item.
        /// </summary>
        public string SpecialRecipe { get; set; }

        /// <summary>
        /// Gets or sets the number of stacks on the item, if applicable.
        /// </summary>
        public int Stacks { get; set; }

        /// <summary>
        /// Gets or sets the stats that the item/rune applies.
        /// </summary>
        public BasicDataStats Stats { get; set; }

        /// <summary>
        /// Gets or sets the tags of the item/rune.
        /// </summary>
        public List<string> Tags { get; set; }
    }
}
