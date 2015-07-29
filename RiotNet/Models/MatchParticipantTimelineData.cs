using System.ComponentModel.DataAnnotations.Schema;

namespace RiotNet.Models
{
    /// <summary>
    /// This object contains timeline data.
    /// </summary>
    [ComplexType]
    public class MatchParticipantTimelineData
    {
        /// <summary>
        /// Gets or sets the value per minute from 10 min to 20 min.
        /// </summary>
        public double TenToTwenty { get; set; }

        /// <summary>
        /// Gets or sets the value per minute from 30 min to the end of the game.
        /// </summary>
        public double ThirtyToEnd { get; set; }

        /// <summary>
        /// Gets or sets the value per minute from 20 min to 30 min.
        /// </summary>
        public double TwentyToThirty { get; set; }

        /// <summary>
        /// Gets or sets the value per minute from the beginning of the game to 10 min.
        /// </summary>
        public double ZeroToTen { get; set; }
    }
}
