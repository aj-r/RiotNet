using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains champion strength and difficulty information.
    /// </summary>
    public class StaticChampionInfo
    {
        /// <summary>
        /// Gets or sets the champion's attack power.
        /// </summary>
        public int Attack { get; set; }

        /// <summary>
        /// Gets or sets the champion's magic power.
        /// </summary>
        public int Magic { get; set; }

        /// <summary>
        /// Gets or sets the champion's defense power.
        /// </summary>
        public int Defence { get; set; }

        /// <summary>
        /// Gets or sets the champion's difficulty.
        /// </summary>
        public int Difficulty { get; set; }

#if DB_READY
        /// <summary>
        /// Gets or sets the ID of the current <see cref="StaticChampionInfo"/>. This does NOT come from the Riot API; it is used as a key when storing this object in a database.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int Id { get; set; }
#endif
    }
}
