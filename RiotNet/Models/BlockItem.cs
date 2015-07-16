using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace RiotNet.Models
{
    /// <summary>
    /// Represents an item on an item page.
    /// </summary>
    public class BlockItem
    {
        /// <summary>
        /// Gets or sets the ID of the item in this slot.
        /// </summary>
        [JsonProperty("id")]
        public int ItemId { get; set; }

        /// <summary>
        /// Gets or sets the count of the specified item that is in this slot.
        /// </summary>
        public int Count { get; set; }

#if DB_READY
        /// <summary>
        /// Gets or sets the ID of the current <see cref="BlockItem"/>. This does NOT come from the Riot API; it is used as a key when storing this object in a database.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int BlockItemId { get; set; }
#endif
    }
}
