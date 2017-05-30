using System.ComponentModel.DataAnnotations.Schema;

namespace RiotNet.Models
{
    /// <summary>
    /// This object contains match player information.
    /// </summary>
    [ComplexType]
    public class MatchPlayer
    {
        /// <summary>
        /// Gets or sets the platform ID of the player's account. This should equal one of the <see cref="Models.PlatformId"/> values.
        /// </summary>
        public string CurrentPlatformId { get; set; }

        /// <summary>
        /// Gets or sets the platform ID of the player's account. This should equal one of the <see cref="Models.PlatformId"/> values.
        /// </summary>
        /// <remarks>
        /// For old North America accounts, this may equal "NA" instead of "NA1".
        /// </remarks>
        public string PlatformId { get; set; }

        /// <summary>
        /// Gets or sets the player's account ID.
        /// </summary>
        public long CurrentAccountId { get; set; }

        /// <summary>
        /// Gets or sets the player's account ID.
        /// </summary>
        public long AccountId { get; set; }

        /// <summary>
        /// Gets or sets the match history URI.
        /// </summary>
        public string MatchHistoryUri { get; set; }

        /// <summary>
        /// Gets or sets the profile icon ID.
        /// </summary>
        public int ProfileIcon { get; set; }

        /// <summary>
        /// Gets or sets the summoner ID.
        /// </summary>
        public long SummonerId { get; set; }

        /// <summary>
        /// Gets or sets the summoner name.
        /// </summary>
        public string SummonerName { get; set; }
    }
}
