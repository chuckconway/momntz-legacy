namespace Momntz.Data.Commands.Users
{
    public class CreateUserCommand : ICommand
    {
        /// <summary> Gets or sets the username. </summary>
        /// <value> The username. </value>
        public string Username { get; set; }

        /// <summary> Gets or sets the email. </summary>
        /// <value> The email. </value>
        public string Email { get; set; }

        /// <summary> Gets or sets the name of the first. </summary>
        /// <value> The name of the first. </value>
        public string FirstName { get; set; }

        /// <summary> Gets or sets the name of the last. </summary>
        /// <value> The name of the last. </value>
        public string LastName { get; set; }

        /// <summary> Gets or sets the password. </summary>
        /// <value> The password. </value>
        public string Password { get; set; }

        /// <summary> Constructor. </summary>
        /// <param name="username">  The username. </param>
        /// <param name="email">     The email. </param>
        /// <param name="firstName"> Name of the first. </param>
        /// <param name="lastName">  Name of the last. </param>
        /// <param name="password">  The password. </param>
        public CreateUserCommand(string username, string email, string firstName, string lastName, string password)
        {
            Username = username;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
        }
    }
}
