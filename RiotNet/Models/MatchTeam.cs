using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RiotNet.Models
{
    /// <summary>
    /// This object contains match team information.
    /// </summary>
    public class MatchTeam
    {
        /// <summary>
        /// Gets or sets banned champion data if game was draft mode, otherwise null.
        /// </summary>
        public List<MatchBannedChampion> Bans { get; set; }

        /// <summary>
        /// Gets or sets number of times the team killed baron.
        /// </summary>
        public int BaronKills { get; set; }

        /// <summary>
        /// Gets or sets if game was a dominion game, specifies the points the team had at game end, otherwise null.
        /// </summary>
        public long DominionVictoryScore { get; set; }

        /// <summary>
        /// Gets or sets number of times the team killed dragon.
        /// </summary>
        public int DragonKills { get; set; }

        /// <summary>
        /// Gets or sets flag indicating whether or not the team got the first baron kill.
        /// </summary>
        public bool FirstBaron { get; set; }

        /// <summary>
        /// Gets or sets flag indicating whether or not the team got first blood.
        /// </summary>
        public bool FirstBlood { get; set; }

        /// <summary>
        /// Gets or sets flag indicating whether or not the team got the first dragon kill.
        /// </summary>
        public bool FirstDragon { get; set; }

        /// <summary>
        /// Gets or sets flag indicating whether or not the team destroyed the first inhibitor.
        /// </summary>
        public bool FirstInhibitor { get; set; }

        /// <summary>
        /// Gets or sets flag indicating whether or not the team destroyed the first tower.
        /// </summary>
        public bool FirstTower { get; set; }

        /// <summary>
        /// Gets or sets number of inhibitors the team destroyed.
        /// </summary>
        public int InhibitorKills { get; set; }

        /// <summary>
        /// Gets or sets team ID.
        /// </summary>
        public int TeamId { get; set; }

        /// <summary>
        /// Gets or sets number of towers the team destroyed.
        /// </summary>
        public int TowerKills { get; set; }

        /// <summary>
        /// Gets or sets number of times the team killed vilemaw.
        /// </summary>
        public int VilemawKills { get; set; }

        /// <summary>
        /// Gets or sets flag indicating whether or not the team won.
        /// </summary>
        public bool Winner { get; set; }
    }
}
