using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        /// Gets or sets service status.
        /// </summary>
        public ServerStatus Status { get; set; }
    }
}
