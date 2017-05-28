using System;
#if NET_45
using System.Runtime.Serialization;
using System.Security.Permissions;
#endif

namespace RiotNet
{
    /// <summary>
    /// Represents an error that occurs when a REST request fails because it timed out or was cancelled.
    /// </summary>
    public class RestTimeoutException : RestException
    {
        /// <summary>
        /// Creates a new <see cref="RestTimeoutException"/> instance.
        /// </summary>
        public RestTimeoutException()
            : this(null)
        { }

        /// <summary>
        /// Creates a new <see cref="RestTimeoutException"/> instance.
        /// </summary>
        /// <param name="response">The response.</param>
        public RestTimeoutException(RiotResponse response)
            : this(response, (Exception)null)
        { }

        /// <summary>
        /// Creates a new <see cref="RestTimeoutException"/> instance.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public RestTimeoutException(RiotResponse response, Exception innerException)
            : base(response, "A REST request timed out.", innerException)
        { }

        /// <summary>
        /// Creates a new <see cref="RestTimeoutException"/> instance.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <param name="message">A message that describes the error.</param>
        public RestTimeoutException(RiotResponse response, string message)
            : base(response, message)
        { }

        /// <summary>
        /// Creates a new <see cref="RestTimeoutException"/> instance.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <param name="message">A message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public RestTimeoutException(RiotResponse response, string message, Exception innerException)
            : base(response, message, innerException)
        { }

#if NET_45
        /// <summary>
        /// Creates a new <see cref="RestTimeoutException"/> instance.
        /// </summary>
        /// <param name="info">The SerializationInfo that holds the serialized object data about the exception.</param>
        /// <param name="context">The StreamingContext that contains contextual information about the source or destination.</param>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected RestTimeoutException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
#endif
    }
}
