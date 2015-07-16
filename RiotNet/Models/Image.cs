using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains image data.
    /// </summary>
    public class Image
    {
        public string Full { get; set; }

        public string Group { get; set; }

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

#if DATA_ANNOTATIONS
        /// <summary>
        /// Gets or sets the ID of the <see cref="Image"/>. This does NOT come from the Riot API; it is used as a key when storing this object in a database.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public long Id { get; set; }
#endif
    }
}
