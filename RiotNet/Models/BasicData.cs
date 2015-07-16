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
        /// <summary>
        /// Creates a new <see cref="BasicData"/> instance.
        /// </summary>
        public BasicData()
        {
            // Note: default values are defined in the "basic" property of an ItemList or RuneList.
            Colloq = string.Empty;
            Description = string.Empty;
            Group = string.Empty;
            Maps = new Dictionary<string, bool>
            { 
                { "1", true },
                { "8", true },
                { "10", true },
                { "12", true },
            };
            Name = string.Empty;
            PlainText = string.Empty;
            SanitizedDescription = string.Empty;
            Stacks = 1;
            Stats = new BasicDataStats();
            Tags = new List<string>();
        }

        /// <summary>
        /// Gets or sets a semicolon-separated list of abbreviations that can be used for searching for the item.
        /// </summary>
        public string Colloq { get; set; }

        /// <summary>
        /// Gets or sets the description of the item/rune.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the group to which the item/rune belongs.
        /// </summary>
        public string Group { get; set; }

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
        /// Gets or sets the maps that the item is used on, indexed by map ID.
        /// </summary>
        public Dictionary<string, bool> Maps { get; set; }

        /// <summary>
        /// Gets or sets the name of the item/rune.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the plain text of the item/rune.
        /// </summary>
        [JsonProperty("plaintext")]
        public string PlainText { get; set; }

        /// <summary>
        /// Gets or sets the name of the only champion that is allowed to have this item.
        /// </summary>
        public string RequiredChampion { get; set; }

        /// <summary>
        /// Gets or sets the sanitized description of the item/rune.
        /// </summary>
        public string SanitizedDescription { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of instances of this item that can exist in a single inventory slot.
        /// </summary>
        /// <remarks>
        /// Some items have a "stacks" value of 0. I'm not sure why, but I think 0 should be treated as if it was 1.
        /// </remarks>
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
