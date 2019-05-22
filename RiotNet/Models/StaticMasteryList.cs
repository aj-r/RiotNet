namespace RiotNet.Models
{
    /// <summary>
    /// Contains mastery list data.
    /// </summary>
    public class StaticMasteryList : StaticDataList<StaticMastery>
    {
        /// <summary>
        /// Creates a new <see cref="StaticMasteryList"/> instance.
        /// </summary>
        public StaticMasteryList()
        {
            Type = "mastery";
        }

        /// <summary>
        /// Gets or sets the mastery tree structure.
        /// </summary>
        public StaticMasteryTree Tree { get; set; }
    }
}
