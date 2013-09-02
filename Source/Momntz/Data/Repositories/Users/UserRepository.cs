using System.Collections.Generic;
using System.Linq;
using ChuckConway.Cryptography;
using Hypersonic;
using Momntz.Core.Extensions;
using Momntz.Data.Projections.Users;
using Momntz.Data.Repositories.Users.Parameters;
using Momntz.Data.Schema;
using NHibernate;
using NHibernate.Criterion;
using ISession = NHibernate.ISession;
using ITransaction = NHibernate.ITransaction;

namespace Momntz.Data.Repositories.Users
{
    /// <summary>
    ///     Class UserRepository.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly ICrypto _crypto;
        private readonly ISessionFactory _sessionFactory;
        private readonly ISession _session;
        private readonly IDatabase _database;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <param name="database">The database.</param>
        /// <param name="crypto">The crypto.</param>
        /// <param name="sessionFactory">The session factory.</param>
        public UserRepository(ISession session, IDatabase database, ICrypto crypto, ISessionFactory sessionFactory)
        {
            _session = session;
            _database = database;
            _crypto = crypto;
            _sessionFactory = sessionFactory;
        }

        /// <summary>
        ///     Creates the specified parameters.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        public void Create(CreateUserParameters parameters)
        {
            parameters.Password = _crypto.Hash(parameters.Password);

            using (ITransaction trans = _session.BeginTransaction())
            {
                _session.CreateCommandProcedure("User_Create", parameters)
                    .ExecuteUpdate();

                trans.Commit();
            }
        }

        /// <summary>
        /// Authenticates the user.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>AuthenticatedUser.</returns>
        public AuthenticatedUser AuthenticateUser(UsernameAndPassword args)
        {
            var single = _database.Single<User, object>("User_GetOwnerPasswordByUsername", new { args.Username }, _database.AutoPopulate<User>);

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

        /// <summary>
        /// Executes the specified args.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns>System.String.</returns>
        public string CreateUsername(CreateUsername args)
        {
            string username = GetName(args.Username, args.Users);
            return username;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="users">The users.</param>
        /// <returns>System.String.</returns>
        private string GetName(string username, IList<User> users)
        {
            //loading all the username will not scale, but for now it will work.
            bool found = Found(username, users); ;
            string name = username;
            int count = 1;

            while (found)
            {
                string temp = username + "." + count;
                found = Found(temp, users);

                name = temp;
                count++;
            }

            return name;
        }

        /// <summary>
        /// Founds the specified username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="users">The users.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
        private static bool Found(string username, IEnumerable<User> users)
        {
            bool found = users.Any(u => u.Username == username);
            return found;
        }

        /// <summary>
        /// Gets the display name.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>DisplayName.</returns>
        public DisplayName GetDisplayName(string username)
        {
            using (var trans = _session.BeginTransaction())
            {
                var item = _session.QueryOver<User>()
                                   .Where(u => u.Username == username)
                                   .SingleOrDefault();


                trans.Commit();
                return new DisplayName() { Fullname = item.FullName };
            }
        }

        /// <summary>
        /// Gets the active users.
        /// </summary>
        /// <returns>IList{ActiveUsername}.</returns>
        public IList<ActiveUsername> GetActiveUsers()
        {
            using (var session = _sessionFactory.OpenSession())
            using (var trans = session.BeginTransaction())
            {
                var items = session.QueryOver<User>()
                    .Where(Restrictions.Or(Restrictions.Eq("UserStatus", UserStatus.Active), Restrictions.Eq("UserStatus", UserStatus.Ghost)))
                    .List()
                    .Select(r => new ActiveUsername() { Username = r.Username })
                    .ToList();

                trans.Commit();

                return items;
            }
        }
    }
}