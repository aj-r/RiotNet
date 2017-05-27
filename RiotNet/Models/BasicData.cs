using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RiotNet.Models
{
    /// <summary>
    /// Represents an item or rune.
    /// </summary>
    public class BasicData
    {
        /// <summary>
        /// Gets or sets a semicolon-separated list of abbreviations that can be used for searching for the item.
        /// </summary>
        [DefaultValue("")]
        public string Colloq { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the description of the item/rune.
        /// </summary>
        [DefaultValue("")]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the group to which the item/rune belongs.
        /// </summary>
        [DefaultValue("")]
        public string Group { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the ID of the item or rune.
        /// </summary>
        /// <remarks>
        /// This property is used as the primary key when storing the current object in a database.
        /// </remarks>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the image data for the current item/rune.
        /// </summary>
        public Image Image { get; set; } = new Image();

        /// <summary>
        /// Gets or sets the maps that the item is used on, indexed by map ID.
        /// </summary>
        public DictionaryOfBoolean Maps { get; set; } = new DictionaryOfBoolean
        {
            { "1", true },
            { "8", true },
            { "10", true },
            { "12", true },
        };

        /// <summary>
        /// Gets or sets the name of the item/rune.
        /// </summary>
        [Required]
        [DefaultValue("")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the plain text of the item/rune.
        /// </summary>
        [DefaultValue("")]
        [JsonProperty("plaintext")]
        public string PlainText { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the name of the only champion that is allowed to have this item.
        /// </summary>
        [DefaultValue("")]
        public string RequiredChampion { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the sanitized description of the item/rune.
        /// </summary>
        [DefaultValue("")]
        public string SanitizedDescription { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the maximum number of instances of this item that can exist in a single inventory slot.
        /// </summary>
        /// <remarks>
        /// Some items have a "stacks" value of 0. I'm not sure why, but I think 0 should be treated as if it was 1.
        /// </remarks>
        [DefaultValue(1)]
        public int Stacks { get; set; } = 1;

        /// <summary>
        /// Gets or sets the tags of the item/rune.
        /// </summary>
        public ListOfString Tags { get; set; } = new ListOfString();
    }
}
