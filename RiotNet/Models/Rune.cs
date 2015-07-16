using Newtonsoft.Json;

namespace RiotNet.Models
{
    /// <summary>
    /// Represents a rune.
    /// </summary>
    public class Rune : BasicData
    {
        /// <summary>
        /// Creates a new <see cref="Rune"/> instance.
        /// </summary>
        public Rune()
        {
            RuneMetaData = new MetaData();
        }

        /// <summary>
        /// Gets or sets the metadata for the rune.
        /// </summary>
        [JsonProperty("rune")]
        public MetaData RuneMetaData { get; set; }

    }
}
