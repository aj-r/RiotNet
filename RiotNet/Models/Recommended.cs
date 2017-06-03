using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RiotNet.Models
{
    /// <summary>
    /// Represents a recommended item set.
    /// </summary>
    public class Recommended
    {
        /// <summary>
        /// Gets or sets the blocks (or groups of items) in this item set.
        /// </summary>
        public virtual List<Block> Blocks { get; set; }

        /// <summary>
        /// Gets or sets the champion name for the current item set.
        /// </summary>
        public string Champion { get; set; }

        /// <summary>
        /// Gets or sets the map for which the current item set applies.
        /// </summary>
        public string Map { get; set; }

        /// <summary>
        /// Gets or sets the game mode for which the current item set applies.
        /// </summary>
        public string Mode { get; set; }

        /// <summary>
        /// Indicates whether this item set takes priority. This appears to be false for all item sets except Ashe's recommended items in the tutorial.
        /// </summary>
        public bool Priority { get; set; }

        /// <summary>
        /// Gets or sets the title of the item set.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the type of item set. This value appears to always equal "riot".
        /// </summary>
        public string Type { get; set; }

#if DB_READY
        /// <summary>
        /// Gets or sets the ID of the current item set. This does NOT come from the Riot API; it is used as a key when storing this object in a database.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public long DatabaseId { get; set; }
#endif
    }
}
