using System.ComponentModel.DataAnnotations.Schema;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains champion passive ability data.
    /// </summary>
    [ComplexType]
    public class Passive
    {
        /// <summary>
        /// Gets or sets the description of the passive.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the image data for the passive's icon.
        /// </summary>
        public Image Image { get; set; } = new Image();

        /// <summary>
        /// Gets or sets the name of the passive.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the sanitized description of the passive.
        /// </summary>
        public string SanitizedDescription { get; set; }
    }
}
