using System.Collections.Generic;

namespace Momntz.Model
{
    public class User
    {
        /// <summary> Gets or sets the username. </summary>
        /// <value> The username. </value>
        public string Username { get; set; }

        /// <summary> Gets or sets the email. </summary>
        /// <value> The email. </value>
        public string Email { get; set; }

        public List<Name> Names { get; set; }

        /// <summary> Gets or sets the user status. </summary>
        /// <value> The user status. </value>
        public UserStatus UserStatus { get; set; }

        public string Password { get; set; }
    }

    public enum UserStatus
    {
        Inactive,
        Active,
        Ghost
    }
}
