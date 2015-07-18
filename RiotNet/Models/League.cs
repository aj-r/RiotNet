using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace RiotNet.Models
{
    /// <summary>
    /// Represents a ranked league.
    /// </summary>
    public class League
    {
        /// <summary>
        /// Gets or sets the entries for all participants in the league.
        /// </summary>
        public virtual List<LeagueEntry> Entries { get; set; }

        /// <summary>
        /// Gets or sets the name of the league. This is an internal place-holder name only.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the ID of the relevant participant that is a member of this league (i.e., a requested summoner ID, a requested team ID,
        /// or the ID of a team to which one of the requested summoners belongs). Only present when full league is requested so that participant's
        /// entry can be identified. Not present when individual entry is requested.
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
        public long Id { get; set; }
#endif
    }
}
