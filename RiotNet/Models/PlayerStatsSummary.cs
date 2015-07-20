using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RiotNet.Models
{
    /// <summary>
    /// This object contains player stats summary information.
    /// </summary>
    public class PlayerStatsSummary
    {
        /// <summary>
        /// Gets or sets aggregated stats.
        /// </summary>
        public AggregatedStats AggregatedStats { get; set; }

        /// <summary>
        /// Gets or sets number of losses for this queue type. Returned for ranked queue types only.
        /// </summary>
        public int Losses { get; set; }

        /// <summary>
        /// Gets or sets date stats were last modified.
        /// </summary>
        public DateTime ModifyDate { get; set; }

        /// <summary>
        /// Gets or sets player stats summary type.
        /// </summary>
        // TODO: we should be able to use the enum GameMode, except that the strings are slightly different (no underscores...)
        // TODO: create custom converter.
        public GameMode PlayerStatSummaryType { get; set; }

        /// <summary>
        /// Gets or sets number of wins for this queue type.
        /// </summary>
        public int Wins { get; set; }
    }
}
