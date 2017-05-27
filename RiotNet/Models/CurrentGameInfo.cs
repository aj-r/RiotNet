using System.Collections.Generic;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains info about a game.
    /// </summary>
    public class CurrentGameInfo : GameInfoBase
    {
        /// <summary>
        /// Gets or sets the participant information.
        /// </summary>
        public List<CurrentGameParticipant> Participants { get; set; }
    }
}
