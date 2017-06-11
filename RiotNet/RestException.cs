using System;
#if NET_45
using System.Runtime.Serialization;
using System.Security.Permissions;
#endif

namespace RiotNet
{
    /// <summary>
    /// Represents an error that occurred during a REST request.
    /// </summary>
    public class RestException : Exception
    {
        private readonly RiotResponse response;

        /// <summary>
        /// Creates a new <see cref="RestException"/> instance.
        /// </summary>
        public RestException()
            : this(null)
        { }

        /// <summary>
        /// Creates a new <see cref="RestException"/> instance.
        /// </summary>
        /// <param name="response">The response.</param>
        public RestException(RiotResponse response)
            : this(response, (Exception)null)
        { }

        /// <summary>
        /// Creates a new <see cref="RestException"/> instance.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <param name="message">A message that describes the error.</param>
        public RestException(RiotResponse response, string message)
            : this(response, message, null)
        { }

        /// <summary>
        /// Creates a new <see cref="RestException"/> instance.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public RestException(RiotResponse response, Exception innerException)
            : this(response, "A REST request failed." + (response?.Response?.StatusCode != null ? " Status code: " + (int)response.Response.StatusCode : string.Empty), innerException)
        { }

        /// <summary>
        /// Creates a new <see cref="RestException"/> instance.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <param name="message">A message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public RestException(RiotResponse response, string message, Exception innerException)
            : base(message, innerException)
        {
            this.response = response;
        }

#if NET_45
        /// <summary>
        /// Creates a new <see cref="RestException"/> instance.
        /// </summary>
        /// <param name="info">The SerializationInfo that holds the serialized object data about the exception.</param>
        /// <param name="context">The StreamingContext that contains contextual information about the source or destination.</param>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected RestException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            response = (RiotResponse)info.GetValue("Response", typeof(RiotResponse));
        }

        /// <summary>
        /// Populates the SerializationInfo with information about the exception.
        /// </summary>
        /// <param name="info">The SerializationInfo that holds the serialized object data about the exception.</param>
        /// <param name="context">The StreamingContext that contains contextual information about the source or destination.</param>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Response", response);
            base.GetObjectData(info, context);
        }
#endif

        /// <summary>
        /// Gets the response.
        /// </summary>
        public RiotResponse Response
        {
            get { return response; }
        }
    }
}
