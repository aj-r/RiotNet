using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RiotNet.Models
{
    /// <summary>
    /// This object contains match player information.
    /// </summary>
    public class MatchPlayer
    {
        /// <summary>
        /// Gets or sets match history URI.
        /// </summary>
        public string MatchHistoryUri { get; set; }

        /// <summary>
        /// Gets or sets profile icon ID.
        /// </summary>
        public int ProfileIcon { get; set; }

        /// <summary>
        /// Gets or sets summoner ID.
        /// </summary>
        public long SummonerId { get; set; }

        /// <summary>
        /// Gets or sets summoner name.
        /// </summary>
        public string SummonerName { get; set; }
    }
}
