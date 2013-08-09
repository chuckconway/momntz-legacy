using System;
using Momntz.Data.Queries;

namespace Momntz.Data.Projections.Connections
{
    public class ConnectionResult : IQueryParameters, IGroupItem
    {
        public string Username { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the create date.
        /// </summary>
        /// <value>The create date.</value>
        public DateTime? CreateDate { get; set; }
    }
}
