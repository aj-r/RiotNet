using RiotNet.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RiotNet
{
    public partial interface IRiotClient
    {
        /// <summary>
        /// Registers the current client as a tournament provider. This method uses the Tournament API. This endpoint is only accessible if you have a tournament API key.
        /// IMPORTANT: if you are using an interim API key, you must set <see cref="RiotClientSettings.UseTournamentStub"/> to true before calling this method.
        /// </summary>
        /// <param name="url">The provider's callback URL to which tournament game results in this region should be posted. The URL must be well-formed, use the http or https protocol, and use the default port for the protocol (http URLs must use port 80, https URLs must use port 443).</param>
        /// <param name="platformId">The platform ID of the region in which the provider will be running tournaments. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="regionalProxy">The name of the regional proxy service. This should equal one of the <see cref="RegionalProxy"/> values.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<long> CreateTournamentProviderAsync(string url, string platformId = null, string regionalProxy = RegionalProxy.Americas, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Registers the current client as a tournament provider. This method uses the Tournament API. This endpoint is only accessible if you have a tournament API key.
        /// IMPORTANT: if you are using an interim API key, you must set <see cref="RiotClientSettings.UseTournamentStub"/> to true before calling this method.
        /// </summary>
        /// <param name="url">The provider's callback URL to which tournament game results in this region should be posted. The URL must be well-formed, use the http or https protocol, and use the default port for the protocol (http URLs must use port 80, https URLs must use port 443).</param>
        /// <param name="platformId">The platform ID of the region in which the provider will be running tournaments. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<long> CreateTournamentProviderAsync(string url, string platformId, CancellationToken token);

        /// <summary>
        /// Creates a tournament. This method uses the Tournament API. This endpoint is only accessible if you have a tournament API key.
        /// IMPORTANT: if you are using an interim API key, you must set <see cref="RiotClientSettings.UseTournamentStub"/> to true before calling this method.
        /// </summary>
        /// <param name="providerId">The providerID obtained from CreateTournamentProviderAsync.</param>
        /// <param name="name">The optional name of the tournament.</param>
        /// <param name="regionalProxy">The name of the regional proxy service. This should equal one of the <see cref="RegionalProxy"/> values.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<long> CreateTournamentAsync(long providerId, string name = null, string regionalProxy = RegionalProxy.Americas, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Creates a tournament. This method uses the Tournament API. This endpoint is only accessible if you have a tournament API key.
        /// IMPORTANT: if you are using an interim API key, you must set <see cref="RiotClientSettings.UseTournamentStub"/> to true before calling this method.
        /// </summary>
        /// <param name="providerId">The providerID obtained from CreateTournamentProviderAsync.</param>
        /// <param name="name">The optional name of the tournament.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<long> CreateTournamentAsync(long providerId, string name, CancellationToken token);

        /// <summary>
        /// Creates one or more tournament codes. This method uses the Tournament API. This endpoint is only accessible if you have a tournament API key.
        /// IMPORTANT: if you are using an interim API key, you must set <see cref="RiotClientSettings.UseTournamentStub"/> to true before calling this method.
        /// </summary>
        /// <param name="tournamentId">The tournament ID obtained from CreateTournamentAsync.</param>
        /// <param name="count">The number of codes to create (max 1000).</param>
        /// <param name="allowedSummonerIds">Optional list of participants in order to validate the players eligible to join the lobby.</param>
        /// <param name="mapType">The map type of the game. This should equal one of the <see cref="MapType"/> values. Note that <see cref="MapType.CRYSTAL_SCAR"/> is not allowed.</param>
        /// <param name="pickType">The pick type of the game. This should equal one of the <see cref="PickType"/> values.</param>
        /// <param name="spectatorType">The spectator type of the game. This should equal one of the <see cref="SpectatorType"/> values.</param>
        /// <param name="teamSize">The team size of the game. Valid values are 1-5.</param>
        /// <param name="metadata">Optional string that may contain any data in any format, if specified at all. Used to denote any custom information about the game.</param>
        /// <param name="regionalProxy">The name of the regional proxy service. This should equal one of the <see cref="RegionalProxy"/> values.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<List<string>> CreateTournamentCodeAsync(long tournamentId, int? count = null, List<long> allowedSummonerIds = null, string mapType = MapType.SUMMONERS_RIFT,
            string pickType = PickType.TOURNAMENT_DRAFT, string spectatorType = SpectatorType.ALL, int teamSize = 5, string metadata = null, string regionalProxy = RegionalProxy.Americas,
            CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Creates one or more tournament codes. This method uses the Tournament API. This endpoint is only accessible if you have a tournament API key.
        /// IMPORTANT: if you are using an interim API key, you must set <see cref="RiotClientSettings.UseTournamentStub"/> to true before calling this method.
        /// </summary>
        /// <param name="tournamentId">The tournament ID obtained from CreateTournamentAsync.</param>
        /// <param name="count">The number of codes to create (max 1000).</param>
        /// <param name="allowedSummonerIds">Optional list of participants in order to validate the players eligible to join the lobby.</param>
        /// <param name="mapType">The map type of the game. This should equal one of the <see cref="MapType"/> values. Note that <see cref="MapType.CRYSTAL_SCAR"/> is not allowed.</param>
        /// <param name="pickType">The pick type of the game. This should equal one of the <see cref="PickType"/> values.</param>
        /// <param name="spectatorType">The spectator type of the game. This should equal one of the <see cref="SpectatorType"/> values.</param>
        /// <param name="teamSize">The team size of the game. Valid values are 1-5.</param>
        /// <param name="metadata">Optional string that may contain any data in any format, if specified at all. Used to denote any custom information about the game.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<List<string>> CreateTournamentCodeAsync(long tournamentId, int? count, List<long> allowedSummonerIds, string mapType,
            string pickType, string spectatorType, int teamSize, string metadata, CancellationToken token);

        /// <summary>
        /// Saves changes to a tournament code. This method uses the Tournament API. This endpoint is only accessible if you have a tournament API key.
        /// This method does NOT support the tournament stub API.
        /// </summary>
        /// <param name="tournamentCode">The definition for the tournament code(s) to create.</param>
        /// <param name="count">The number of codes to create (max 1000).</param>
        /// <param name="regionalProxy">The name of the regional proxy service. This should equal one of the <see cref="RegionalProxy"/> values.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<List<string>> CreateTournamentCodeAsync(TournamentCode tournamentCode, int? count = null, string regionalProxy = RegionalProxy.Americas, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Saves changes to a tournament code. This method uses the Tournament API. This endpoint is only accessible if you have a tournament API key.
        /// This method does NOT support the tournament stub API.
        /// </summary>
        /// <param name="tournamentCode">The definition for the tournament code(s) to create.</param>
        /// <param name="count">The number of codes to create (max 1000).</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<List<string>> CreateTournamentCodeAsync(TournamentCode tournamentCode, int? count, CancellationToken token);

        /// <summary>
        /// Gets the details of a tournament code. This method uses the Tournament API. This endpoint is only accessible if you have a tournament API key.
        /// This method does NOT support the tournament stub API.
        /// </summary>
        /// <param name="tournamentCode">The tournament code obtained from CreateTournamentCodeAsync.</param>
        /// <param name="regionalProxy">The name of the regional proxy service. This should equal one of the <see cref="RegionalProxy"/> values.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>The tournament code details.</returns>
        Task<TournamentCode> GetTournamentCodeAsync(string tournamentCode, string regionalProxy = RegionalProxy.Americas, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets the details of a tournament code. This method uses the Tournament API. This endpoint is only accessible if you have a tournament API key.
        /// This method does NOT support the tournament stub API.
        /// </summary>
        /// <param name="tournamentCode">The tournament code obtained from CreateTournamentCodeAsync.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>The tournament code details.</returns>
        Task<TournamentCode> GetTournamentCodeAsync(string tournamentCode, CancellationToken token);

        /// <summary>
        /// Saves changes to a tournament code. This method uses the Tournament API. This endpoint is only accessible if you have a tournament API key.
        /// This method does NOT support the tournament stub API.
        /// </summary>
        /// <param name="tournamentCode">The tournament code obtained from CreateTournamentCodeAsync.</param>
        /// <param name="allowedParticipants">Optional list of participants in order to validate the players eligible to join the lobby.</param>
        /// <param name="mapType">The map type of the game. This should equal one of the <see cref="MapType"/> values. Note that <see cref="MapType.CRYSTAL_SCAR"/> is not allowed.</param>
        /// <param name="pickType">The pick type of the game. This should equal one of the <see cref="PickType"/> values.</param>
        /// <param name="spectatorType">The spectator type of the game. This should equal one of the <see cref="SpectatorType"/> values.</param>
        /// <param name="regionalProxy">The name of the regional proxy service. This should equal one of the <see cref="RegionalProxy"/> values.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task UpdateTournamentCodeAsync(string tournamentCode, List<long> allowedParticipants = null, string mapType = MapType.SUMMONERS_RIFT,
            string pickType = PickType.TOURNAMENT_DRAFT, string spectatorType = SpectatorType.ALL, string regionalProxy = RegionalProxy.Americas,
            CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Saves changes to a tournament code. This method uses the Tournament API. This endpoint is only accessible if you have a tournament API key.
        /// This method does NOT support the tournament stub API.
        /// </summary>
        /// <param name="tournamentCode">The tournament code obtained from CreateTournamentCodeAsync.</param>
        /// <param name="allowedParticipants">Optional list of participants in order to validate the players eligible to join the lobby.</param>
        /// <param name="mapType">The map type of the game. This should equal one of the <see cref="MapType"/> values. Note that <see cref="MapType.CRYSTAL_SCAR"/> is not allowed.</param>
        /// <param name="pickType">The pick type of the game. This should equal one of the <see cref="PickType"/> values.</param>
        /// <param name="spectatorType">The spectator type of the game. This should equal one of the <see cref="SpectatorType"/> values.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task UpdateTournamentCodeAsync(string tournamentCode, List<long> allowedParticipants, string mapType,
            string pickType, string spectatorType, CancellationToken token);

        /// <summary>
        /// Saves changes to a tournament code. This method uses the Tournament API. This endpoint is only accessible if you have a tournament API key.
        /// This method does NOT support the tournament stub API.
        /// </summary>
        /// <param name="tournamentCode">The tournament code to update. Only the Code, Participants, MapType, PickType, and SpectatorType properties are used.</param>
        /// <param name="regionalProxy">The name of the regional proxy service. This should equal one of the <see cref="RegionalProxy"/> values.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task UpdateTournamentCodeAsync(TournamentCode tournamentCode, string regionalProxy = RegionalProxy.Americas, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Saves changes to a tournament code. This method uses the Tournament API. This endpoint is only accessible if you have a tournament API key.
        /// This method does NOT support the tournament stub API.
        /// </summary>
        /// <param name="tournamentCode">The tournament code to update. Only the Code, Participants, MapType, PickType, and SpectatorType properties are used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task UpdateTournamentCodeAsync(TournamentCode tournamentCode, CancellationToken token);

        /// <summary>
        /// Gets the events that happened in the lobby of atournament code game. This method uses the Tournament API. This endpoint is only accessible if you have a tournament API key.
        /// IMPORTANT: if you are using an interim API key, you must set <see cref="RiotClientSettings.UseTournamentStub"/> to true before calling this method.
        /// </summary>
        /// <param name="tournamentCode">The tournament code obtained from CreateTournamentCodeAsync.</param>
        /// <param name="regionalProxy">The name of the regional proxy service. This should equal one of the <see cref="RegionalProxy"/> values.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>The tournament code details.</returns>
        Task<List<LobbyEvent>> GetTournamentCodeLobbyEventsAsync(string tournamentCode, string regionalProxy = RegionalProxy.Americas, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Gets the events that happened in the lobby of atournament code game. This method uses the Tournament API. This endpoint is only accessible if you have a tournament API key.
        /// IMPORTANT: if you are using an interim API key, you must set <see cref="RiotClientSettings.UseTournamentStub"/> to true before calling this method.
        /// </summary>
        /// <param name="tournamentCode">The tournament code obtained from CreateTournamentCodeAsync.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>The tournament code details.</returns>
        Task<List<LobbyEvent>> GetTournamentCodeLobbyEventsAsync(string tournamentCode, CancellationToken token);
    }

    public partial class RiotClient
    {
        /// <summary>
        /// Registers the current client as a tournament provider. This method uses the Tournament API. This endpoint is only accessible if you have a tournament API key.
        /// IMPORTANT: if you are using an interim API key, you must set <see cref="RiotClientSettings.UseTournamentStub"/> to true before calling this method.
        /// </summary>
        /// <param name="url">The provider's callback URL to which tournament game results in this region should be posted. The URL must be well-formed, use the http or https protocol, and use the default port for the protocol (http URLs must use port 80, https URLs must use port 443).</param>
        /// <param name="platformId">The platform ID of the region in which the provider will be running tournaments. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="regionalProxy">The name of the regional proxy service. This should equal one of the <see cref="RegionalProxy"/> values.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<long> CreateTournamentProviderAsync(string url, string platformId = null, string regionalProxy = RegionalProxy.Americas, CancellationToken token = default(CancellationToken))
        {
            var region = GetRegion(platformId ?? PlatformId);
            return PostAsync<long>($"{GetTournamentBaseUrl(settings.UseTournamentStub)}/providers", "tournament/providers", new { region, url },
                regionalProxy, token);
        }

        /// <summary>
        /// Registers the current client as a tournament provider. This method uses the Tournament API. This endpoint is only accessible if you have a tournament API key.
        /// IMPORTANT: if you are using an interim API key, you must set <see cref="RiotClientSettings.UseTournamentStub"/> to true before calling this method.
        /// </summary>
        /// <param name="url">The provider's callback URL to which tournament game results in this region should be posted. The URL must be well-formed, use the http or https protocol, and use the default port for the protocol (http URLs must use port 80, https URLs must use port 443).</param>
        /// <param name="platformId">The platform ID of the region in which the provider will be running tournaments. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<long> CreateTournamentProviderAsync(string url, string platformId, CancellationToken token)
        {
            return CreateTournamentProviderAsync(url, platformId, RegionalProxy.Americas, token);
        }

        /// <summary>
        /// Creates a tournament. This method uses the Tournament API. This endpoint is only accessible if you have a tournament API key.
        /// IMPORTANT: if you are using an interim API key, you must set <see cref="RiotClientSettings.UseTournamentStub"/> to true before calling this method.
        /// </summary>
        /// <param name="providerId">The providerId obtained from CreateTournamentProviderAsync.</param>
        /// <param name="name">The optional name of the tournament.</param>
        /// <param name="regionalProxy">The name of the regional proxy service. This should equal one of the <see cref="RegionalProxy"/> values.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<long> CreateTournamentAsync(long providerId, string name = null, string regionalProxy = RegionalProxy.Americas, CancellationToken token = default(CancellationToken))
        {
            return PostAsync<long>($"{GetTournamentBaseUrl(settings.UseTournamentStub)}/tournaments", "tournament/tournaments", new { name, providerId },
                regionalProxy, token);
        }

        /// <summary>
        /// Creates a tournament. This method uses the Tournament API. This endpoint is only accessible if you have a tournament API key.
        /// IMPORTANT: if you are using an interim API key, you must set <see cref="RiotClientSettings.UseTournamentStub"/> to true before calling this method.
        /// </summary>
        /// <param name="providerId">The providerId obtained from CreateTournamentProviderAsync.</param>
        /// <param name="name">The optional name of the tournament.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<long> CreateTournamentAsync(long providerId, string name, CancellationToken token)
        {
            return CreateTournamentAsync(providerId, name, RegionalProxy.Americas, token);
        }

        /// <summary>
        /// Creates one or more tournament codes. This method uses the Tournament API. This endpoint is only accessible if you have a tournament API key.
        /// IMPORTANT: if you are using an interim API key, you must set <see cref="RiotClientSettings.UseTournamentStub"/> to true before calling this method.
        /// </summary>
        /// <param name="tournamentId">The tournament ID obtained from CreateTournamentAsync.</param>
        /// <param name="count">The number of codes to create (max 1000).</param>
        /// <param name="allowedSummonerIds">Optional list of participants in order to validate the players eligible to join the lobby.</param>
        /// <param name="mapType">The map type of the game. This should equal one of the <see cref="MapType"/> values. Note that <see cref="MapType.CRYSTAL_SCAR"/> is not allowed.</param>
        /// <param name="pickType">The pick type of the game. This should equal one of the <see cref="PickType"/> values.</param>
        /// <param name="spectatorType">The spectator type of the game. This should equal one of the <see cref="SpectatorType"/> values.</param>
        /// <param name="teamSize">The team size of the game. Valid values are 1-5.</param>
        /// <param name="metadata">Optional string that may contain any data in any format, if specified at all. Used to denote any custom information about the game.</param>
        /// <param name="regionalProxy">The name of the regional proxy service. This should equal one of the <see cref="RegionalProxy"/> values.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<List<string>> CreateTournamentCodeAsync(long tournamentId, int? count = null, List<long> allowedSummonerIds = null, string mapType = MapType.SUMMONERS_RIFT,
            string pickType = PickType.TOURNAMENT_DRAFT, string spectatorType = SpectatorType.ALL, int teamSize = 5, string metadata = null, string regionalProxy = RegionalProxy.Americas,
            CancellationToken token = default(CancellationToken))
        {
            var queryParameters = new Dictionary<string, object> { { "tournamentId", tournamentId } };
            if (count != null)
                queryParameters["count"] = count;
            return PostAsync<List<string>>($"{GetTournamentBaseUrl(settings.UseTournamentStub)}/codes", "tournament/codes", new
            {
                allowedSummonerIds,
                mapType,
                pickType,
                spectatorType,
                teamSize,
                metadata
            }, regionalProxy, token, queryParameters);
        }

        /// <summary>
        /// Creates one or more tournament codes. This method uses the Tournament API. This endpoint is only accessible if you have a tournament API key.
        /// IMPORTANT: if you are using an interim API key, you must set <see cref="RiotClientSettings.UseTournamentStub"/> to true before calling this method.
        /// </summary>
        /// <param name="tournamentId">The tournament ID obtained from CreateTournamentAsync.</param>
        /// <param name="count">The number of codes to create (max 1000).</param>
        /// <param name="allowedSummonerIds">Optional list of participants in order to validate the players eligible to join the lobby.</param>
        /// <param name="mapType">The map type of the game. This should equal one of the <see cref="MapType"/> values. Note that <see cref="MapType.CRYSTAL_SCAR"/> is not allowed.</param>
        /// <param name="pickType">The pick type of the game. This should equal one of the <see cref="PickType"/> values.</param>
        /// <param name="spectatorType">The spectator type of the game. This should equal one of the <see cref="SpectatorType"/> values.</param>
        /// <param name="teamSize">The team size of the game. Valid values are 1-5.</param>
        /// <param name="metadata">Optional string that may contain any data in any format, if specified at all. Used to denote any custom information about the game.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<List<string>> CreateTournamentCodeAsync(long tournamentId, int? count, List<long> allowedSummonerIds, string mapType,
            string pickType, string spectatorType, int teamSize, string metadata, CancellationToken token)
        {
            return CreateTournamentCodeAsync(tournamentId, count, allowedSummonerIds, mapType, pickType, spectatorType, teamSize, metadata, RegionalProxy.Americas, token);
        }

        /// <summary>
        /// Saves changes to a tournament code. This method uses the Tournament API. This endpoint is only accessible if you have a tournament API key.
        /// This method does NOT support the tournament stub API.
        /// </summary>
        /// <param name="tournamentCode">The definition for the tournament code(s) to create.</param>
        /// <param name="count">The number of codes to create (max 1000).</param>
        /// <param name="regionalProxy">The name of the regional proxy service. This should equal one of the <see cref="RegionalProxy"/> values.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<List<string>> CreateTournamentCodeAsync(TournamentCode tournamentCode, int? count = null, string regionalProxy = RegionalProxy.Americas, CancellationToken token = default(CancellationToken))
        {
            return CreateTournamentCodeAsync(tournamentCode.TournamentId, count, tournamentCode.Participants, tournamentCode.Map, tournamentCode.PickType, tournamentCode.Spectators,
                tournamentCode.TeamSize, tournamentCode.MetaData, regionalProxy, token);
        }

        /// <summary>
        /// Saves changes to a tournament code. This method uses the Tournament API. This endpoint is only accessible if you have a tournament API key.
        /// This method does NOT support the tournament stub API.
        /// </summary>
        /// <param name="tournamentCode">The definition for the tournament code(s) to create.</param>
        /// <param name="count">The number of codes to create (max 1000).</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<List<string>> CreateTournamentCodeAsync(TournamentCode tournamentCode, int? count, CancellationToken token)
        {
            return CreateTournamentCodeAsync(tournamentCode, count, RegionalProxy.Americas, token);
        }

        /// <summary>
        /// Gets the details of a tournament code. This method uses the Tournament API. This endpoint is only accessible if you have a tournament API key.
        /// This method does NOT support the tournament stub API.
        /// </summary>
        /// <param name="tournamentCode">The tournament code obtained from CreateTournamentCodeAsync.</param>
        /// <param name="regionalProxy">The name of the regional proxy service. This should equal one of the <see cref="RegionalProxy"/> values.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>The tournament code details.</returns>
        public Task<TournamentCode> GetTournamentCodeAsync(string tournamentCode, string regionalProxy = RegionalProxy.Americas, CancellationToken token = default(CancellationToken))
        {
            return GetAsync<TournamentCode>($"{GetTournamentBaseUrl(false)}/codes/{tournamentCode}", "tournament/codes/{tournamentCode}",
                regionalProxy, token);
        }

        /// <summary>
        /// Gets the details of a tournament code. This method uses the Tournament API. This endpoint is only accessible if you have a tournament API key.
        /// This method does NOT support the tournament stub API.
        /// </summary>
        /// <param name="tournamentCode">The tournament code obtained from CreateTournamentCodeAsync.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>The tournament code details.</returns>
        public Task<TournamentCode> GetTournamentCodeAsync(string tournamentCode, CancellationToken token)
        {
            return GetTournamentCodeAsync(tournamentCode, RegionalProxy.Americas, token);
        }

        /// <summary>
        /// Saves changes to a tournament code. This method uses the Tournament API. This endpoint is only accessible if you have a tournament API key.
        /// This method does NOT support the tournament stub API.
        /// </summary>
        /// <param name="tournamentCode">The tournament code obtained from CreateTournamentCodeAsync.</param>
        /// <param name="allowedSummonerIds">Optional list of participants in order to validate the players eligible to join the lobby.</param>
        /// <param name="mapType">The map type of the game. This should equal one of the <see cref="MapType"/> values. Note that <see cref="MapType.CRYSTAL_SCAR"/> is not allowed.</param>
        /// <param name="pickType">The pick type of the game. This should equal one of the <see cref="PickType"/> values.</param>
        /// <param name="spectatorType">The spectator type of the game. This should equal one of the <see cref="SpectatorType"/> values.</param>
        /// <param name="regionalProxy">The name of the regional proxy service. This should equal one of the <see cref="RegionalProxy"/> values.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task UpdateTournamentCodeAsync(string tournamentCode, List<long> allowedSummonerIds = null, string mapType = MapType.SUMMONERS_RIFT,
            string pickType = PickType.TOURNAMENT_DRAFT, string spectatorType = SpectatorType.ALL, string regionalProxy = RegionalProxy.Americas,
            CancellationToken token = default(CancellationToken))
        {
            return PutAsync<object>($"{GetTournamentBaseUrl(false)}/codes/{tournamentCode}", "tournament/codes/{tournamentCode}", new
            {
                allowedSummonerIds,
                mapType,
                pickType,
                spectatorType
            }, regionalProxy, token);
        }

        /// <summary>
        /// Saves changes to a tournament code. This method uses the Tournament API. This endpoint is only accessible if you have a tournament API key.
        /// This method does NOT support the tournament stub API.
        /// </summary>
        /// <param name="tournamentCode">The tournament code obtained from CreateTournamentCodeAsync.</param>
        /// <param name="allowedSummonerIds">Optional list of participants in order to validate the players eligible to join the lobby.</param>
        /// <param name="mapType">The map type of the game. This should equal one of the <see cref="MapType"/> values. Note that <see cref="MapType.CRYSTAL_SCAR"/> is not allowed.</param>
        /// <param name="pickType">The pick type of the game. This should equal one of the <see cref="PickType"/> values.</param>
        /// <param name="spectatorType">The spectator type of the game. This should equal one of the <see cref="SpectatorType"/> values.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task UpdateTournamentCodeAsync(string tournamentCode, List<long> allowedSummonerIds, string mapType,
            string pickType, string spectatorType, CancellationToken token)
        {
            return UpdateTournamentCodeAsync(tournamentCode, allowedSummonerIds, mapType, pickType, spectatorType, RegionalProxy.Americas, token);
        }

        /// <summary>
        /// Saves changes to a tournament code. This method uses the Tournament API. This endpoint is only accessible if you have a tournament API key.
        /// This method does NOT support the tournament stub API.
        /// </summary>
        /// <param name="tournamentCode">The tournament code to update. Only the Code, Participants, MapType, PickType, and SpectatorType properties are used.</param>
        /// <param name="regionalProxy">The name of the regional proxy service. This should equal one of the <see cref="RegionalProxy"/> values.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task UpdateTournamentCodeAsync(TournamentCode tournamentCode, string regionalProxy = RegionalProxy.Americas, CancellationToken token = default(CancellationToken))
        {
            return UpdateTournamentCodeAsync(tournamentCode.Code, tournamentCode.Participants, tournamentCode.Map, tournamentCode.PickType, tournamentCode.Spectators, regionalProxy, token);
        }

        /// <summary>
        /// Saves changes to a tournament code. This method uses the Tournament API. This endpoint is only accessible if you have a tournament API key.
        /// This method does NOT support the tournament stub API.
        /// </summary>
        /// <param name="tournamentCode">The tournament code to update. Only the Code, Participants, MapType, PickType, and SpectatorType properties are used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task UpdateTournamentCodeAsync(TournamentCode tournamentCode, CancellationToken token)
        {
            return UpdateTournamentCodeAsync(tournamentCode, RegionalProxy.Americas, token);
        }

        /// <summary>
        /// Gets the events that happened in the lobby of atournament code game. This method uses the Tournament API. This endpoint is only accessible if you have a tournament API key.
        /// IMPORTANT: if you are using an interim API key, you must set <see cref="RiotClientSettings.UseTournamentStub"/> to true before calling this method.
        /// </summary>
        /// <param name="tournamentCode">The tournament code obtained from CreateTournamentCodeAsync.</param>
        /// <param name="regionalProxy">The name of the regional proxy service. This should equal one of the <see cref="RegionalProxy"/> values.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>The tournament code details.</returns>
        public async Task<List<LobbyEvent>> GetTournamentCodeLobbyEventsAsync(string tournamentCode, string regionalProxy = RegionalProxy.Americas, CancellationToken token = default(CancellationToken))
        {
            var wrapper = await GetAsync<LobbyEventWrapper>($"{GetTournamentBaseUrl(settings.UseTournamentStub)}/lobby-events/by-code/{tournamentCode}",
                "tournament/lobby-events/by-code/{tournamentCode}",
                regionalProxy,
                token)
                .ConfigureAwait(false);
            return wrapper.EventList;
        }

        /// <summary>
        /// Gets the events that happened in the lobby of atournament code game. This method uses the Tournament API. This endpoint is only accessible if you have a tournament API key.
        /// IMPORTANT: if you are using an interim API key, you must set <see cref="RiotClientSettings.UseTournamentStub"/> to true before calling this method.
        /// </summary>
        /// <param name="tournamentCode">The tournament code obtained from CreateTournamentCodeAsync.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>The tournament code details.</returns>
        public Task<List<LobbyEvent>> GetTournamentCodeLobbyEventsAsync(string tournamentCode, CancellationToken token)
        {
            return GetTournamentCodeLobbyEventsAsync(tournamentCode, RegionalProxy.Americas, token);
        }

        /// <summary>
        /// Gets the base URL for tournament requests.
        /// </summary>
        /// <param name="stub">Indicates whether to use the tournament-stub API instead of the tournament API.</param>
        /// <returns>The base URL.</returns>
        protected string GetTournamentBaseUrl(bool stub)
        {
            return (stub ? "tournament-stub" : "tournament") + "/v3";
        }

        /// <summary>
        /// Gets the region for agiven platform ID.
        /// </summary>
        /// <param name="platformId">The platform ID.</param>
        /// <returns>A region.</returns>
        protected string GetRegion(string platformId)
        {
            switch (platformId)
            {
                case Models.PlatformId.BR1:
                    return "BR";
                case "BR":
                    return "BR";
                case Models.PlatformId.EUN1:
                    return "EUNE";
                case "EUNE":
                    return "EUNE";
                case Models.PlatformId.EUW1:
                    return "EUW";
                case "EUW":
                    return "EUW";
                case Models.PlatformId.JP1:
                    return "JP";
                case "JP":
                    return "JP";
                case Models.PlatformId.KR:
                    return "KR";
                case Models.PlatformId.LA1:
                    return "LAN";
                case "LAN":
                    return "LAN";
                case Models.PlatformId.LA2:
                    return "LAS";
                case "LAS":
                    return "LAS";
                case Models.PlatformId.NA1:
                    return "NA";
                case "NA":
                    return "NA";
                case Models.PlatformId.OC1:
                    return "OCE";
                case "OCE":
                    return "OCE";
                case Models.PlatformId.PBE1:
                    return "PBE";
                case "PBE":
                    return "PBE";
                case Models.PlatformId.RU:
                    return "RU";
                case Models.PlatformId.TR1:
                    return "TR";
                default:
                    throw new NotSupportedException($"Platform ID '{platformId}' is not supported.");
            }
        }
    }
}
