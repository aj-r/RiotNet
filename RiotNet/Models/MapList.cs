using System.Collections.Generic;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains data for multiple maps.
    /// </summary>
    public class MapList
    {
        /// <summary>
        /// Gets or sets the set of maps indexed by ID.
        /// </summary>
        public Dictionary<string, MapDetails> Data { get; set; }

        /// <summary>
        /// Gets or sets the type of list.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the game version to which the list applies.
        /// </summary>
        public string Version { get; set; }
    }
}
