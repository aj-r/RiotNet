using System.Collections.Generic;

namespace RiotNet.Models
{
    /// <summary>
    /// This object contains player match history information. The maximum range for begin and end index is 15. If the range is more than 15, the end index will be modified to enforce the 15 game limit. If only one of the index parameters is specified, the other will be computed accordingly.
    /// </summary>
    internal class PlayerHistory
    {
        /// <summary>
        /// Gets or sets list of matches for the player.
        /// </summary>
        public List<MatchSummary> Matches { get; set; }
    }
}
