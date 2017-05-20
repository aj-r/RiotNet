using Newtonsoft.Json;
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
        /// Gets or sets the value per minute from the beginning of the game to 10 min.
        /// </summary>
        [JsonProperty("0-10")]
        public double ZeroToTen { get; set; }

        /// <summary>
        /// Gets or sets the value per minute from 10 min to 20 min.
        /// </summary>
        [JsonProperty("10-20")]
        public double TenToTwenty { get; set; }

        /// <summary>
        /// Gets or sets the value per minute from 20 min to 30 min.
        /// </summary>
        [JsonProperty("20-30")]
        public double TwentyToThirty { get; set; }
    }
}
