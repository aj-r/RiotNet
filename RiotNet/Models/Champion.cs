using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains champion data.
    /// </summary>
    public class Champion
    {
        /// <summary>
        /// Gets or sets whether the champion is active.
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets whether the champion bot is enabled (for custom games).
        /// </summary>
        public bool BotEnabled { get; set; }

        /// <summary>
        /// Gets or sets whether the champion bot is enabled for match-made games (Co-op vs. AI).
        /// </summary>
        public bool BotMmEnabled { get; set; }

        /// <summary>
        /// Gets or sets whether the champion is currently free to play.
        /// </summary>
        public bool FreeToPlay { get; set; }

        /// <summary>
        /// Gets or sets the champion id. This corresponds to a <see cref="StaticChampion"/> ID.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the ranked play enabled flag.
        /// </summary>
        public bool RankedPlayEnabled { get; set; }
    }
}
