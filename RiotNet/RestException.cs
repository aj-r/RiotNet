using System;
using System.Runtime.Serialization;
using System.Security.Permissions;
using RestSharp;

namespace RiotNet
{
    /// <summary>
    /// Represents an error that occurred during a REST request.
    /// </summary>
    public class RestException : Exception
    {
        private IRestResponse response;

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
        public RestException(IRestResponse response)
            : this(response, "A REST request failed." + (response != null && (int)response.StatusCode > 0 ? " Status code: " + (int)response.StatusCode : string.Empty))
        { }

        /// <summary>
        /// Creates a new <see cref="RestException"/> instance.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <param name="message">A message that describes the error.</param>
        public RestException(IRestResponse response, string message)
            : base(message)
        {
            this.response = response;
        }

        /// <summary>
        /// Creates a new <see cref="RestException"/> instance.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <param name="message">A message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public RestException(IRestResponse response, string message, Exception innerException)
            : base(message, innerException)
        {
            this.response = response;
        }

        /// <summary>
        /// Creates a new <see cref="RestException"/> instance.
        /// </summary>
        /// <param name="info">The SerializationInfo that holds the serialized object data about the exception.</param>
        /// <param name="context">The StreamingContext that contains contextual information about the source or destination.</param>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected RestException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            response = (IRestResponse)info.GetValue("Response", typeof(IRestResponse));
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

        /// <summary>
        /// Gets the response.
        /// </summary>
        public IRestResponse Response
        {
            get { return response; }
        }
    }
}
