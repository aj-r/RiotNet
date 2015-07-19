using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RiotNet.Models
{
    /// <summary>
    /// This object contains rune information.
    /// </summary>
    public class Rune
    {
        /// <summary>
        /// Gets or sets rune rank (number of that rune used).
        /// </summary>
        public long Rank { get; set; }

        /// <summary>
        /// Gets or sets rune ID.
        /// </summary>
        public long RuneId { get; set; }
    }
}
