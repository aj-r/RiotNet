using System;

namespace RiotNet
{
    /// <summary>
    /// Represents a method that will handle an event that contains response data.
    /// </summary>
    /// <param name="sender">The object that created the event.</param>
    /// <param name="e">Arguments for the event.</param>
    public delegate void ResponseEventHandler(object sender, ResponseEventArgs e);

    /// <summary>
    /// Contains event data for an event that contains an HTTP response.
    /// </summary>
    public class ResponseEventArgs : EventArgs
    {
        private readonly RiotResponse response;

        /// <summary>
        /// Creates a new <see cref="ResponseEventArgs"/> instance.
        /// </summary>
        /// <param name="response">The response for the request that caused the event.</param>
        public ResponseEventArgs(RiotResponse response)
        {
            this.response = response;
        }

        /// <summary>
        /// Gets the response for the request that caused the event.
        /// </summary>
        public RiotResponse Response
        {
            get { return response; }
        }
    }
}
