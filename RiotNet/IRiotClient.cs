using RiotNet.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RiotNet
{
    public partial interface IRiotClient
    {
        #region Tournament API

        /// <summary>
        /// Gets the currently supported version of the Tournament API that the client communicates with.
        /// </summary>
        string TournamentApiVersion { get; }

        /// <summary>
        /// Registers the current client as a tournament provider. This method uses the Tournament API. This endpoint is only accessible if you have a tournament API key.
        /// </summary>
        /// <param name="url">The provider's callback URL to which tournament game results in this region should be posted.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<long> CreateTournamentProviderAsync(string url);
        
        /// <summary>
        /// Creates a tournament. This method uses the Tournament API. This endpoint is only accessible if you have a tournament API key.
        /// </summary>
        /// <param name="providerID">The providerID obtained from <see cref="CreateTournamentProviderAsync"/>.</param>
        /// <param name="name">The optional name of the tournament.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<long> CreateTournamentAsync(long providerID, string name = null);
        
        /// <summary>
        /// Creates one or more tournament codes. This method uses the Tournament API. This endpoint is only accessible if you have a tournament API key.
        /// </summary>
        /// <param name="tournamentId">The tournament ID obtained from <see cref="CreateTournamentAsync"/>.</param>
        /// <param name="count">The number of codes to create (max 1000).</param>
        /// <param name="allowedSummonerIds">Optional list of participants in order to validate the players eligible to join the lobby.</param>
        /// <param name="mapType">The map type of the game. Note that <see cref="MapType.CRYSTAL_SCAR"/> is not allowed.</param>
        /// <param name="pickType">The pick type of the game.</param>
        /// <param name="spectatorType">The spectator type of the game.</param>
        /// <param name="teamSize">The team size of the game. Valid values are 1-5.</param>
        /// <param name="metadata">Optional string that may contain any data in any format, if specified at all. Used to denote any custom information about the game.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<List<string>> CreateTournamentCodeAsync(long tournamentId, int? count = null, List<long> allowedSummonerIds = null, MapType mapType = MapType.SUMMONERS_RIFT,
            PickType pickType = PickType.TOURNAMENT_DRAFT, SpectatorType spectatorType = SpectatorType.ALL, int teamSize = 5, string metadata = null);
        
        /// <summary>
        /// Gets the details of a tournament code. This method uses the Tournament API. This endpoint is only accessible if you have a tournament API key.
        /// </summary>
        /// <param name="tournamentCode">The tournament code obtained from <see cref="CreateTournamentCodeAsync"/>.</param>
        /// <returns>The tournament code details.</returns>
        Task<TournamentCode> GetTournamentCodeAsync(string tournamentCode);
        
        /// <summary>
        /// Saves changes to a tournament code. This method uses the Tournament API. This endpoint is only accessible if you have a tournament API key.
        /// </summary>
        /// <param name="tournamentCode">The tournament code obtained from <see cref="CreateTournamentCodeAsync"/>.</param>
        /// <param name="allowedSummonerIds">Optional list of participants in order to validate the players eligible to join the lobby.</param>
        /// <param name="mapType">The map type of the game.</param>
        /// <param name="pickType">The pick type of the game.</param>
        /// <param name="spectatorType">The spectator type of the game.</param>
        Task UpdateTournamentCodeAsync(string tournamentCode, List<long> allowedSummonerIds = null, MapType mapType = MapType.SUMMONERS_RIFT,
            PickType pickType = PickType.TOURNAMENT_DRAFT, SpectatorType spectatorType = SpectatorType.ALL);
        
        /// <summary>
        /// Saves changes to a tournament code. This method uses the Tournament API. This endpoint is only accessible if you have a tournament API key.
        /// </summary>
        /// <param name="tournamentCode">The tournament code to update. Only the Code, Participants, MapType, PickType, and SpectatorType proerties are used.</param>
        Task UpdateTournamentCodeAsync(TournamentCode tournamentCode);
        
        /// <summary>
        /// Gets the events that happened in the lobby of atournament code game. This method uses the Tournament API. This endpoint is only accessible if you have a tournament API key.
        /// </summary>
        /// <param name="tournamentCode">The tournament code obtained from <see cref="CreateTournamentCodeAsync"/>.</param>
        /// <returns>The tournament code details.</returns>
        Task<List<LobbyEvent>> GetTournamentCodeLobbyEventsAsync(string tournamentCode);

        #endregion
    }
}
