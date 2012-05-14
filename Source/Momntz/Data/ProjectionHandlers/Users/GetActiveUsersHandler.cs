using System.Collections.Generic;
using System.Linq;
using Hypersonic;
using Momntz.Model;

namespace Momntz.Data.ProjectionHandlers.Users
{
    public class GetActiveUsersHandler : IProjectionHandler<object, List<string>>
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
        public List<string> Execute(object args)
        {
           return _session
                .Query<User>(new[]{"Username"})
                .Where(u => u.UserStatus == UserStatus.Active)
                .List()
                .Select(u => u.Username)
                .ToList();
        }
    }
}
