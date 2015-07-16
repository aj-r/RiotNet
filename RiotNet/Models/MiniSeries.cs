using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains information about a promotion series.
    /// </summary>
    public class MiniSeries
    {
        /// <summary>
        /// Gets or sets the number of losses in the current series.
        /// </summary>
        public int Losses { get; set; }

        /// <summary>
        /// Gets or sets a sring showing the current, sequential mini series progress where 'W' represents a win, 'L' represents a loss, and 'N' represents a game that hasn't been played yet.
        /// </summary>
        public string Progress { get; set; }

        /// <summary>
        /// Gets or sets the number of wins required for promotion.
        /// </summary>
        public int Target { get; set; }

        /// <summary>
        /// Gets or sets the number of wins in the current series.
        /// </summary>
        public int Wins { get; set; }

#if DB_READY

        /// <summary>
        /// Gets or sets the ID of the <see cref="MiniSeries"/>. This does NOT come from the Riot API; it is used as a key when storing this object in a database.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public long Id { get; set; }

#endif
    }
}
