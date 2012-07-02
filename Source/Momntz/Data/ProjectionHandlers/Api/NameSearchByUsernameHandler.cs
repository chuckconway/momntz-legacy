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
                return items.ConvertAll(ConvertToNameSearchResult);
        }

        private static NameSearchResult ConvertToNameSearchResult(Name name)
        {
            string fullName = (string.IsNullOrEmpty(name.First) ? string.Empty : name.First );
            fullName = fullName + (string.IsNullOrEmpty(name.Middle) ? string.Empty : " " + name.Middle );
            fullName = fullName + (string.IsNullOrEmpty(name.Last) ? string.Empty : " " + name.Last );
            fullName = fullName + (string.IsNullOrEmpty(name.Suffix) ? string.Empty : " " + name.Suffix );

            return new NameSearchResult {Id = name.Id, Label = fullName, Value = fullName};
        }
    }

    public class NameAndUsername
    {
        public string Name { get; set; }

        public string Username { get; set; }
    }
}
