using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RiotNet.Models
{
    /// <summary>
    /// Represents a group of items in an item page.
    /// </summary>
    public class Block
    {
        /// <summary>
        /// Gets or sets the list of items in this block.
        /// </summary>
        public virtual List<BlockItem> Items { get; set; }

        /// <summary>
        /// Gets or sets a flag that indicates whether to use tutorial formatting when displaying items in the block. If true, all items within the block are separated by a plus sign with the last item being separated by an arrow indicating that the other items build into the last item.
        /// </summary>
        public bool RecMath { get; set; }

        /// <summary>
        /// Gets or sets the type (or internal name) of the block.
        /// </summary>
        public string Type { get; set; }

#if DB_READY
        /// <summary>
        /// Gets or sets the ID of the current <see cref="Block"/>. This does NOT come from the Riot API; it is used as a key when storing this object in a database.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public long DatabaseId { get; set; }
#endif
    }
}
