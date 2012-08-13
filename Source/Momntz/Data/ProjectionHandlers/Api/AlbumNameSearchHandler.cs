using System;
using System.Collections.Generic;
using System.Linq;
using Momntz.Data.Projections.Api;

namespace Momntz.Data.ProjectionHandlers.Api
{
    public class AlbumNameSearchHandler : IProjectionHandler<AlbumNameSearchParameters, List<AlbumNameResult>>
    {
        private readonly IMomntzSession _session;

        public AlbumNameSearchHandler(IMomntzSession session)
        {
            _session = session;
        }

        public List<AlbumNameResult> Execute(AlbumNameSearchParameters args)
        {
          return  _session.Session.Database
                .List<AlbumNameResult, object>("TagAlbum_GetTermByFirstCharactersAndUsername", new { term = args.Term, username = args.Username })
                .ToList();

        }
    }

    public class AlbumNameSearchParameters
    {
        public string Term { get; set; }

        public string Username { get; set; }
    }
}
