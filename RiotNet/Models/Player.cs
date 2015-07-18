using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RiotNet.Models
{
    /// <summary>
    /// Basic info about a player in a game.
    /// </summary>
    public class Player
    {
        /// <summary>
        ///  Gets or sets the champion id associated with player.
        /// </summary>
        public int ChampionId { get; set; }

        /// <summary>
        ///  Gets or sets the summoner id associated with player.
        /// </summary>
        public long SummonerId { get; set; }

        /// <summary>
        ///  Gets or sets the team id associated with player (team 1 or team 2).
        /// </summary>
        public TeamSide TeamId { get; set; }
    }
}
