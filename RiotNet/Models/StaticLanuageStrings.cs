namespace RiotNet.Models
{
    /// <summary>
    /// Contains strings in a specified language.
    /// </summary>
    public class StaticLanuageStrings : StaticDataList<string>
    {
        /// <summary>
        /// Creates a new <see cref="StaticLanuageStrings"/> instance.
        /// </summary>
        public StaticLanuageStrings()
        {
            Type = "language";
        }
    }
}
