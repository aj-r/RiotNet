using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RiotNet.Models
{
    /// <summary>
    /// This object contains a collection of champion stats information.
    /// </summary>
    public class ChampionStats
    {
        /// <summary>
        /// Gets or sets champion ID. Note that champion ID 0 represents the combined stats for all champions. For static information correlating to champion IDs, please refer to the LoL Static Data API.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets aggregated stats associated with the champion.
        /// </summary>
        public AggregatedStats Stats { get; set; }
    }
}
