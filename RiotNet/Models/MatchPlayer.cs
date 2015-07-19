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
