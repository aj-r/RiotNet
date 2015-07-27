using System;
using System.Collections.Generic;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains champion list data.
    /// </summary>
    public class StaticChampionList : StaticDataList
    {
        /// <summary>
        /// Creates a new <see cref="StaticChampionList"/> instance.
        /// </summary>
        public StaticChampionList()
        {
            Type = "champion";
        }

        /// <summary>
        /// Gets or sets the set of champions indexed by name (or ID if you specified dataById in the request).
        /// </summary>
        public Dictionary<string, StaticChampion> Data { get; set; }

        /// <summary>
        /// Gets or sets the format.
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// Gets or sets the keys. This maps champion IDs to champion names.
        /// </summary>
        public Dictionary<string, string> Keys { get; set; }
    }
}
