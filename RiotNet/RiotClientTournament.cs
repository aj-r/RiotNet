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

        private IRestRequest CreateTournamentProviderRequest(Region region, string url)
        {
            var request = Post("tournament/public/{version}/provider");
            request.AddUrlSegment("version", TournamentApiVersion);
            request.AddBody(new { region, url });
            return request;
        }

        /// <summary>
        /// Registers the current client as a tournament provider.
        /// </summary>
        /// <param name="region">The region in which the provider will be running tournaments.</param>
        /// <param name="url">The provider's callback URL to which tournament game results in this region should be posted.</param>
        /// <returns>The registered providerId.</returns>
        public long CreateTournamentProvider(Region region, string url)
        {
            return Execute<long>(CreateTournamentProviderRequest(region, url));
        }

        /// <summary>
        /// Registers the current client as a tournament provider.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<long> CreateTournamentProviderAsync(Region region, string url)
        {
            return ExecuteAsync<long>(CreateTournamentProviderRequest(region, url));
        }

        private IRestRequest CreateTournamentRequest(long providerId, string name)
        {
            var request = Post("tournament/public/{version}/tournament");
            request.AddUrlSegment("version", TournamentApiVersion);
            request.AddBody(new { name, providerId });
            return request;
        }

        /// <summary>
        /// Creates a tournament.
        /// </summary>
        /// <param name="providerId">The providerId obtained from <see cref="CreateTournamentProvider"/>.</param>
        /// <param name="name">The optional name of the tournament.</param>
        /// <returns>The tournamentId.</returns>
        public long CreateTournament(long providerId, string name = null)
        {
            return Execute<long>(CreateTournamentRequest(providerId, name));
        }

        /// <summary>
        /// Creates a tournament.
        /// </summary>
        /// <param name="providerId">The providerId obtained from <see cref="CreateTournamentProvider"/>.</param>
        /// <param name="name">The optional name of the tournament.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task<long> CreateTournamentAsync(long providerId, string name = null)
        {
            return ExecuteAsync<long>(CreateTournamentRequest(providerId, name));
        }

        private IRestRequest CreateTournamentCodeRequest(long tournamentId, int? count, List<long> allowedSummonerIds, MapType mapType,
            PickType pickType, SpectatorType spectatorType, int teamSize, string metadata)
        {
            var request = Post("tournament/public/{version}/tournament");
            request.AddUrlSegment("version", TournamentApiVersion);
            request.AddParameter("tournamentId", tournamentId, ParameterType.QueryString);
            if (count != null)
                request.AddParameter("count", count.Value, ParameterType.QueryString);
            request.AddBody(new { allowedSummonerIds, mapType, pickType, spectatorType, teamSize, metadata });
            return request;
        }

        /// <summary>
        /// Creates one or more tournament codes.
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
            PickType pickType = PickType.TOURNAMENT_DRAFT, SpectatorType spectatorType = SpectatorType.NONE, int teamSize = 5, string metadata = null)
        {
            return Execute<List<string>>(CreateTournamentCodeRequest(tournamentId, count, allowedSummonerIds, mapType, pickType, spectatorType, teamSize, metadata));
        }

        /// <summary>
        /// Creates one or more tournament codes.
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
            PickType pickType = PickType.TOURNAMENT_DRAFT, SpectatorType spectatorType = SpectatorType.NONE, int teamSize = 5, string metadata = null)
        {
            return ExecuteAsync<List<string>>(CreateTournamentCodeRequest(tournamentId, count, allowedSummonerIds, mapType, pickType, spectatorType, teamSize, metadata));
        }
    }
}
