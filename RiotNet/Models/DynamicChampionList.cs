using System;
using System.Collections.Generic;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains a list of dynamic champion data.
    /// </summary>
    internal class DynamicChampionList
    {
        /// <summary>
        /// Gets or sets the list of champions.
        /// </summary>
        public List<DynamicChampion> Champions { get; set; }
    }
}
