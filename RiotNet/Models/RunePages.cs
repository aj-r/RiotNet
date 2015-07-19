using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains information about a single summoner's rune pages.
    /// </summary>
    public class RunePages
    {
        /// <summary>
        /// Gets or sets the collection of rune pages of this summoner.
        /// </summary>
        public virtual List<RunePage> Pages { get; set; }

        /// <summary>
        /// Gets or sets the summoner ID of this summoner.
        /// </summary>
        public long SummonerId { get; set; }

#if DB_READY
        /// <summary>
        /// Gets or sets the ID of the <see cref="RunePages"/>. This does NOT come from the Riot API; it is used as a key when storing this object in a database.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public long DatabaseId { get; set; }
#endif
    }
}
