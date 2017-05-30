using System.ComponentModel.DataAnnotations.Schema;

namespace RiotNet.Models
{
    /// <summary>
    /// This object contains all timeline information.
    /// Delta fields refer to values for the specified period (e.g., the gold per minute over the first 10 minutes of the game versus the second 20 minutes of the game).
    /// Diffs fields refer to the deltas versus the calculated lane opponent(s).
    /// </summary>
    [ComplexType]
    public class MatchParticipantTimeline
    {
        /// <summary>
        /// Gets or sets creeps per minute timeline data.
        /// </summary>
        public MatchParticipantTimelineData CreepsPerMinDeltas { get; set; } = new MatchParticipantTimelineData();

        /// <summary>
        /// Gets or sets creep score difference per minute timeline data
        /// </summary>
        public MatchParticipantTimelineData CsDiffPerMinDeltas { get; set; } = new MatchParticipantTimelineData();

        /// <summary>
        /// Gets or sets damage taken difference per minute timeline data.
        /// </summary>
        public MatchParticipantTimelineData DamageTakenDiffPerMinDeltas { get; set; } = new MatchParticipantTimelineData();

        /// <summary>
        /// Gets or sets damage taken per minute timeline data.
        /// </summary>
        public MatchParticipantTimelineData DamageTakenPerMinDeltas { get; set; } = new MatchParticipantTimelineData();

        /// <summary>
        /// Gets or sets gold per minute timeline data.
        /// </summary>
        public MatchParticipantTimelineData GoldPerMinDeltas { get; set; } = new MatchParticipantTimelineData();

        /// <summary>
        /// Gets or sets the participant's lane. This should equal one of the <see cref="PlayerPosition"/> values.
        /// </summary>
        public string Lane { get; set; }

        /// <summary>
        /// Gets or sets the participant ID.
        /// </summary>
        public int ParticipantId { get; set; }

        /// <summary>
        /// Gets or sets the participant's role. This should equal one of the <see cref="MatchRole"/> values.
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Gets or sets experience difference per minute timeline data.
        /// </summary>
        public MatchParticipantTimelineData XpDiffPerMinDeltas { get; set; } = new MatchParticipantTimelineData();

        /// <summary>
        /// Gets or sets experience per minute timeline data.
        /// </summary>
        public MatchParticipantTimelineData XpPerMinDeltas { get; set; } = new MatchParticipantTimelineData();
    }
}
