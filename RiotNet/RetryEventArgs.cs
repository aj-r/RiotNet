using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotNet
{
    /// <summary>
    /// Contains event data for an error that could trigger a retry of an operation.
    /// </summary>
    public class RetryEventArgs : EventArgs
    {
        private readonly int attemptCount;

        /// <summary>
        /// Creates a new <see cref="RetryEventArgs"/> instance.
        /// </summary>
        /// <param name="attemptCount">The number of times that the same request has been attempted.</param>
        public RetryEventArgs(int attemptCount)
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
