using System.Collections.Generic;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains some information on a featured game.
    /// </summary>
    public class FeaturedGameInfo : GameInfoBase
    {
        /// <summary>
        /// Gets or sets the participant information.
        /// </summary>
        public List<Participant> Participants { get; set; }
    }
}
