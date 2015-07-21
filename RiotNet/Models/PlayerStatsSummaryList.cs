using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotNet.Models
{
    /// <summary>
    /// This object contains a collection of player stats summary information. Each one is associated with a different game mode.
    /// </summary>
    public class PlayerStatsSummaryList
    {
        /// <summary>
        /// Gets or sets several collections of player stat summaries associated with the summoner.
        /// </summary>
        public List<PlayerStatsSummary> PlayerStatSummaries { get; set; }

        /// <summary>
        /// Gets or sets the summoner ID.
        /// </summary>
        public long SummonerId { get; set; }
    }
}
