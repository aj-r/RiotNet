using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains data for a map (e.g. Summoner's Rift).
    /// </summary>
    public class StaticMapDetails
    {
        /// <summary>
        /// Gets or sets data for the map's image.
        /// </summary>
        public virtual StaticImage Image { get; set; }

        /// <summary>
        /// Gets or sets the map ID.
        /// </summary>
        [Key]
        public long MapId { get; set; }

        /// <summary>
        /// Gets or sets the name of the map.
        /// </summary>
        public string MapName { get; set; }

        /// <summary>
        /// Gets or sets the list of item names for items that cannot be purchased on this map.
        /// </summary>
        public ListOfString UnpurchasableItemList { get; set; }
    }
}
