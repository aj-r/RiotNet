using System;
using System.Collections.Generic;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains rune list data.
    /// </summary>
    public class StaticRuneList : StaticDataList
    {
        /// <summary>
        /// Creates a new <see cref="StaticRuneList"/> instance.
        /// </summary>
        public StaticRuneList()
        {
            Type = "rune";
        }

        /// <summary>
        /// Gets or sets the basic rune data, which contains the default values of the rune object.
        /// </summary>
        public BasicData Basic { get; set; }

        /// <summary>
        /// Gets or sets the set of runes indexed by name.
        /// </summary>
        public Dictionary<string, StaticRune> Data { get; set; }
    }
}
