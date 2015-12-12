using System.Collections.Generic;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains a list of lobby events.
    /// </summary>
    public class LobbyEventWrapper
    {
        /// <summary>
        /// Gets or sets the list of events.
        /// </summary>
        public List<LobbyEvent> EventList { get; set; }
    }
}
