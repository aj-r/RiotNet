using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotNet.Models
{
    /// <summary>
    /// The base class for a list of data points.
    /// </summary>
    public class StaticDataList
    {
        /// <summary>
        /// Gets or sets the type of list.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the game version to which the item list applies.
        /// </summary>
        public string Version { get; set; }
    }
}
