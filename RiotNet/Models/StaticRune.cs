namespace RiotNet.Models
{
    /// <summary>
    /// Represents a rune.
    /// </summary>
    public class StaticRune : BasicData
    {
        /// <summary>
        /// Gets or sets the metadata for the rune.
        /// </summary>
        public MetaData Rune { get; set; } = new MetaData();

        /// <summary>
        /// Gets or sets the stats that the rune applies.
        /// </summary>
        public RuneDataStats Stats { get; set; } = new RuneDataStats();
    }
}
