using System;
using System.Collections.Generic;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains mastery list data.
    /// </summary>
    public class MasteryList
    {
        /// <summary>
        /// Gets or sets the basic mastery data.
        /// </summary>
        public BasicData Basic { get; set; }

        /// <summary>
        /// Gets or sets the set of masteries indexed by name.
        /// </summary>
        public Dictionary<string, Mastery> Data { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the game version to which the list applies.
        /// </summary>
        public string Version { get; set; }
    }
}
