using System.Collections.Generic;
using System.Linq;
using Hypersonic;
using Momntz.Data.Projections.Api;
using Momntz.Model;

namespace Momntz.Data.ProjectionHandlers.Api
{
    public class NameSearchByUsernameHandler : IProjectionHandler<NameAndUsername, List<NameSearchResult>>
    {
        private readonly IMomntzSession _session;

        public NameSearchByUsernameHandler(IMomntzSession session)
        {
            _session = session;
        }

        public List<NameSearchResult> Execute(NameAndUsername args)
        {
                var items = _session.Session.Database.List<Name, object>("AlsoKnownAs_FindNameByFirstLetersAndUsername", new {Search = args.Name, args.Username}).ToList();
                return items.ConvertAll(a => new NameSearchResult { id = a.AlsoKnownAsId, label = a.FullName, value = a.FullName });
        }
    }

    public class NameAndUsername
    {
        public string Name { get; set; }

        public string Username { get; set; }
    }
}
