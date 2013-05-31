using System.Collections.Generic;
using System.Linq;
using Momntz.Data.Projections.Users;
using Momntz.Data.Schema;


namespace Momntz.Data.ProjectionHandlers.Users
{
    public class CreateUsernameHandler : IProjectionHandler<CreateUsername, string>
    {

        /// <summary>
        /// Executes the specified args.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns>System.String.</returns>
        public string Execute(CreateUsername args)
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
    }
}
