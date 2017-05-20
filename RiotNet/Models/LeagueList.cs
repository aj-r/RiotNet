using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace RiotNet.Models
{
    /// <summary>
    /// Represents a ranked league.
    /// </summary>
    public class LeagueList
    {
        /// <summary>
        /// Gets or sets the entries for all participants in the league.
        /// </summary>
        public virtual List<LeagueItem> Entries { get; set; }

        /// <summary>
        /// Gets or sets the name of the league.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the summoner ID of the relevant participant that is a member of this league.
        /// </summary>
        public string ParticipantId { get; set; }

        /// <summary>
        /// Gets or sets the league's queue type.
        /// </summary>
        public RankedQueue Queue { get; set; }

        /// <summary>
        /// Gets or sets the league's tier.
        /// </summary>
        public Tier Tier { get; set; }

#if DB_READY
        /// <summary>
        /// Gets or sets the ID of the league. This does NOT come from the Riot API; it is used as a key when storing this object in a database.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public long DatabaseId { get; set; }
#endif
    }
}
