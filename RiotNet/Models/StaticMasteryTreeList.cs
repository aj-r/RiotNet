using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace RiotNet.Models
{
    /// <summary>
    /// Represents one row in a mastery tree.
    /// </summary>
    public class StaticMasteryTreeList
    {
        /// <summary>
        /// Gets or sets the items in the current <see cref="StaticMasteryTreeList"/>.
        /// </summary>
        public virtual List<StaticMasteryTreeItem> MasteryTreeItems { get; set; }

#if DB_READY
        /// <summary>
        /// Gets or sets the ID of the <see cref="StaticMasteryTreeList"/>. This does NOT come from the Riot API; it is used as a key when storing this object in a database.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public long DatabaseId { get; set; }
#endif
    }
}
