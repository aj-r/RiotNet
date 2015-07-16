using System;
using System.Collections.Generic;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains rune list data.
    /// </summary>
    public class RuneList
    {
        /// <summary>
        /// Creates a new <see cref="RuneList"/> instance.
        /// </summary>
        public RuneList()
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
        public Dictionary<string, Rune> Data { get; set; }

        /// <summary>
        /// Gets or sets the type of list. This is probably always equal to "rune".
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the game version to which the list applies.
        /// </summary>
        public string Version { get; set; }
    }
}
