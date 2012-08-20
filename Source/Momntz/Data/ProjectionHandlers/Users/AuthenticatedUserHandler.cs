using Hypersonic;
using Momntz.Data.Projections.Users;
using Momntz.Infrastructure.Security;
using Momntz.Model;

namespace Momntz.Data.ProjectionHandlers.Users
{
    public class AuthenticatedUserHandler : IProjectionHandler<UsernameAndPassword, AuthenticatedUser>
    {
        private readonly IMomntzSession _session;
        private readonly ICrypto _crypto;

        /// <summary> Constructor. </summary>
        /// <param name="session"> The session. </param>
        /// <param name="crypto">  The crypto. </param>
        public AuthenticatedUserHandler(IMomntzSession session, ICrypto crypto)
        {
            _session = session;
            _crypto = crypto;
        }

        /// <summary> Executes the given arguments. </summary>
        /// <param name="args"> The arguments. </param>
        /// <returns> . </returns>
        public AuthenticatedUser Execute(UsernameAndPassword args)
        {
            var single = _session.Session.Database.Single<User, object>("User_GetOwnerPasswordByUsername", new {args.Username},
                                                                 _session.Session.Database.AutoPopulate<User>);

            bool isValid = ValidatePassword(args, single);
            return (isValid ? new AuthenticatedUser { Username = single.Username } : null);
        }

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
        public UsernameAndPassword(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
