using System;
#if NET_45
using System.Runtime.Serialization;
using System.Security.Permissions;
#endif

namespace RiotNet
{
    /// <summary>
    /// Represents an error that occurs when a REST request fails because the requested resource was not found.
    /// </summary>
    public class NotFoundException : RestException
    {
        /// <summary>
        /// Creates a new <see cref="NotFoundException"/> instance.
        /// </summary>
        public NotFoundException()
            : this(null)
        { }

        /// <summary>
        /// Creates a new <see cref="NotFoundException"/> instance.
        /// </summary>
        /// <param name="response">The response.</param>
        public NotFoundException(RiotResponse response)
            : this(response, (Exception)null)
        { }

        /// <summary>
        /// Creates a new <see cref="NotFoundException"/> instance.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public NotFoundException(RiotResponse response, Exception innerException)
            : base(response, "The requested resource was not found.", innerException)
        { }

        /// <summary>
        /// Creates a new <see cref="NotFoundException"/> instance.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <param name="message">A message that describes the error.</param>
        public NotFoundException(RiotResponse response, string message)
            : base(response, message)
        { }

        /// <summary>
        /// Creates a new <see cref="NotFoundException"/> instance.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <param name="message">A message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public NotFoundException(RiotResponse response, string message, Exception innerException)
            : base(response, message, innerException)
        { }

#if NET_45
        /// <summary>
        /// Creates a new <see cref="NotFoundException"/> instance.
        /// </summary>
        /// <param name="info">The SerializationInfo that holds the serialized object data about the exception.</param>
        /// <param name="context">The StreamingContext that contains contextual information about the source or destination.</param>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected NotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
#endif
    }
}
