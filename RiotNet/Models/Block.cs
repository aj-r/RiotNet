using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

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
        public List<BlockItem> Items { get; set; }

        /// <summary>
        /// No idea what this is. Sorry.
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
        public int Id { get; set; }
#endif
    }
}
