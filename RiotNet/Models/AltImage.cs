using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace RiotNet.Models
{
    // Note: unfortunately we cannot inherit from Image here because it is configured as a [ComplexType], and AltImage needs to NOT be a [ComplexType].

    /// <summary>
    /// Contains alternate image data.
    /// </summary>
    public class AltImage
    {
        /// <summary>
        /// Gets or sets the file name of the full-size image.
        /// </summary>
        public string Full { get; set; }

        /// <summary>
        /// Gets or sets the group to which the image belongs.
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// Gets or sets the file name of the sprite image.
        /// </summary>
        public string Sprite { get; set; }

        /// <summary>
        /// Gets or sets the x-offset of the image.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Gets or sets the y-offset of the image.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Gets or sets the width of the image.
        /// </summary>
        public int W { get; set; }

        /// <summary>
        /// Gets or sets the height of the image.
        /// </summary>
        public int H { get; set; }

#if DB_READY
        /// <summary>
        /// Gets or sets the ID of the <see cref="AltImage"/>. This does NOT come from the Riot API; it is used as a key when storing this object in a database.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public long DatabaseId { get; set; }
#endif
    }
}
