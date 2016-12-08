using RiotNet.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RiotNet
{
    public partial class RiotClient
    {
        /// <summary>
        /// Gets the currently supported version of the Tournament API that the client communicates with.
        /// </summary>
        public string TournamentApiVersion { get { return "v1"; } }

        /// <summary>
        /// Registers the current client as a tournament provider. This method uses the Tournament API. This endpoint is only accessible if you have a tournament API key.
        /// IMPORTANT: if you are using an interim API key, you must set <see cref="RiotClientSettings.UseTournamentStub"/> to true before calling this method.
        /// </summary>
        /// <param name="url">The provider's callback URL to which tournament game results in this region should be posted.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<long> CreateTournamentProviderAsync(string url)
        {
            var publicOrStub = settings.UseTournamentStub ? "stub" : "public";
            return PostAsync<long>($"{globalBaseUrl}/tournament/{publicOrStub}/{TournamentApiVersion}/provider", new { region, url });
        }

        /// <summary>
        /// Creates a tournament. This method uses the Tournament API. This endpoint is only accessible if you have a tournament API key.
        /// IMPORTANT: if you are using an interim API key, you must set <see cref="RiotClientSettings.UseTournamentStub"/> to true before calling this method.
        /// </summary>
        /// <param name="providerId">The providerId obtained from <see cref="CreateTournamentProvider"/>.</param>
        /// <param name="name">The optional name of the tournament.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<long> CreateTournamentAsync(long providerId, string name = null)
        {
            var publicOrStub = settings.UseTournamentStub ? "stub" : "public";
            return PostAsync<long>($"{globalBaseUrl}/tournament/{publicOrStub}/{TournamentApiVersion}/tournament", new { name, providerId });
        }

        /// <summary>
        /// Creates one or more tournament codes. This method uses the Tournament API. This endpoint is only accessible if you have a tournament API key.
        /// IMPORTANT: if you are using an interim API key, you must set <see cref="RiotClientSettings.UseTournamentStub"/> to true before calling this method.
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
        public Task<List<string>> CreateTournamentCodeAsync(long tournamentId, int? count = null, List<long> allowedSummonerIds = null, MapType mapType = MapType.SUMMONERS_RIFT,
            PickType pickType = PickType.TOURNAMENT_DRAFT, SpectatorType spectatorType = SpectatorType.ALL, int teamSize = 5, string metadata = null)
        {
            var publicOrStub = settings.UseTournamentStub ? "stub" : "public";
            var queryParameters = new Dictionary<string, object> { { "tournamentId", tournamentId } };
            if (count != null)
                queryParameters["count"] = count;
            return PostAsync<List<string>>($"{globalBaseUrl}/tournament/{publicOrStub}/{TournamentApiVersion}/code", new
            {
                allowedSummonerIds = allowedSummonerIds != null ? new { participants = allowedSummonerIds } : null,
                mapType,
                pickType,
                spectatorType,
                teamSize,
                metadata
            }, queryParameters);
        }

        /// <summary>
        /// Gets the details of a tournament code. This method uses the Tournament API. This endpoint is only accessible if you have a tournament API key.
        /// IMPORTANT: if you are using an interim API key, you must set <see cref="RiotClientSettings.UseTournamentStub"/> to true before calling this method.
        /// </summary>
        /// <param name="tournamentCode">The tournament code obtained from <see cref="CreateTournamentCodeAsync"/>.</param>
        /// <returns>The tournament code details.</returns>
        public Task<TournamentCode> GetTournamentCodeAsync(string tournamentCode)
        {
            var publicOrStub = settings.UseTournamentStub ? "stub" : "public";
            return GetAsync<TournamentCode>($"{globalBaseUrl}/tournament/{publicOrStub}/{TournamentApiVersion}/code/{tournamentCode}");
        }

        /// <summary>
        /// Saves changes to a tournament code. This method uses the Tournament API. This endpoint is only accessible if you have a tournament API key.
        /// IMPORTANT: if you are using an interim API key, you must set <see cref="RiotClientSettings.UseTournamentStub"/> to true before calling this method.
        /// </summary>
        /// <param name="tournamentCode">The tournament code obtained from <see cref="CreateTournamentCodeAsync"/>.</param>
        /// <param name="allowedSummonerIds">Optional list of participants in order to validate the players eligible to join the lobby.</param>
        /// <param name="mapType">The map type of the game.</param>
        /// <param name="pickType">The pick type of the game.</param>
        /// <param name="spectatorType">The spectator type of the game.</param>
        public Task UpdateTournamentCodeAsync(string tournamentCode, List<long> allowedSummonerIds = null, MapType mapType = MapType.SUMMONERS_RIFT,
            PickType pickType = PickType.TOURNAMENT_DRAFT, SpectatorType spectatorType = SpectatorType.ALL)
        {
            var publicOrStub = settings.UseTournamentStub ? "stub" : "public";
            return PutAsync<object>($"{globalBaseUrl}/tournament/{publicOrStub}/{TournamentApiVersion}/code/{tournamentCode}", new
            {
                allowedParticipants = allowedSummonerIds != null ? string.Join(",", allowedSummonerIds) : null,
                mapType,
                pickType,
                spectatorType
            });
        }

        /// <summary>
        /// Saves changes to a tournament code. This method uses the Tournament API. This endpoint is only accessible if you have a tournament API key.
        /// IMPORTANT: if you are using an interim API key, you must set <see cref="RiotClientSettings.UseTournamentStub"/> to true before calling this method.
        /// </summary>
        /// <param name="tournamentCode">The tournament code to update. Only the Code, Participants, MapType, PickType, and SpectatorType proerties are used.</param>
        public Task UpdateTournamentCodeAsync(TournamentCode tournamentCode)
        {
            return UpdateTournamentCodeAsync(tournamentCode.Code, tournamentCode.Participants, tournamentCode.Map, tournamentCode.PickType, tournamentCode.Spectators);
        }

        /// <summary>
        /// Gets the events that happened in the lobby of atournament code game. This method uses the Tournament API. This endpoint is only accessible if you have a tournament API key.
        /// IMPORTANT: if you are using an interim API key, you must set <see cref="RiotClientSettings.UseTournamentStub"/> to true before calling this method.
        /// </summary>
        /// <param name="tournamentCode">The tournament code obtained from <see cref="CreateTournamentCodeAsync"/>.</param>
        /// <returns>The tournament code details.</returns>
        public async Task<List<LobbyEvent>> GetTournamentCodeLobbyEventsAsync(string tournamentCode)
        {
            var publicOrStub = settings.UseTournamentStub ? "stub" : "public";
            var wrapper = await GetAsync<LobbyEventWrapper>($"{globalBaseUrl}/tournament/{publicOrStub}/{TournamentApiVersion}/lobby/events/by-code/{tournamentCode}").ConfigureAwait(false);
            return wrapper.EventList;
        }

    }
}
