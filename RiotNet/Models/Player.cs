using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

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

#if DB_READY
        /// <summary>
        /// Gets or sets the ID of the current <see cref="Player"/>. This does NOT come from the Riot API; it is used as a key when storing this object in a database.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public long DatabaseId { get; set; }
#endif
    }
}
