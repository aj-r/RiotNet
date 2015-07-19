using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains detailed match information.
    /// </summary>
    public class MatchDetail : MatchSummary
    {
        /// <summary>
        /// Gets or sets team information.
        /// </summary>
        public virtual List<MatchTeam> Teams { get; set; }

        /// <summary>
        /// Gets or sets match timeline data (not included by default)
        /// </summary>
        public virtual Timeline Timeline { get; set; }
    }
}
