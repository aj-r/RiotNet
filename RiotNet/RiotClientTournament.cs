using System.Threading.Tasks;
using RestSharp;
using RiotNet.Models;
using System.Collections.Generic;

namespace RiotNet
{
    public partial class RiotClient
    {
        /// <summary>
        /// Gets the currently supported version of the Tournament API that the client communicates with.
        /// </summary>
        public string TournamentApiVersion { get { return "v1"; } }

        private IRestRequest CreateTournamentProviderRequest(string url)
        {
            var request = Post("tournament/public/{version}/provider");
            request.AddUrlSegment("version", TournamentApiVersion);
            request.AddBody(new { region, url });
            return request;
        }

        /// <summary>
        /// Registers the current client as a tournament provider. This endpoint is only accessible if you have a tournament API key.
        /// </summary>
        /// <param name="url">The provider's callback URL to which tournament game results in this region should be posted.</param>
        /// <returns>The registered providerId.</returns>
        public long CreateTournamentProvider(string url)
        {
            return Execute<long>(CreateTournamentProviderRequest(url), globalClient);
        }

        /// <summary>
        /// Registers the current client as a tournament provider. This endpoint is only accessible if you have a tournament API key.
        /// </summary>
        /// <param name="url">The provider's callback URL to which tournament game results in this region should be posted.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<long> CreateTournamentProviderAsync(string url)
        {
            return ExecuteAsync<long>(CreateTournamentProviderRequest(url), globalClient);
        }

        private IRestRequest CreateTournamentRequest(long providerId, string name)
        {
            var request = Post("tournament/public/{version}/tournament");
            request.AddUrlSegment("version", TournamentApiVersion);
            request.AddBody(new { name, providerId });
            return request;
        }

        /// <summary>
        /// Creates a tournament. This endpoint is only accessible if you have a tournament API key.
        /// </summary>
        /// <param name="providerId">The providerId obtained from <see cref="CreateTournamentProvider"/>.</param>
        /// <param name="name">The optional name of the tournament.</param>
        /// <returns>The tournamentId.</returns>
        public long CreateTournament(long providerId, string name = null)
        {
            return Execute<long>(CreateTournamentRequest(providerId, name), globalClient);
        }

        /// <summary>
        /// Creates a tournament. This endpoint is only accessible if you have a tournament API key.
        /// </summary>
        /// <param name="providerId">The providerId obtained from <see cref="CreateTournamentProvider"/>.</param>
        /// <param name="name">The optional name of the tournament.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<long> CreateTournamentAsync(long providerId, string name = null)
        {
            return ExecuteAsync<long>(CreateTournamentRequest(providerId, name), globalClient);
        }

        private IRestRequest CreateTournamentCodeRequest(long tournamentId, int? count, List<long> allowedSummonerIds, MapType mapType,
            PickType pickType, SpectatorType spectatorType, int teamSize, string metadata)
        {
            var request = Post("tournament/public/{version}/code");
            request.AddUrlSegment("version", TournamentApiVersion);
            request.AddParameter("tournamentId", tournamentId, ParameterType.QueryString);
            if (count != null)
                request.AddParameter("count", count.Value, ParameterType.QueryString);
            request.AddBody(new
            {
                allowedSummonerIds = allowedSummonerIds != null ? new { participants = allowedSummonerIds } : null,
                mapType,
                pickType,
                spectatorType,
                teamSize,
                metadata
            });
            return request;
        }

        /// <summary>
        /// Creates one or more tournament codes. This endpoint is only accessible if you have a tournament API key.
        /// </summary>
        /// <param name="tournamentId">The tournament ID obtained from <see cref="CreateTournament"/>.</param>
        /// <param name="count">The number of codes to create (max 1000).</param>
        /// <param name="allowedSummonerIds">Optional list of participants in order to validate the players eligible to join the lobby.</param>
        /// <param name="mapType">The map type of the game.</param>
        /// <param name="pickType">The pick type of the game.</param>
        /// <param name="spectatorType">The spectator type of the game.</param>
        /// <param name="teamSize">The team size of the game. Valid values are 1-5.</param>
        /// <param name="metadata">Optional string that may contain any data in any format, if specified at all. Used to denote any custom information about the game.</param>
        /// <returns>A list of tournament codes.</returns>
        public List<string> CreateTournamentCode(long tournamentId, int? count = null, List<long> allowedSummonerIds = null, MapType mapType = MapType.SUMMONERS_RIFT,
            PickType pickType = PickType.TOURNAMENT_DRAFT, SpectatorType spectatorType = SpectatorType.ALL, int teamSize = 5, string metadata = null)
        {
            return Execute<List<string>>(CreateTournamentCodeRequest(tournamentId, count, allowedSummonerIds, mapType, pickType, spectatorType, teamSize, metadata), globalClient);
        }

        /// <summary>
        /// Creates one or more tournament codes. This endpoint is only accessible if you have a tournament API key.
        /// </summary>
        /// <param name="tournamentId">The tournament ID obtained from <see cref="CreateTournamentAsync"/>.</param>
        /// <param name="count">The number of codes to create (max 1000).</param>
        /// <param name="allowedSummonerIds">Optional list of participants in order to validate the players eligible to join the lobby.</param>
        /// <param name="mapType">The map type of the game.</param>
        /// <param name="pickType">The pick type of the game.</param>
        /// <param name="spectatorType">The spectator type of the game.</param>
        /// <param name="teamSize">The team size of the game. Valid values are 1-5.</param>
        /// <param name="metadata">Optional string that may contain any data in any format, if specified at all. Used to denote any custom information about the game.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<List<string>> CreateTournamentCodeAsync(long tournamentId, int? count = null, List<long> allowedSummonerIds = null, MapType mapType = MapType.SUMMONERS_RIFT,
            PickType pickType = PickType.TOURNAMENT_DRAFT, SpectatorType spectatorType = SpectatorType.ALL, int teamSize = 5, string metadata = null)
        {
            return ExecuteAsync<List<string>>(CreateTournamentCodeRequest(tournamentId, count, allowedSummonerIds, mapType, pickType, spectatorType, teamSize, metadata), globalClient);
        }

        private IRestRequest GetTournamentCodeRequest(string tournamentCode)
        {
            var request = Get("tournament/public/{version}/code/{tournamentCode}");
            request.AddUrlSegment("version", TournamentApiVersion);
            request.AddUrlSegment("tournamentCode", tournamentCode);
            return request;
        }

        /// <summary>
        /// Gets the details of a tournament code.
        /// </summary>
        /// <param name="tournamentCode">The tournament code obtained from <see cref="CreateTournamentCode"/>.</param>
        /// <returns>The tournament code details.</returns>
        public TournamentCode GetTournamentCode(string tournamentCode)
        {
            return Execute<TournamentCode>(GetTournamentCodeRequest(tournamentCode), globalClient);
        }

        /// <summary>
        /// Gets the details of a tournament code.
        /// </summary>
        /// <param name="tournamentCode">The tournament code obtained from <see cref="CreateTournamentCodeAsync"/>.</param>
        /// <returns>The tournament code details.</returns>
        public Task<TournamentCode> GetTournamentCodeAsync(string tournamentCode)
        {
            return ExecuteAsync<TournamentCode>(GetTournamentCodeRequest(tournamentCode), globalClient);
        }

        private IRestRequest UpdateTournamentCodeRequest(string tournamentCode, List<long> allowedSummonerIds, MapType mapType, PickType pickType, SpectatorType spectatorType)
        {
            var request = Put("tournament/public/{version}/code/{tournamentCode}");
            request.AddUrlSegment("version", TournamentApiVersion);
            request.AddUrlSegment("tournamentCode", tournamentCode);
            request.AddBody(new
            {
                allowedParticipants = allowedSummonerIds != null ? string.Join(",", allowedSummonerIds) : null,
                mapType,
                pickType,
                spectatorType
            });
            return request;
        }

        /// <summary>
        /// Saves changes to a tournament code.
        /// </summary>
        /// <param name="tournamentCode">The tournament code obtained from <see cref="CreateTournamentCode"/>.</param>
        /// <param name="allowedSummonerIds">Optional list of participants in order to validate the players eligible to join the lobby.</param>
        /// <param name="mapType">The map type of the game.</param>
        /// <param name="pickType">The pick type of the game.</param>
        /// <param name="spectatorType">The spectator type of the game.</param>
        public void UpdateTournamentCode(string tournamentCode, List<long> allowedSummonerIds = null, MapType mapType = MapType.SUMMONERS_RIFT,
            PickType pickType = PickType.TOURNAMENT_DRAFT, SpectatorType spectatorType = SpectatorType.ALL)
        {
            Execute<object>(UpdateTournamentCodeRequest(tournamentCode, allowedSummonerIds, mapType, pickType, spectatorType), globalClient);
        }

        /// <summary>
        /// Saves changes to a tournament code.
        /// </summary>
        /// <param name="tournamentCode">The tournament code obtained from <see cref="CreateTournamentCodeAsync"/>.</param>
        /// <param name="allowedSummonerIds">Optional list of participants in order to validate the players eligible to join the lobby.</param>
        /// <param name="mapType">The map type of the game.</param>
        /// <param name="pickType">The pick type of the game.</param>
        /// <param name="spectatorType">The spectator type of the game.</param>
        public Task UpdateTournamentCodeAsync(string tournamentCode, List<long> allowedSummonerIds = null, MapType mapType = MapType.SUMMONERS_RIFT,
            PickType pickType = PickType.TOURNAMENT_DRAFT, SpectatorType spectatorType = SpectatorType.ALL)
        {
            return ExecuteAsync<object>(UpdateTournamentCodeRequest(tournamentCode, allowedSummonerIds, mapType, pickType, spectatorType), globalClient);
        }

        /// <summary>
        /// Saves changes to a tournament code.
        /// </summary>
        /// <param name="tournamentCode">The tournament code to update. Only the Code, Participants, MapType, PickType, and SpectatorType proerties are used.</param>
        public void UpdateTournamentCode(TournamentCode tournamentCode)
        {
            UpdateTournamentCode(tournamentCode.Code, tournamentCode.Participants, tournamentCode.Map, tournamentCode.PickType, tournamentCode.Spectators);
        }

        /// <summary>
        /// Saves changes to a tournament code.
        /// </summary>
        /// <param name="tournamentCode">The tournament code to update. Only the Code, Participants, MapType, PickType, and SpectatorType proerties are used.</param>
        public Task UpdateTournamentCodeAsync(TournamentCode tournamentCode)
        {
            return UpdateTournamentCodeAsync(tournamentCode.Code, tournamentCode.Participants, tournamentCode.Map, tournamentCode.PickType, tournamentCode.Spectators);
        }

        private IRestRequest GetTournamentCodeEventsRequest(string tournamentCode)
        {
            var request = Get("tournament/public/{version}/lobby/events/by-code/{tournamentCode}");
            request.AddUrlSegment("version", TournamentApiVersion);
            request.AddUrlSegment("tournamentCode", tournamentCode);
            return request;
        }

        /// <summary>
        /// Gets the events that happened in the lobby of atournament code game.
        /// </summary>
        /// <param name="tournamentCode">The tournament code obtained from <see cref="CreateTournamentCode"/>.</param>
        /// <returns>The tournament code details.</returns>
        public List<LobbyEvent> GetTournamentCodeEvents(string tournamentCode)
        {
            var wrapper = Execute<LobbyEventWrapper>(GetTournamentCodeEventsRequest(tournamentCode), globalClient);
            return wrapper.EventList;
        }

        /// <summary>
        /// Gets the events that happened in the lobby of atournament code game.
        /// </summary>
        /// <param name="tournamentCode">The tournament code obtained from <see cref="CreateTournamentCodeAsync"/>.</param>
        /// <returns>The tournament code details.</returns>
        public async Task<List<LobbyEvent>> GetTournamentCodeEventsAsync(string tournamentCode)
        {
            var wrapper = await ExecuteAsync<LobbyEventWrapper>(GetTournamentCodeEventsRequest(tournamentCode), globalClient);
            return wrapper.EventList;
        }

    }
}
