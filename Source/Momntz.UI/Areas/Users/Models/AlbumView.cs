using System.Collections.Generic;
using Momntz.Data.Projections;

namespace Momntz.UI.Areas.Users.Models
{
    public class GroupView : ISignedUser
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
        /// Gets or sets the items.
        /// </summary>
        /// <value>The items.</value>
        public List<IGroupItem> Items { get; set; }
    }
}