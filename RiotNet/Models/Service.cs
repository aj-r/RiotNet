using System.Collections.Generic;

namespace RiotNet.Models
{
    /// <summary>
    /// Represents server services.
    /// </summary>
    public class Service
    {
        /// <summary>
        /// Gets or sets list of service incidents.
        /// </summary>
        public List<Incident> Incidents { get; set; }

        /// <summary>
        /// Gets or sets the service name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the service tag name.
        /// </summary>
        public string Slug { get; set; }

        /// <summary>
        /// Gets or sets service status. This should equal one of the <see cref="ServerStatus"/> values.
        /// </summary>
        public string Status { get; set; }
    }
}
