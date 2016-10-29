namespace RiotNet
{
    /// <summary>
    /// Represents a method that will handle an event that could trigger a retry of a request.
    /// </summary>
    /// <param name="sender">The object that created the event.</param>
    /// <param name="e">Arguments for the event.</param>
    public delegate void RetryEventHandler(object sender, RetryEventArgs e);

    /// <summary>
    /// Contains event data for an error that could trigger a retry of a request.
    /// </summary>
    public class RetryEventArgs : ResponseEventArgs
    {
        private readonly int attemptCount;

        /// <summary>
        /// Creates a new <see cref="RetryEventArgs"/> instance.
        /// </summary>
        /// <param name="response">The response for the request that caused the event.</param>
        /// <param name="attemptCount">The number of times that the same request has been attempted.</param>
        public RetryEventArgs(RiotResponse response, int attemptCount)
            : base(response)
        {
            this.attemptCount = attemptCount;
        }

        /// <summary>
        /// Gets the number of times that the same request has been attempted.
        /// </summary>
        public int AttemptCount
        {
            get { return attemptCount; }
        }

        /// <summary>
        /// Gets or sets whether the sender should retry the operation after the event handler has finished executing.
        /// </summary>
        public bool Retry { get; set; }
    }
}
