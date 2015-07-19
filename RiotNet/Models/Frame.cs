using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RiotNet.Models
{
    /// <summary>
    /// This object contains game frame information.
    /// </summary>
    public class Frame
    {
        /// <summary>
        /// Gets or sets list of events for this frame.
        /// </summary>
        public List<Event> Events { get; set; }

        /// <summary>
        /// Gets or sets map of each participant ID to the participant's information for the frame.
        /// </summary>
        public Dictionary<string, MatchParticipantFrame> ParticipantFrames { get; set; }

        /// <summary>
        /// Gets or sets represents how many milliseconds into the game the frame occurred.
        /// </summary>
        public long Timestamp { get; set; }
    }
}
