using System;
using ChuckConway.Cloud.Queue;

namespace Momntz.Infrastructure.Instrumentation.Logging.Models
{
    public class QueueLogMessage : IMessage
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the endpoint.
        /// </summary>
        /// <value>The endpoint.</value>
        public string Endpoint { get; set; }
    }
}
