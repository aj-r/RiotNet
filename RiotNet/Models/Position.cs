using System.ComponentModel.DataAnnotations.Schema;

namespace RiotNet.Models
{
    /// <summary>
    /// This object contains participant frame position information.
    /// </summary>
    [ComplexType]
    public class Position
    {
        /// <summary>
        /// Gets or sets participant X position.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Gets or sets participant Y position.
        /// </summary>
        public int Y { get; set; }
    }
}
