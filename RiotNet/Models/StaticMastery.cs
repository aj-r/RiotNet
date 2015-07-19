using System.ComponentModel.DataAnnotations;

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
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the description of the mastery at each rank.
        /// </summary>
        public ListOfString Description { get; set; }

        /// <summary>
        /// Gets or sets the image data for the mastery's icon.
        /// </summary>
        public virtual StaticImage Image { get; set; }

        /// <summary>
        /// Gets or sets the type of mastery tree that the current <see cref="StaticMastery"/> belongs to.
        /// </summary>
        public MastertyTreeType MasteryTree { get; set; }

        /// <summary>
        /// Gets or sets the name of the mastery.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the ID of the mastery that must be filled before any points can be added to the current mastery. A value of zero indicates no prerequisites.
        /// </summary>
        public int Prereq { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of ranks that the mastery has.
        /// </summary>
        public int Ranks { get; set; }

        /// <summary>
        /// Gets or sets the sanitized description of the mastery at each rank.
        /// </summary>
        public ListOfString SanitizedDescription { get; set; }
    }
}
