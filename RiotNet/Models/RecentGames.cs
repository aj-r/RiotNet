using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotNet.Models
{
    /// <summary>
    /// This object contains recent games information
    /// </summary>
    public class RecentGames
    {
        /// <summary>
        ///  Gets or sets the collection of recent games played by player (max 10).
        /// </summary>
        public List<Game> Games { get; set; }

        /// <summary>
        ///  Gets or sets the summoner ID.
        /// </summary>
        public long SummonerId { get; set; }
    }
}
