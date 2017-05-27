namespace RiotNet
{
    /// <summary>
    /// Contains settings for a <see cref="RiotClient"/>.
    /// </summary>
    public class RiotClientSettings
    {
        /// <summary>
        /// Creates a new <see cref="RiotClientSettings"/> instance.
        /// </summary>
        public RiotClientSettings()
        { }

        /// <summary>
        /// Gets or sets the Riot API key to use.
        /// NOTE: If you are using a public repository, do NOT check you API key in to the repository.
        /// It is recommended to load your API key from a separate file (e.g. key.txt) that is ignored by your repository.
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// Gets or sets whether to use the tournament-stub API instead of the tournament API.
        /// </summary>
        public bool UseTournamentStub { get; set; } = false;

        /// <summary>
        /// Gets or sets how the <see cref="RiotClient"/> should handle the case where the request times out.
        /// </summary>
        public bool RetryOnTimeout { get; set; } = false;

        /// <summary>
        /// Gets or sets how the <see cref="RiotClient"/> should handle the case where the client fails to connect to the server.
        /// </summary>
        public bool RetryOnConnectionFailure { get; set; } = false;

        /// <summary>
        /// Gets or sets how the <see cref="RiotClient"/> should handle the case where the rate limit is exceeded.
        /// </summary>
        public bool RetryOnRateLimitExceeded { get; set; } = true;

        /// <summary>
        /// Gets or sets how the <see cref="RiotClient"/> should handle the case where server returns an error code of 500 or higher.
        /// </summary>
        /// <remarks>
        /// This is true by default because it seems that the Riot Games API intermittently returns 50x response codes. This can be resolved by re-sending the request.
        /// </remarks>
        public bool RetryOnServerError { get; set; } = true;

        /// <summary>
        /// Gets or sets whether the client should throw an exception if an error occurred during the request (that is, the request did not complete, or it completed with a response code of 400 or higher, except for 404 errors).
        /// </summary>
        public bool ThrowOnError { get; set; } = true;

        /// <summary>
        /// Gets or sets whether the client should throw an exception if the server responded with a Not Found (404) error.
        /// </summary>
        public bool ThrowOnNotFound { get; set; } = false;

        /// <summary>
        /// Gets or sets the maximum number of times that the same request should be attempted. Applies only if one of the RequestErrorHandling modes is set to Retry.
        /// </summary>
        public int MaxRequestAttempts { get; set; } = 3;
    }
}
