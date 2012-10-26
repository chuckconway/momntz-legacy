namespace Momntz.Model
{
    public class User
    {
        /// <summary> Gets or sets the username. </summary>
        /// <value> The username. </value>
        public virtual string Username { get; set; }

        /// <summary> Gets or sets the email. </summary>
        /// <value> The email. </value>
        public virtual string Email { get; set; }

        /// <summary> Gets or sets the user status. </summary>
        /// <value> The user status. </value>
        public virtual int UserStatus { get; set; }

        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        /// <value>The full name.</value>
        public virtual string FullName { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        public virtual string Password { get; set; }
    }

    public class UserStatus
    {
        public const int Inactive = 0;
        public const int Active = 1;
        public const int Ghost = 2;
    }
}
