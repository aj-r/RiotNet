using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotNet.Models
{
    public class TeamMemberInfo
    {
        /// <summary>
        /// Gets or sets the date this team member was invited to the team.
        /// </summary>
        public DateTime InviteDate { get; set; }

        /// <summary>
        /// Gets or sets the date this team member joined the team.
        /// </summary>
        public DateTime JoinDate { get; set; }

        /// <summary>
        /// Gets or sets this team member's player ID.
        /// </summary>
        public long PlayerId { get; set; }

        /// <summary>
        /// Gets or sets this team member's status.
        /// </summary>
        public String Status { get; set; }
    }
}
