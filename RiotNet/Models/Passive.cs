using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains champion passive ability data.
    /// </summary>
    public class Passive
    {
        /// <summary>
        /// Gets or sets the description of the passive.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the image data for the passive's icon.
        /// </summary>
        public virtual Image Image { get; set; }

        /// <summary>
        /// Gets or sets the name of the passive.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the sanitized description of the passive.
        /// </summary>
        public string SanitizedDescription { get; set; }

#if DB_READY
        /// <summary>
        /// Gets or sets the ID of the current <see cref="Passive"/>. This does NOT come from the Riot API; it is used as a key when storing this object in a database.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int Id { get; set; }
#endif
    }
}
