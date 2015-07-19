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
    /// Contains information about a single mastery in a mastery page.
    /// </summary>
    public class Mastery
    {
        /// <summary>
        /// Gets or sets the ID of this mastery.
        /// For static information regarding masteries, please refer to the Static Data API.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the number of mastery points put into this mastery.
        /// </summary>
        public int Rank { get; set; }

#if DB_READY
        /// <summary>
        /// Gets or sets the ID of the <see cref="Mastery"/>. This does NOT come from the Riot API; it is used as a key when storing this object in a database.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public long DatabaseId { get; set; }
#endif
    }
}
