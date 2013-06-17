namespace Momntz.Data.Commands.Users
{
    public class CreateUserCommand : ICommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateUserCommand"/> class.
        /// </summary>
        public CreateUserCommand()
        { 
            //required for automapper
        }

        /// <summary> Gets or sets the username. </summary>
        /// <value> The username. </value>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>The created by.</value>
        public string CreatedBy { get; set; }

        /// <summary> Gets or sets the email. </summary>
        /// <value> The email. </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        public string FirstName { get; set; }


        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        public string LastName { get; set; }

        /// <summary> Gets or sets the password. </summary>
        /// <value> The password. </value>
        public string Password { get; set; }

        /// <summary> Constructor. </summary>
        /// <param name="username">  The username. </param>
        /// <param name="createdBy"> </param>
        /// <param name="email">     The email. </param>
        /// <param name="firstName"> Name of the first. </param>
        /// <param name="lastName">  Name of the last. </param>
        /// <param name="password">  The password. </param>
        public CreateUserCommand(string username, string createdBy, string email,  string firstName, string lastName, string password)
        {
            Username = username;
            CreatedBy = createdBy;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
        }
    }
}
