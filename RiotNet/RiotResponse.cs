using System;
using System.Net.Http;

namespace RiotNet
{
    /// <summary>
    /// A wrapper for the 
    /// </summary>
    public class RiotResponse
    {
        /// <summary>
        /// Creates a new <see cref="RiotResponse"/> isntance.
        /// </summary>
        /// <param name="response">The underlying response from the server.</param>
        /// <param name="exception">The exception thrown during the request, if any.</param>
        /// <param name="timedOut">Whether the request timed out or was cancelled.</param>
        public RiotResponse(HttpResponseMessage response, Exception exception = null, bool timedOut = false)
        {
            Response = response;
            Exception = exception;
            TimedOut = timedOut;
        }

        /// <summary>
        /// Gets the underlying response from the server.
        /// </summary>
        public HttpResponseMessage Response { get; private set; }

        /// <summary>
        /// Gets the exception thrown during the request, if any.
        /// </summary>
        public Exception Exception { get; private set; }

        /// <summary>
        /// Gets whether the request timed out or was cancelled.
        /// </summary>
        public bool TimedOut { get; private set; }
    }

}
