using System.Collections.Generic;
using Momntz.Data.Projections;

namespace Momntz.Data.Repositories.Connections
{
    public interface IConnectionRepository
    {
        /// <summary>
        /// Gets the connections for user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>List{IGroupItem}.</returns>
        List<IGroupItem> GetConnectionsForUser(string username);
    }
}
