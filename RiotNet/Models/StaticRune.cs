using Newtonsoft.Json;

namespace RiotNet.Models
{
    /// <summary>
    /// Represents a rune.
    /// </summary>
    public class StaticRune : BasicData
    {
        /// <summary>
        /// Creates a new <see cref="StaticRune"/> instance.
        /// </summary>
        public StaticRune()
        {
            Rune = new MetaData();
        }

        /// <summary>
        /// Gets or sets the metadata for the rune.
        /// </summary>
        public MetaData Rune { get; set; }

    }
}
