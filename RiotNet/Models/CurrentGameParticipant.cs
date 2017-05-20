using System.Collections.Generic;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains information about a participant in a game that is in progress (or was in progress at the time the data was retrieved).
    /// </summary>
    public class CurrentGameParticipant : Participant
    {
        /// <summary>
        ///  Gets or sets the list of masteries used by this participant.
        /// </summary>
        public virtual List<Mastery> Masteries { get; set; }

        /// <summary>
        ///  Gets or sets the list of runes used by this participant.
        /// </summary>
        public virtual List<Rune> Runes { get; set; }

        /// <summary>
        ///  Gets or sets the summoner ID of this participant.
        /// </summary>
        public long SummonerId { get; set; }
    }
}
