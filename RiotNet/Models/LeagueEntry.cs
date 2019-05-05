namespace RiotNet.Models
{
    /// <summary>
    /// Contains a summoner's rank information.
    /// </summary>
    public class LeagueEntry : LeagueItem
    {
        /// <summary>
        /// Gets or sets the ID of the league.
        /// NOTE: this value will not be set by GetLeagueEntriesAsync(), but it may be set in the future.
        /// </summary>
        public string LeagueId { get; set; }

        /// <summary>
        /// Gets or sets the league's queue type. This should equal one of the <see cref="RankedQueue"/> values.
        /// </summary>
        public string QueueType { get; set; }

        /// <summary>
        /// Gets or sets the league's tier. This should equal one of the <see cref="Models.Tier"/> values.
        /// </summary>
        public string Tier { get; set; }
    }
}
