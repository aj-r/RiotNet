using System.ComponentModel.DataAnnotations.Schema;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains information about a promotion series.
    /// </summary>
    [ComplexType]
    public class MiniSeries
    {
        /// <summary>
        /// Gets or sets the number of losses in the current series.
        /// </summary>
        public int Losses { get; set; }

        /// <summary>
        /// Gets or sets a string showing the current, sequential mini series progress where 'W' represents a win, 'L' represents a loss, and 'N' represents a game that hasn't been played yet.
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
    }
}
