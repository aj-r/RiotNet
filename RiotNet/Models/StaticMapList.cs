namespace RiotNet.Models
{
    /// <summary>
    /// Contains data for multiple maps.
    /// </summary>
    public class StaticMapList : StaticDataList<StaticMapDetails>
    {
        /// <summary>
        /// Creates a new <see cref="StaticMapList"/> instance.
        /// </summary>
        public StaticMapList()
        {
            Type = "map";
        }
    }
}
