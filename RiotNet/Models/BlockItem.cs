using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public int Id { get; set; }

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
        public long DatabaseId { get; set; }
#endif
    }
}
