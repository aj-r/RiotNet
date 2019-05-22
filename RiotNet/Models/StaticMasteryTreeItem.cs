using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RiotNet.Models
{
    /// <summary>
    /// Represents one item in a mastery tree list.
    /// </summary>
    public class StaticMasteryTreeItem
    {
        /// <summary>
        /// Gets or sets the mastery ID.
        /// </summary>
        public int MasteryId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the mastery that must be filled before any points can be added to the current mastery. A value of zero indicates no prerequisites.
        /// Season 6-7 do not have any masteries with prerequisites.
        /// </summary>
        public int Prereq { get; set; }

#if DB_READY
        /// <summary>
        /// Gets or sets the ID of the <see cref="StaticMasteryTreeItem"/>. This does NOT come from the Riot API; it is used as a key when storing this object in a database.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public long DatabaseId { get; set; }
#endif
    }
}
