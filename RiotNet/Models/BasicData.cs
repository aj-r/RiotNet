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
        /// Gets or sets the description of the item/rune.
        /// </summary>
        [DefaultValue("")]
        public string Description { get; set; } = string.Empty;

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
        /// Gets or sets the name of the item/rune.
        /// </summary>
        [Required]
        [DefaultValue("")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the sanitized description of the item/rune.
        /// </summary>
        [DefaultValue("")]
        public string SanitizedDescription { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the tags of the item/rune.
        /// </summary>
        public ListOfString Tags { get; set; } = new ListOfString();
    }
}
