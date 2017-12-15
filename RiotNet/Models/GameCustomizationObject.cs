namespace RiotNet.Models
{
    /// <summary>
    /// Represents game customization data chosen by a participant.
    /// </summary>
    public class GameCustomizationObject
    {
        /// <summary>
        /// Gets or sets the customization category.
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// Gets or sets the customization content.
        /// </summary>
        public string Content { get; set; }
    }
}
