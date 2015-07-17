using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotNet.Models
{
    public class TeamStatDetail
    {
        /// <summary>
        /// Gets or sets the average games played. This value appears to always be 0.
        /// </summary>
        public int AverageGamesPlayed { get; set; }

        /// <summary>
        /// Gets or sets the number of losses the team has for this ranked queue.
        /// </summary>
        public int Losses { get; set; }

        /// <summary>
        /// Gets or sets the ranked queue type that these stats are for.
        /// </summary>
        public RankedQueue TeamStatType { get; set; }

        /// <summary>
        /// Gets or sets the number of wins the team has for this ranked queue.
        /// </summary>
        public int Wins { get; set; }
    }
}
