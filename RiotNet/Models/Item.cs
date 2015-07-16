using System.Collections.Generic;

namespace RiotNet.Models
{
    /// <summary>
    /// Represents an item that a player can use during a match.
    /// </summary>
    public class Item : BasicData
    {
        /// <summary>
        /// Gets or sets the effect of the item.
        /// </summary>
        public Dictionary<string, string> Effect { get; set; }
    }
}
