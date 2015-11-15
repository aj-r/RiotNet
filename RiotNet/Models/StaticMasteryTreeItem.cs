namespace RiotNet.Models
{
    /// <summary>
    /// Represents one item in a mastery tree list.
    /// </summary>
    public class StaticMasteryTreeItem
    {
        /// <summary>
        /// Gets or sets the mastery ID.
        /// </summary>
        public int MasteryId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the mastery that must be filled before any points can be added to the current mastery. A value of zero indicates no prerequisites.
        /// Season 6 does not have any masteries with prerequisites.
        /// </summary>
        public int Prereq { get; set; }
    }
}
