using Hypersonic;
using Momntz.Data.Projections.Users;
using Momntz.Infrastructure.Security;
using Momntz.Model;

namespace Momntz.Data.ProjectionHandlers.Users
{
    public class AuthenticatedUserHandler : IProjectionHandler<UsernameAndPassword, AuthenticatedUser>
    {
        private readonly IDatabase _database;
        private readonly ICrypto _crypto;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <param name="crypto">The crypto.</param>
        public AuthenticatedUserHandler(IDatabase database, ICrypto crypto)
        {
            _database = database;
            _crypto = crypto;
        }

        /// <summary> Executes the given arguments. </summary>
        /// <param name="args"> The arguments. </param>
        /// <returns> . </returns>
        public AuthenticatedUser Execute(UsernameAndPassword args)
        {
            var single = _database.Single<User, object>("User_GetOwnerPasswordByUsername", new { args.Username },
                                                                 _database.AutoPopulate<User>);

            bool isValid = ValidatePassword(args, single);
            return (isValid ? new AuthenticatedUser { Username = single.Username } : null);
        }

        /// <summary>
        /// Validates the password.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <param name="single">The single.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
        private bool ValidatePassword(UsernameAndPassword args, User single)
        {
            bool isValid = false;
            if (single != null)
            {
                try
                {
                    isValid = _crypto.IsMatch(args.Password, single.Password);
                }
                catch
                {
                    isValid = false;
                }
            }
            return isValid;
        }
    }

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
