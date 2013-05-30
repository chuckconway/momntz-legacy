using System.Collections.Generic;
using Momntz.Data.Schema;


namespace Momntz.Data.Projections.Users
{
    public class CreateUsername:IProjection
    {
        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>The users.</value>
        public IList<User> Users { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        public string Username { get; set; }
    }
}
