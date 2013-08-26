using System;
using System.Collections.Generic;
using System.Linq;
using Hypersonic;
using Momntz.Data.Projections.Import;
using Momntz.Data.Projections.Users;
using Momntz.Data.Schema;

namespace Momntz.Data.ProjectionHandlers.Import
{
    public class GetApiUserProjectionHandler : IProjectionHandler<GetApiUserProjection, string>
    {
        private readonly NHibernate.ISession _session;
        private readonly IDatabase _database;
        private readonly IProjectionHandler<CreateUsername, string> _userFromApiKey;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetApiUserProjectionHandler" /> class.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <param name="database">The database.</param>
        /// <param name="userFromApiKey">The user from API key.</param>
        public GetApiUserProjectionHandler(NHibernate.ISession session, IDatabase database, IProjectionHandler<CreateUsername, string> userFromApiKey)
        {
            _session = session;
            _database = database;
            _userFromApiKey = userFromApiKey;
        }

        /// <summary>
        /// Executes the specified args.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public string Execute(GetApiUserProjection args)
        {
            IList<User> users = GetUsers();
            bool hasUser = users.Any(u => string.Equals(u.Username, args.Username, StringComparison.InvariantCultureIgnoreCase));
            string username = args.Username;
           
            if(!hasUser)
            {
                _userFromApiKey.Execute()

                _processor.Process<CreateUsername, string>(new CreateUsername() { Username = args.Username, Users = users });
                var result = _database.Single<UsernameResult, GetApiUserProjection>("User_CreateUsernameFromApiKey", args);
                username = result.Username;
            }


            return username;
        }

        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <returns>IList{User}.</returns>
        private IList<User> GetUsers()
        {
            IList<User> users;

            using (var trans = _session.BeginTransaction())
            {
                users = _session.QueryOver<User>().List();
                trans.Commit();
            }

            return users;
        }

        /// <summary>
        /// Class UsernameResult
        /// </summary>
        public class UsernameResult
        {
            public string Username { get; set; }
        }
    }
}
