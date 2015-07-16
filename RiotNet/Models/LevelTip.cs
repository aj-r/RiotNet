using System.Collections.Generic;

namespace RiotNet.Models
{
    /// <summary>
    /// Explains what happens when levelling up an ability.
    /// </summary>
    public class LevelTip
    {
        /// <summary>
        /// Gets or sets the effects that change for each rank of the ability.
        /// </summary>
        public List<string> Effect { get; set; }

        /// <summary>
        /// Gets or sets the labels for the corresponding effects that change at each rank of the ability.
        /// </summary>
        public List<string> Label { get; set; }
    }
}
