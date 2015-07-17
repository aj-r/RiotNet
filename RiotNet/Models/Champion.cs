using System.ComponentModel.DataAnnotations;

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
        /// Gets or sets whether the champion is free to play.
        /// </summary>
        public bool FreeToPlay { get; set; }

        /// <summary>
        /// Gets or sets the champion id (see StaticChampion Id).
        /// </summary>
        [Key]
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the ranked play enabled flag.
        /// </summary>
        public bool RankedPlayEnabled { get; set; }
    }
}
