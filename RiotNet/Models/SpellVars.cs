using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public ListOfDouble Coeff { get; set; } = new ListOfDouble();

        /// <summary>
        /// Gets or sets the special operator for this spell variable.
        /// </summary>
        public string Dyn { get; set; }

        /// <summary>
        /// Gets or sets the key used to reference this spell variable in calculations.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets the property that the scaling coefficients apply to.
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// Gets or sets the ability with which this spell variable ranks up. If unspecified, it ranks up with the current ability.
        /// </summary>
        public string RanksWith { get; set; }

#if DB_READY
        /// <summary>
        /// Gets or sets the ID of the current <see cref="SpellVars"/>. This does NOT come from the Riot API; it is used as a key when storing this object in a database.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public long DatabaseId { get; set; }
#endif
    }
}
