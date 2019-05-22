using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains champion spell data.
    /// </summary>
    public class StaticChampionSpell : StaticSpell
    {
        /// <summary>
        /// Gets or sets the alternate image data for the current ability.
        /// </summary>
        [JsonProperty("altimages")]
        public virtual List<AltImage> AltImages { get; set; }

#if DB_READY
        /// <summary>
        /// Gets or sets the ID of the current <see cref="StaticChampionSpell"/>. This does NOT come from the Riot API; it is used as a key when storing this object in a database.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public long DatabaseId { get; set; }
#endif
    }
}
