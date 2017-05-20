using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace RiotNet.Models
{
    /// <summary>
    /// Represents a rune on a player's rune page.
    /// </summary>
    public class Rune
    {
        private long count;

        /// <summary>
        /// Gets or sets number of instances of the rune used on the rune page. This is equal to Rank, but it is set by the Spectator API.
        /// </summary>
        public long Count
        {
            get { return count; }
            set { count = value; }
        }

        /// <summary>
        /// Gets or sets number of instances of the rune used on the rune page. This is equal to Count, but it is set by the Match API.
        /// </summary>
        public long Rank
        {
            get { return count; }
            set { count = value; }
        }

        /// <summary>
        /// Gets or sets rune ID. This corresponds to the ID of a <see cref="StaticRune"/>.
        /// </summary>
        public long RuneId { get; set; }

#if DB_READY
        /// <summary>
        /// Gets or sets the ID of the <see cref="Rune"/>. This does NOT come from the Riot API; it is used as a key when storing this object in a database.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public long DatabaseId { get; set; }
#endif
    }
}
