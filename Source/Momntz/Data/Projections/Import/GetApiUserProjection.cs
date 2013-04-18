using System;
using Momntz.Data.Commands;

namespace Momntz.Data.Projections.Import
{
    public class GetApiUserProjection : IProjection
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
