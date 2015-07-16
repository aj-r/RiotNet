using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains spell data for a single rank of a spell.
    /// </summary>
    public class SpellVars
    {
        /// <summary>
        /// Gets or sets the scaling coefficients for the current spell.
        /// </summary>
        public List<double> Coeff { get; set; }

        public string Dyn { get; set; }

        public string Key { get; set; }

        public string Link { get; set; }

        public string RanksWith { get; set; }

#if DB_READY
        /// <summary>
        /// Gets or sets the ID of the current <see cref="Block"/>. This does NOT come from the Riot API; it is used as a key when storing this object in a database.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int Id { get; set; }
#endif
    }
}
