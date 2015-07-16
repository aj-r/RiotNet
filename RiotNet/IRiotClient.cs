using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RiotNet.Models;

namespace RiotNet
{
    /// <summary>
    /// A client that interacts with the Riot Games API.
    /// </summary>
    public interface IRiotClient
    {
        /// <summary>
        /// Occurs when the client executes a request when the API rate limit has been exceeded.
        /// </summary>
        event EventHandler<RetryEventArgs> RateLimitExceeded;

        /// <summary>
        /// Occurs when the a request times out.
        /// </summary>
        event EventHandler<RetryEventArgs> RequestTimedOut;

        /// <summary>
        /// Occurs when the client fails to connect to the server while executing a request.
        /// </summary>
        event EventHandler<RetryEventArgs> ConnectionFailed;

        /// <summary>
        /// Gets the settings for the <see cref="IRiotClient"/>.
        /// </summary>
        RiotClientSettings Settings { get; }
        
        /// <summary>
        /// Gets the master league.
        /// </summary>
        /// <param name="type">The queue type.</param>
        /// <returns>The master league.</returns>
        Task<League> GetMasterLeagueTaskAsync(RankedQueue type);
    }
}
