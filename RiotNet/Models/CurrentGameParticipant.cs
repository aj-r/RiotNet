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
        public Perks Perks { get; set; } = new Perks();

        /// <summary>
        /// Gets or sets the list of customizations chosen by this participant.
        /// </summary>
        public List<GameCustomizationObject> GameCustomizationObjects { get; set; } = new List<GameCustomizationObject>();

        /// <summary>
        ///  Gets or sets the summoner ID of this participant.
        /// </summary>
        public long SummonerId { get; set; }
    }
}
