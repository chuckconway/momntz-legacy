using System.Collections;
using System.Collections.Generic;
using Momntz.Data.Projections.Users;
using Momntz.Data.Repositories.Users.Parameters;

namespace Momntz.Data.Repositories.Users
{
    public interface IUserRepository
    {
        /// <summary>
        ///     Creates the specified parameters.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        void Create(CreateUserParameters parameters);

        /// <summary>
        /// Authenticates the user.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>AuthenticatedUser.</returns>
        AuthenticatedUser AuthenticateUser(UsernameAndPassword args);

        /// <summary>
        /// Creates the username.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>System.String.</returns>
        string CreateUsername(CreateUsername args);

        /// <summary>
        /// Gets the display name.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>DisplayName.</returns>
        DisplayName GetDisplayName(string username);

        /// <summary>
        /// Gets the active users.
        /// </summary>
        /// <returns>IList{ActiveUsername}.</returns>
        IList<ActiveUsername> GetActiveUsers();
    }
}