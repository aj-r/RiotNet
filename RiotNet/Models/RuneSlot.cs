using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains information about a single rune slot in a rune page.
    /// </summary>
    public class RuneSlot
    {
        /// <summary>
        /// Gets or sets the ID of the rune in this rune slot. This corresponds to the ID of a <see cref="StaticRune"/>.
        /// </summary>
        public int RuneId { get; set; }

        /// <summary>
        /// Gets or sets the ID of this rune slot.
        /// </summary>
        public int RuneSlotId { get; set; }

#if DB_READY
        /// <summary>
        /// Gets or sets the ID of the <see cref="RuneSlot"/>. This does NOT come from the Riot API; it is used as a key when storing this object in a database.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public long DatabaseId { get; set; }
#endif
    }
}
