﻿namespace Momntz.UI.Areas.Users.Models
{
    public interface ISignedUser
    {
        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        /// <value>The display name.</value>
        string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        string Username { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is authenticated user.
        /// </summary>
        /// <value><c>true</c> if this instance is authenticated user; otherwise, <c>false</c>.</value>
        bool IsAuthenticatedUser { get; set; }
    }

    public class SignedUser : ISignedUser
    {
        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        /// <value>The display name.</value>
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
    }
}
