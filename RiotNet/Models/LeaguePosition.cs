namespace RiotNet.Models
{
    /// <summary>
    /// Contains league participant information representing a summoner. Also contains information about the legue containing this entry.
    /// </summary>
    public class LeaguePosition : LeagueItem
    {
        /// <summary>
        /// Gets or sets the name of the league.
        /// </summary>
        public string LeagueName { get; set; }

        /// <summary>
        /// Gets or sets the league's queue type.
        /// </summary>
        public RankedQueue QueueType { get; set; }

        /// <summary>
        /// Gets or sets the league's tier.
        /// </summary>
        public Tier Tier { get; set; }
    }
}
