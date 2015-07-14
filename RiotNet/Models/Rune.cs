using System.Collections.Generic;
using Newtonsoft.Json;

namespace RiotNet.Models
{
    /// <summary>
    /// Represents a rune.
    /// </summary>
    public class Rune
    {
        public string Colloq { get; set; }

        public bool ConsumeOnFull { get; set; }

        public bool Consumed { get; set; }

        public int Depth { get; set; }

        /// <summary>
        /// Gets or sets the description of the rune.
        /// </summary>
        public string Description { get; set; }

        public List<string> From { get; set; }

        /// <summary>
        /// Gets or sets the group to which the rune belongs.
        /// </summary>
        public string Group { get; set; }

        public bool HideFromAll { get; set; }

        /// <summary>
        /// Gets or sets the rune's ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the image data for the current rune.
        /// </summary>
        public Image Image { get; set; }

        /// <summary>
        /// Gets or sets whether the rune exists in the store.
        /// </summary>
        public bool InStore { get; set; }

        public List<string> Into { get; set; }

        public Dictionary<string, bool> Maps { get; set; }

        /// <summary>
        /// Gets or sets the name of the rune.
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
        /// Gets or sets the sanitized description of the rune.
        /// </summary>
        public string SanitizedDescription { get; set; }

        /// <summary>
        /// Gets or sets the special recipe for the rune.
        /// </summary>
        public string SpecialRecipe { get; set; }

        public int Stacks { get; set; }

        /// <summary>
        /// Gets or sets the stats that the rune applies.
        /// </summary>
        public BasicDataStats Stats { get; set; }

        /// <summary>
        /// Gets or sets the tags of the rune.
        /// </summary>
        public List<string> Tags { get; set; }
    }
}
