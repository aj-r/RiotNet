namespace RiotNet.Models
{
    /// <summary>
    /// Contains league participant information representing a summoner. Also contains information about the legue containing this entry.
    /// </summary>
    public class LeaguePosition : LeagueItem
    {
        /// <summary>
        /// Gets or sets the ID of the league.
        /// </summary>
        public string LeagueId { get; set; }

        /// <summary>
        /// Gets or sets the name of the league.
        /// </summary>
        public string LeagueName { get; set; }

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
