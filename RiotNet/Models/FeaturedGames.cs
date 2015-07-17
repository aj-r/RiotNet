using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains list of featured games.
    /// </summary>
    public class FeaturedGames
    {
        /// <summary>
        ///  Gets or sets the suggested interval to wait before requesting featured games again.
        /// </summary>
        public long ClientRefreshInterval { get; set; }

        /// <summary>
        ///  Gets or sets the list of featured games.
        /// </summary>
        public List<FeaturedGameInfo> GameList { get; set; }
    }
}
