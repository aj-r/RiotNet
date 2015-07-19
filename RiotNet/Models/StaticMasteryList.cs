using System;
using System.Collections.Generic;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains mastery list data.
    /// </summary>
    public class StaticMasteryList : StaticDataList
    {
        /// <summary>
        /// Creates a new <see cref="StaticMasteryList"/> instance.
        /// </summary>
        public StaticMasteryList()
        {
            Type = "mastery";
        }

        /// <summary>
        /// Gets or sets the mastery tree structure.
        /// </summary>
        public StaticMasteryTree Tree { get; set; }

        /// <summary>
        /// Gets or sets the set of masteries indexed by ID.
        /// </summary>
        public Dictionary<string, StaticMastery> Data { get; set; }
    }
}
