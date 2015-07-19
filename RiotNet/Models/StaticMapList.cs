using System.Collections.Generic;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains data for multiple maps.
    /// </summary>
    public class StaticMapList : StaticDataList
    {
        /// <summary>
        /// Creates a new <see cref="StaticMapList"/> instance.
        /// </summary>
        public StaticMapList()
        {
            Type = "map";
        }

        /// <summary>
        /// Gets or sets the set of maps indexed by ID.
        /// </summary>
        public Dictionary<string, StaticMapDetails> Data { get; set; }
    }
}
