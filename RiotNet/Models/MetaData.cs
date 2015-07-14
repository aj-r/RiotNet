namespace RiotNet.Models
{
    /// <summary>
    /// Represents metadata for a rune.
    /// </summary>
    public class MetaData
    {
        /// <summary>
        /// Gets or sets whether the object is a rune.
        /// </summary>
        public bool IsRune { get; set; }

        /// <summary>
        /// Gets or sets the tier of the rune.
        /// </summary>
        public string Tier { get; set; }

        /// <summary>
        /// Gets or sets the type of the rune.
        /// </summary>
        public string Type { get; set; }
    }
}
