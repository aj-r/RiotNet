using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

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
        public virtual List<TeamMemberInfo> MemberList { get; set; }

        /// <summary>
        /// Gets or sets the player ID of the owner of the team.
        /// </summary>
        public long OwnerId { get; set; }

#if DB_READY
        /// <summary>
        /// Gets or sets the ID of the current <see cref="Roster"/>. This does NOT come from the Riot API; it is used as a key when storing this object in a database.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int DatabaseId { get; set; }
#endif
    }
}
