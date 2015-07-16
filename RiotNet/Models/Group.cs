namespace RiotNet.Models
{
    /// <summary>
    /// Contains item group data, which defines the maximum number of items of a certain type that a player can own.
    /// </summary>
    public class Group
    {
        /// <summary>
        /// Gets or sets the maximum number of items in the current group that a player is allowed to own.
        /// </summary>
        public string MaxGroupOwnable { get; set; }

        /// <summary>
        /// Gets or sets the name of the group.
        /// </summary>
        public string Key { get; set; }
    }
}
