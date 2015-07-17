using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotNet.Models
{
    public class MatchHistorySummary
    {
        /// <summary>
        /// Gets or sets the number of assists obtained by the team in this match.
        /// </summary>
        public int Assists { get; set; }

        /// <summary>
        /// Gets or sets the date the match was completed.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the number of deaths obtained by the team in this match.
        /// </summary>
        public int Deaths { get; set; }

        /// <summary>
        /// Gets or sets the Game ID.
        /// </summary>
        public long GameId { get; set; }

        /// <summary>
        /// Gets or sets the game mode of this game.
        /// </summary>
        public GameMode GameMode { get; set; }

        /// <summary>
        /// Gets or sets whether this game resulted in a Loss Prevented for either team.
        /// </summary>
        public bool Invalid { get; set; }

        /// <summary>
        /// Gets or sets the number of kills obtained by the team in this match.
        /// </summary>
        public int Kills { get; set; }

        /// <summary>
        /// Gets or sets the ID of the map this match was played on.
        /// </summary>
        public int MapId { get; set; }

        /// <summary>
        /// Gets or sets the number of kills obtained by the enemy team in this match.
        /// </summary>
        public int OpposingTeamKills { get; set; }

        /// <summary>
        /// Gets or sets the name of the opposing team.
        /// </summary>
        public String OpposingTeamName { get; set; }

        /// <summary>
        /// Gets or sets whether this team won the match.
        /// </summary>
        public bool Win { get; set; }
    }
}
