using System.Collections.Generic;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains text that explains what happens when levelling up an ability.
    /// </summary>
    public class LevelTip
    {
        /// <summary>
        /// Gets or sets the effect descriptions for each rank of the ability.
        /// </summary>
        public List<string> Effect { get; set; }

        /// <summary>
        /// Gets or sets the labels for each rank of the ability.
        /// </summary>
        public List<string> Label { get; set; }
    }
}
