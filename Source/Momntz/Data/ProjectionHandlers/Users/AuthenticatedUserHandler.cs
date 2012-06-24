using Hypersonic;
using Momntz.Data.Projections.Users;
using Momntz.Model;

namespace Momntz.Data.ProjectionHandlers.Users
{
    public class AuthenticatedUserHandler : IProjectionHandler<UsernameAndPassword, AuthenticatedUser>
    {
        private readonly ISession _session;

        public AuthenticatedUserHandler(ISession session)
        {
            _session = session;
        }

        public AuthenticatedUser Execute(UsernameAndPassword args)
        {
            var single = _session.Query<User>()
                .Where(u => u.Username == args.Username && 
                    u.Password == args.Password && 
                    u.UserStatus == UserStatus.Active)
                    .Single();

            return (single == null ? null : new AuthenticatedUser() {Username = single.Username});
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
