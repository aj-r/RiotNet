using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public Image Image { get; set; } = new Image();

        /// <summary>
        /// Gets or sets the map ID.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long MapId { get; set; }

        /// <summary>
        /// Gets or sets the name of the map.
        /// </summary>
        [Required]
        public string MapName { get; set; }

        /// <summary>
        /// Gets or sets the list of item IDs for items that cannot be purchased on this map. NOTE: the Riot API never seems to set this property, so it is always empty.
        /// </summary>
        public ListOfLong UnpurchasableItemList { get; set; } = new ListOfLong();
    }
}
