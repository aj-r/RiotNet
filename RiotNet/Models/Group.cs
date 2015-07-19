using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains item group data, which defines the maximum number of items of a certain type that a player can own.
    /// </summary>
    public class Group
    {
        /// <summary>
        /// Gets or sets the maximum number of items in the current group that a player is allowed to own.
        /// </summary>
        [JsonProperty("MaxGroupOwnable")]
        public string MaxGroupOwnable { get; set; }

        /// <summary>
        /// Gets or sets the name of the group.
        /// </summary>
        public string Key { get; set; }

#if DB_READY
        /// <summary>
        /// Gets or sets the ID of the current <see cref="Group"/>. This does NOT come from the Riot API; it is used as a key when storing this object in a database.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public long DatabaseId { get; set; }
#endif
    }
}
