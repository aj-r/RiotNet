using Newtonsoft.Json;
using RiotNet.Converters;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RiotNet.Models
{
    /// <summary>
    /// Represents a team in a particular match.
    /// </summary>
    public class MatchTeam
    {
        /// <summary>
        /// Gets or sets the banned champion data if the game was draft mode. For non-draft games, this will be null.
        /// </summary>
        public virtual List<BannedChampion> Bans { get; set; }

        /// <summary>
        /// Gets or sets the number of times the team killed baron.
        /// </summary>
        public int BaronKills { get; set; }

        /// <summary>
        /// Gets or sets the points the team had at game end if the game was a dominion game, otherwise 0.
        /// </summary>
        public int DominionVictoryScore { get; set; }

        /// <summary>
        /// Gets or sets the number of times the team killed dragon.
        /// </summary>
        public int DragonKills { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating whether or not the team got the first baron kill.
        /// </summary>
        public bool FirstBaron { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating whether or not the team got first blood.
        /// </summary>
        public bool FirstBlood { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating whether or not the team got the first dragon kill.
        /// </summary>
        public bool FirstDragon { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating whether or not the team destroyed the first inhibitor.
        /// </summary>
        public bool FirstInhibitor { get; set; }

        /// <summary>
        /// Gets or sets the number of times the team killed the rift herald.
        /// </summary>
        public bool FirstRiftHerald { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating whether or not the team destroyed the first tower.
        /// </summary>
        public bool FirstTower { get; set; }

        /// <summary>
        /// Gets or sets the number of inhibitors the team destroyed.
        /// </summary>
        public int InhibitorKills { get; set; }

        /// <summary>
        /// Gets or sets the number of times the team killed the rift herald.
        /// </summary>
        public int RiftHeraldKills { get; set; }

        /// <summary>
        /// Gets or sets the team ID.
        /// </summary>
        public TeamSide TeamId { get; set; }

        /// <summary>
        /// Gets or sets the number of towers the team destroyed.
        /// </summary>
        public int TowerKills { get; set; }

        /// <summary>
        /// Gets or sets the number of times the team killed vilemaw.
        /// </summary>
        public int VilemawKills { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating whether or not the team won.
        /// </summary>
        [JsonConverter(typeof(WinStringConverter))]
        public bool Win { get; set; }

#if DB_READY
        /// <summary>
        /// Gets or sets the ID of the <see cref="MatchTeam"/>. This does NOT come from the Riot API; it is used as a key when storing this object in a database.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public long DatabaseId { get; set; }
#endif
    }
}
