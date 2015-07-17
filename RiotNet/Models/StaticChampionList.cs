using System;
using System.Collections.Generic;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains champion list data.
    /// </summary>
    public class StaticChampionList
    {
        /// <summary>
        /// Gets or sets the set of champions indexed by name (or ID if you specified dataById in the request).
        /// </summary>
        public Dictionary<string, StaticChampion> Data { get; set; }

        /// <summary>
        /// Gets or sets the format.
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// Gets or sets the keys.
        /// </summary>
        public Dictionary<string, string> Keys { get; set; }

        /// <summary>
        /// Gets or sets the item type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the game version to which the item list applies.
        /// </summary>
        public string Version { get; set; }
    }
}
