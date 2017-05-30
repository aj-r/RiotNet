using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RiotNet.Models
{
    /// <summary>
    /// Represents a mastery slot.
    /// </summary>
    public class StaticMastery
    {
        /// <summary>
        /// Gets or sets the mastery ID.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the description of the mastery at each rank.
        /// </summary>
        public ListOfString Description { get; set; } = new ListOfString();

        /// <summary>
        /// Gets or sets the image data for the mastery's icon.
        /// </summary>
        public Image Image { get; set; } = new Image();

        /// <summary>
        /// Gets or sets the type of mastery tree that the current <see cref="StaticMastery"/> belongs to. This should equal one of the <see cref="MastertyTreeType"/> values.
        /// </summary>
        public string MasteryTree { get; set; }

        /// <summary>
        /// Gets or sets the name of the mastery.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the ID of the mastery that must be filled before any points can be added to the current mastery. A value of zero indicates no prerequisites.
        /// Season 6-7 do not have any masteries with prerequisites.
        /// </summary>
        public int Prereq { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of ranks that the mastery has.
        /// </summary>
        public int Ranks { get; set; }

        /// <summary>
        /// Gets or sets the sanitized description of the mastery at each rank.
        /// </summary>
        public ListOfString SanitizedDescription { get; set; } = new ListOfString();
    }
}
