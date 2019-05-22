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
    }
}
