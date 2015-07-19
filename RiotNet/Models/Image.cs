using System.ComponentModel.DataAnnotations.Schema;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains image data.
    /// </summary>
    [ComplexType]
    public class Image
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
    }
}
