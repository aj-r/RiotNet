using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace RiotNet.Models
{
    /// <summary>
    /// Represents metadata for a rune.
    /// </summary>
    [ComplexType]
    public class MetaData
    {
        /// <summary>
        /// Creates a new <see cref="MetaData"/> instance.
        /// </summary>
        public MetaData()
        {
            // Note: default values are defined in the "basic" property of an ItemList or RuneList.
            IsRune = true;
            Tier = "1";
            Type = "Red";
        }

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
