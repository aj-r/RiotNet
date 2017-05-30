using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains information about a tournament code.
    /// </summary>
    public class TournamentCode
    {
        /// <summary>
        ///  Gets or sets the tournament code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        ///  Gets or sets tournament code ID.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        /// <summary>
        ///  Gets or sets the name of the lobby for the tournament code game.
        /// </summary>
        public string LobbyName { get; set; }

        /// <summary>
        ///  Gets or sets the map on which the tournament code game will be played. This should equal one of the <see cref="MapType"/> values.
        /// </summary>
        public string Map { get; set; }

        /// <summary>
        ///  Gets or sets the metadata for the tournament code game.
        /// </summary>
        public string MetaData { get; set; }

        /// <summary>
        ///  Gets or sets the IDs of the summoners who are allowed to participate in the game.
        /// </summary>
        [NotMapped]
        public ListOfLong Participants { get; set; }

        /// <summary>
        ///  Gets or sets the lobby password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the method used for picking champions. This should equal one of the <see cref="PickType"/> values.
        /// </summary>
        public string PickType { get; set; }

        /// <summary>
        ///  Gets or sets the provider ID.
        /// </summary>
        public long ProviderId { get; set; }

        /// <summary>
        ///  Gets or sets the region in which the game is played.
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        ///  Gets or sets the spectator type for the game. This should equal one of the <see cref="SpectatorType"/> values.
        /// </summary>
        public string Spectators { get; set; }

        /// <summary>
        ///  Gets or sets the number of players per team.
        /// </summary>
        public int TeamSize { get; set; }

        /// <summary>
        ///  Gets or sets the tournament ID.
        /// </summary>
        public long TournamentId { get; set; }
    }
}