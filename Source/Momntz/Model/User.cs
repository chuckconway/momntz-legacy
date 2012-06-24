namespace Momntz.Model
{
    public class User
    {
        /// <summary> Gets or sets the username. </summary>
        /// <value> The username. </value>
        public string Username { get; set; }

        /// <summary> Gets or sets the name of the first. </summary>
        /// <value> The name of the first. </value>
        public string FirstName { get; set; }

        /// <summary> Gets or sets the name of the last. </summary>
        /// <value> The name of the last. </value>
        public string LastName { get; set; }

        /// <summary> Gets or sets the email. </summary>
        /// <value> The email. </value>
        public string Email { get; set; }

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
