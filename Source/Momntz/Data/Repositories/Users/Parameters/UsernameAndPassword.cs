namespace Momntz.Data.Repositories.Users.Parameters
{
    public class UsernameAndPassword
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UsernameAndPassword" /> class.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        public UsernameAndPassword(string username, string password)
        {
            Username = username;
            Password = password;
        }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        public string Password { get; set; }
    }
}