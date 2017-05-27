using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace RiotNet.Models
{
    /// <summary>
    /// Represents metadata for a rune.
    /// </summary>
    [ComplexType]
    public class MetaData
    {
        /// <summary>
        /// Gets or sets whether the object is a rune.
        /// </summary>
        [DefaultValue(true)]
        public bool IsRune { get; set; } = true;

        /// <summary>
        /// Gets or sets the tier of the rune.
        /// </summary>
        [DefaultValue("1")]
        public string Tier { get; set; } = "1";

        /// <summary>
        /// Gets or sets the type of the rune.
        /// </summary>
        [DefaultValue("red")]
        public string Type { get; set; } = "red";
    }
}
