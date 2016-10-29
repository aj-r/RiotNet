using System;
using System.Net.Http;

namespace RiotNet
{
    /// <summary>
    /// A wrapper for the 
    /// </summary>
    public class RiotResponse
    {
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
        /// Gets whether the request timed out.
        /// </summary>
        public bool TimedOut { get; private set; }
    }

}
