using System.Collections.Generic;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains data for multiple maps.
    /// </summary>
    public class MapList : StaticDataList
    {
        /// <summary>
        /// Creates a new <see cref="MapList"/> instance.
        /// </summary>
        public MapList()
        {
            Type = "map";
        }

        /// <summary>
        /// Gets or sets the set of maps indexed by ID.
        /// </summary>
        public Dictionary<string, MapDetails> Data { get; set; }
    }
}
