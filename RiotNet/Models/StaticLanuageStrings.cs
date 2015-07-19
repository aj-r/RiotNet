using System.Collections.Generic;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains strings in a specified language.
    /// </summary>
    public class StaticLanuageStrings
    {
        /// <summary>
        /// Contains the strings.
        /// </summary>
        public Dictionary<string, string> Data { get; set; }

        /// <summary>
        /// Gets or sets the LanguageStrings type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the game version to which the list applies.
        /// </summary>
        public string Version { get; set; }
    }
}
