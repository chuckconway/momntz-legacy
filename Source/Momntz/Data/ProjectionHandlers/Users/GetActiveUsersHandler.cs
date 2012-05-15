using System.Collections.Generic;
using Hypersonic;
using Momntz.Data.Projections.Users;
using Momntz.Model;

namespace Momntz.Data.ProjectionHandlers.Users
{
    public class GetActiveUsersHandler : IProjectionHandler<object, IList<ActiveUsername>>
    {
        private readonly ISession _session;

        /// <summary> Constructor. </summary>
        /// <param name="session"> The session. </param>
        public GetActiveUsersHandler(ISession session)
        {
            _session = session;
        }

        /// <summary> Executes. </summary>
        /// <param name="args"> The arguments. </param>
        /// <returns> . </returns>
        public IList<ActiveUsername> Execute(object args)
        {
            using (_session)
            {
              return  _session
                       .Query<ActiveUsername, User>()
                       .Where("UserStatus = 'Active'")
                       .List();
            }
        }
    }
}
