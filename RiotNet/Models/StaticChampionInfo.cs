using System.ComponentModel.DataAnnotations.Schema;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains champion strength and difficulty information.
    /// </summary>
    [ComplexType]
    public class StaticChampionInfo
    {
        /// <summary>
        /// Gets or sets the champion's attack power.
        /// </summary>
        public int Attack { get; set; }

        /// <summary>
        /// Gets or sets the champion's magic power.
        /// </summary>
        public int Magic { get; set; }

        /// <summary>
        /// Gets or sets the champion's defense power.
        /// </summary>
        public int Defense { get; set; }

        /// <summary>
        /// Gets or sets the champion's difficulty.
        /// </summary>
        public int Difficulty { get; set; }
    }
}
