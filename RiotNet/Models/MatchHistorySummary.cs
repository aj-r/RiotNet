using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains match history summary information.
    /// </summary>
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

#if DB_READY
        /// <summary>
        /// Gets or sets the ID of the current <see cref="MatchHistorySummary"/>. This does NOT come from the Riot API; it is used as a key when storing this object in a database.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int DatabaseId { get; set; }
#endif
    }
}
