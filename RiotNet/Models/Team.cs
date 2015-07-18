using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains team information.
    /// </summary>
    public class Team
    {
        /// <summary>
        /// Gets or sets the date the team was created.
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Gets or sets the full ID of the team; format: "TEAM-[-0-9a-f]*"
        /// </summary>
        public String FullId { get; set; }

        /// <summary>
        /// Gets or sets the date the last game played by the team ended.
        /// </summary>
        public DateTime LastGameDate { get; set; }

        /// <summary>
        /// Gets or sets the most recent date a team member was added to the team.
        /// </summary>
        public DateTime LastJoinDate { get; set; }

        /// <summary>
        /// Gets or sets the date the team last joined the ranked team queue.
        /// </summary>
        public DateTime LastJoinedRankedTeamQueueDate { get; set; }

        /// <summary>
        /// Gets or sets the match history of the team.
        /// </summary>
        public virtual List<MatchHistorySummary> MatchHistory { get; set; }

        /// <summary>
        /// Gets or sets the date the team was last modified.
        /// </summary>
        public DateTime ModifyDate { get; set; }

        /// <summary>
        /// Gets or sets the name of the team.
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// Gets or sets the team roster.
        /// </summary>
        public virtual Roster Roster { get; set; }

        /// <summary>
        /// Gets or sets the date the second most recent date a team member was added to the team.
        /// </summary>
        public DateTime SecondLastJoinDate { get; set; }

        /// <summary>
        /// Gets or sets the status of the team.
        /// </summary>
        public String Status { get; set; }

        /// <summary>
        /// Gets or sets the team tag.
        /// </summary>
        public String Tag { get; set; }

        /// <summary>
        /// Gets or sets the team's statistics for each type of team ranked queue.
        /// </summary>
        public virtual List<TeamStatDetail> TeamStatDetails { get; set; }

        /// <summary>
        /// Gets or sets the date the third most recent date a team member was added to the team.
        /// </summary>
        public DateTime ThirdLastJoinDate { get; set; }

#if DB_READY
        /// <summary>
        /// Gets or sets the ID of the current <see cref="Team"/>. This does NOT come from the Riot API; it is used as a key when storing this object in a database.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int Id { get; set; }
#endif
    }
}
