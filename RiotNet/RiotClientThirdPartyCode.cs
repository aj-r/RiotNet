using System.Threading;
using System.Threading.Tasks;

namespace RiotNet
{
    public partial interface IRiotClient
    {
        /// <summary>
        /// Gets a code that a third-party application can use to verify a summoner.
        /// </summary>
        /// <param name="summonerId">The summoner ID.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>For KR summoners, a 404 will always be returned.</remarks>
        Task<string> GetThirdPartyCodeAsync(long summonerId, string platformId = null, CancellationToken token = default(CancellationToken));
    }

    public partial class RiotClient
    {
        private const string thirdPartyCodeBasePath = "platform/v3/third-party-code";

        /// <summary>
        /// Gets a code that a third-party application can use to verify a summoner.
        /// </summary>
        /// <param name="summonerId">The summoner ID.</param>
        /// <param name="platformId">The platform ID of the server to connect to. This should equal one of the <see cref="Models.PlatformId"/> values. If unspecified, the <see cref="PlatformId"/> property will be used.</param>
        /// <param name="token">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>For KR summoners, a 404 will always be returned.</remarks>
        public Task<string> GetThirdPartyCodeAsync(long summonerId, string platformId = null, CancellationToken token = default(CancellationToken))
        {
            return GetAsync<string>($"{thirdPartyCodeBasePath}/by-summoner/{summonerId}", $"{thirdPartyCodeBasePath}/by-summoner/{{summonerId}}",
                platformId, token);
        }
    }
}
