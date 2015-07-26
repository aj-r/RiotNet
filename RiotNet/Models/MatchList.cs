using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains a list of matches, with basic match information. Returned when using the Matchlist API. 
    /// The end index of the list may be modified to ensure that there is a maximum of 20 games in the list.
    /// </summary>
    public class MatchList
    {
        /// <summary>
        /// Gets or sets the end index of the match list (<see cref="MatchList.Matches"/>).
        /// The end index may be modified to ensure that there is a maximum of 20 games in the list.
        /// </summary>
        public int EndIndex { get; set; }

        /// <summary>
        /// Gets or sets the list of matches. A maximum of 20 games may be in this list.
        /// </summary>
        public List<MatchReference> Matches { get; set; }

        /// <summary>
        /// Gets or sets the start index for the list of matches.
        /// </summary>
        public int StartIndex { get; set; }

        /// <summary>
        /// Gets or sets the the total number of games in the match list.
        /// </summary>
        public int TotalGames { get; set; }
    }
}
