namespace RiotNet.Models
{
    /// <summary>
    /// Contains profile icon data.
    /// </summary>
    public class StaticProfileIconData : StaticDataList<StaticProfileIcon>
    {
        /// <summary>
        /// Creates a new <see cref="StaticProfileIconData"/> instance.
        /// </summary>
        public StaticProfileIconData()
        {
            Type = "profileicon";
        }
    }
}
