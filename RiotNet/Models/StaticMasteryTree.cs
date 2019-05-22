using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RiotNet.Models
{
    /// <summary>
    /// Represents a mastery tree.
    /// </summary>
    public class StaticMasteryTree
    {
        /// <summary>
        /// Gets or sets the Cunning mastery tree.
        /// </summary>
        [JsonProperty(nameof(Cunning))]
        public virtual List<StaticMasteryTreeList> Cunning { get; set; }

        /// <summary>
        /// Gets or sets the Ferocity mastery tree.
        /// </summary>
        [JsonProperty(nameof(Ferocity))]
        public virtual List<StaticMasteryTreeList> Ferocity { get; set; }

        /// <summary>
        /// Gets or sets the Resolve mastery tree.
        /// </summary>
        [JsonProperty(nameof(Resolve))]
        public virtual List<StaticMasteryTreeList> Resolve { get; set; }

#if DB_READY
        /// <summary>
        /// Gets or sets the ID of the <see cref="StaticMasteryTree"/>. This does NOT come from the Riot API; it is used as a key when storing this object in a database.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public long DatabaseId { get; set; }
#endif
    }
}
