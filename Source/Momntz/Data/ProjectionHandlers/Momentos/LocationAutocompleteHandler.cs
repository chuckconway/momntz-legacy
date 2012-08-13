using System.Collections.Generic;
using System.Linq;
using Momntz.Data.Projections.Momentos;

namespace Momntz.Data.ProjectionHandlers.Momentos
{
    public class LocationAutoCompleteHandler : IProjectionHandler<LocationAutoCompleteParameters, List<LocationAutoComplete>>
    {
        private readonly IMomntzSession _session;

        public LocationAutoCompleteHandler(IMomntzSession session)
        {
            _session = session;
        }

        public List<LocationAutoComplete> Execute(LocationAutoCompleteParameters args)
        {
           return _session.Session
               .Database
               .List<LocationAutoComplete, object>("Momento_GetLocationByFirstCharactersAndUsername", args)
               .ToList();
        }
    }

    public class LocationAutoCompleteParameters
    {
        public string Term { get; set; }

        public string Username { get; set; }
    }
}
