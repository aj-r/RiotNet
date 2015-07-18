using System;
using System.Collections.Generic;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains mastery list data.
    /// </summary>
    public class MasteryList : StaticDataList
    {
        /// <summary>
        /// Creates a new <see cref="MasteryList"/> instance.
        /// </summary>
        public MasteryList()
        {
            Type = "mastery";
        }

        /// <summary>
        /// Gets or sets the basic mastery data.
        /// </summary>
        public BasicData Basic { get; set; }

        /// <summary>
        /// Gets or sets the set of masteries indexed by ID.
        /// </summary>
        public Dictionary<string, Mastery> Data { get; set; }
    }
}
