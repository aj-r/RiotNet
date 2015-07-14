using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains image data.
    /// </summary>
    public class Image
    {
        public string Full { get; set; }

        public string Group { get; set; }

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
