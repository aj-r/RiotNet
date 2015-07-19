using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RiotNet.Models
{
    /// <summary>
    /// This object contains information about banned champions, used in match api.
    /// </summary>
    public class MatchBannedChampion
    {
        /// <summary>
        /// Gets or sets banned champion ID.
        /// </summary>
        public int ChampionId { get; set; }

        /// <summary>
        /// Gets or sets turn during which the champion was banned.
        /// </summary>
        public int PickTurn { get; set; }
    }
}
