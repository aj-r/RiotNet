using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains team statistics detail information.
    /// </summary>
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

#if DB_READY
        /// <summary>
        /// Gets or sets the ID of the current <see cref="StaticChampionInfo"/>. This does NOT come from the Riot API; it is used as a key when storing this object in a database.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int Id { get; set; }
#endif
    }
}
