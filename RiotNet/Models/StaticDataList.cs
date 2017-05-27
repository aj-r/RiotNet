using System.Collections.Generic;

namespace RiotNet.Models
{
    /// <summary>
    /// The base class for a list of data points.
    /// </summary>
    public class StaticDataList<T>
    {
        /// <summary>
        /// Gets or sets the type of list.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the game version to which the item list applies.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the data indexed by name or ID.
        /// </summary>
        public Dictionary<string, T> Data { get; set; } = new Dictionary<string, T>();
    }
}
