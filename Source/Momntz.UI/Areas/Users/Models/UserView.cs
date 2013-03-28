using System.Collections.Generic;
using Momntz.Data.Projections.Momentos;

namespace Momntz.UI.Areas.Users.Models
{
    public class UserView : ISignedUser
    {
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is authenticated user.
        /// </summary>
        /// <value><c>true</c> if this instance is authenticated user; otherwise, <c>false</c>.</value>
        public bool IsAuthenticatedUser { get; set; }

        /// <summary>
        /// Gets or sets the momentos.
        /// </summary>
        /// <value>The momentos.</value>
        public IList<MomentoWithMedia> Momentos { get; set; }
    }
}