using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains roster information.
    /// </summary>
    public class Roster
    {
        /// <summary>
        /// Gets or sets a list of the members of the team.
        /// </summary>
        public List<TeamMemberInfo> MemberList { get; set; }

        /// <summary>
        /// Gets or sets the player ID of the owner of the team.
        /// </summary>
        public long ownerId { get; set; }
    }
}
