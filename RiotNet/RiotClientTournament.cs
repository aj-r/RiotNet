using System.Threading.Tasks;
using RestSharp;
using RiotNet.Models;

namespace RiotNet
{
    public partial class RiotClient
    {
        /// <summary>
        /// Gets the currently supported version of the Tournament API that the client communicates with.
        /// </summary>
        public string TournamentApiVersion { get { return "v1"; } }

        private IRestRequest CreateTournamentProviderRequest()
        {
            var request = Post("tournament/public/{version}/provider");
            request.AddUrlSegment("version", TournamentApiVersion);
            return request;
        }

        /// <summary>
        /// Registers the current client as a tournament provider.
        /// </summary>
        /// <returns>The registered providerID.</returns>
        public string CreateTournamentProvider()
        {
            var s = Execute<RestSharpString>(CreateTournamentProviderRequest());
            return s != null ? s.Value : null;
        }

        /// <summary>
        /// Registers the current client as a tournament provider.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task<string> CreateTournamentProviderAsync()
        {
            var s = await ExecuteAsync<RestSharpString>(CreateTournamentProviderRequest());
            return s != null ? s.Value : null;
        }

        private IRestRequest CreateTournamentRequest(string providerID)
        {
            var request = Post("tournament/public/{version}/tournament");
            request.AddUrlSegment("version", TournamentApiVersion);
            request.AddQueryParameter("providerID", providerID);
            return request;
        }

        /// <summary>
        /// Creates a tournament.
        /// </summary>
        /// <param name="providerID">The providerID obtained from <see cref="CreateTournamentProvider"/>.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public string CreateTournament(string providerID)
        {
            var s = Execute<RestSharpString>(CreateTournamentProviderRequest());
            return s != null ? s.Value : null;
        }

        /// <summary>
        /// Creates a tournament.
        /// </summary>
        /// <param name="providerID">The providerID obtained from <see cref="CreateTournamentProviderAsync"/>.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task<string> CreateTournamentAsync(string providerID)
        {
            var s = await ExecuteAsync<RestSharpString>(CreateTournamentProviderRequest());
            return s != null ? s.Value : null;
        }
    }
}
