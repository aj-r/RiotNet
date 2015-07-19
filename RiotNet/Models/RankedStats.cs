using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace RiotNet.Models
{
    /// <summary>
    /// This object contains ranked stats information.
    /// </summary>
    public class RankedStats
    {
        /// <summary>
        /// Gets or sets collection of aggregated stats summarized by champion.
        /// </summary>
        public virtual List<ChampionStats> Champions { get; set; }

        /// <summary>
        /// Gets or sets the date stats were last modified specified.
        /// </summary>
        public DateTime ModifyDate { get; set; }

        /// <summary>
        /// Gets or sets the summoner ID.
        /// </summary>
        public long SummonerId { get; set; }

#if DB_READY
        /// <summary>
        /// Gets or sets the ID of the <see cref="RankedStats"/>. This does NOT come from the Riot API; it is used as a key when storing this object in a database.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public long DatabaseId { get; set; }
#endif
    }
}
