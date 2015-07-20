using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace RiotNet.Models
{
    /// <summary>
    /// This object contains a collection of champion stats information.
    /// </summary>
    public class ChampionStats
    {
        /// <summary>
        /// Creates a new <see cref="ChampionStats"/> instance.
        /// </summary>
        public ChampionStats()
        {
            Stats = new AggregatedStats();
        }

        /// <summary>
        /// Gets or sets champion ID. Note that champion ID 0 represents the combined stats for all champions. For static information correlating to champion IDs, please refer to the LoL Static Data API.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets aggregated stats associated with the champion.
        /// </summary>
        public AggregatedStats Stats { get; set; }

#if DB_READY
        /// <summary>
        /// Gets or sets the ID of the <see cref="ChampionStats"/>. This does NOT come from the Riot API; it is used as a key when storing this object in a database.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public long DatabaseId { get; set; }
#endif
    }
}
