using System.ComponentModel.DataAnnotations;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains champion skin data.
    /// </summary>
    public class Skin
    {
        /// <summary>
        /// Gets or sets the skin ID.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the skin name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the skin number.
        /// </summary>
        public int Num { get; set; }
    }
}
