namespace RiotNet.Models
{
    /// <summary>
    /// Contains rune list data.
    /// </summary>
    public class StaticRuneList : StaticDataList<StaticRune>
    {
        /// <summary>
        /// Creates a new <see cref="StaticRuneList"/> instance.
        /// </summary>
        public StaticRuneList()
        {
            Type = "rune";
        }

        /// <summary>
        /// Gets or sets the basic rune data, which contains the default values of the rune object.
        /// </summary>
        public StaticRune Basic { get; set; }
    }
}
