using System.Collections.Generic;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains data for multiple maps.
    /// </summary>
    public class MapList
    {
        /// <summary>
        /// Gets or sets the set of champions indexed by name.
        /// </summary>
        public Dictionary<string, StaticChampion> Data { get; set; }

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
