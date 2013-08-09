using System;
using Momntz.Data.Commands;
using Momntz.Data.Queries;

namespace Momntz.Data.Projections.Import
{
    public class GetApiUserQueryParameters : IQueryParameters
    {
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the API key.
        /// </summary>
        /// <value>The API key.</value>
        public Guid ApiKey { get; set; }
    }
}
