using System.ComponentModel.DataAnnotations.Schema;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains information on the perks (runes) chosen by a participant in a match.
    /// </summary>
    [ComplexType]
    public class Perks
    {
        /// <summary>
        /// Gets or sets the main perk style chosen.
        /// </summary>
        public long PerkStyle { get; set; }
        /// <summary>
        /// Gets or sets the chosen perk IDs.
        /// </summary>
        public ListOfLong PerkIds { get; set; } = new ListOfLong();
        /// <summary>
        ///  Gets or sets the perk sub-style chosen.
        /// </summary>
        public long PerkSubStyle { get; set; }
    }
}
