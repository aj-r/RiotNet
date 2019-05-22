using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains data for a profile icon.
    /// </summary>
    public class StaticProfileIcon
    {
        /// <summary>
        /// Gets or sets the mastery ID.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the image data.
        /// </summary>
        public Image Image { get; set; } = new Image();
    }
}
