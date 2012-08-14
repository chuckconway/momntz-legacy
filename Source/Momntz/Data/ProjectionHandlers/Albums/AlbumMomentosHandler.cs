using System.Collections.Generic;
using Momntz.Data.ProjectionHandlers.Momentos;
using Momntz.Data.Projections.Momentos;
using Momntz.Model;
using Momntz.Model.Configuration;

namespace Momntz.Data.ProjectionHandlers.Albums
{
    public class AlbumMomentosHandler : BaseMomentoHandler, IProjectionHandler<AlbumMomentosParameters, List<MomentoWithMedia>>
    {
        public AlbumMomentosHandler(IMomntzSession session, ISettings settings) : base(session, settings) { }

        public List<MomentoWithMedia> Execute(AlbumMomentosParameters args)
        {
            List<MomentoWithMedia> homepages = new List<MomentoWithMedia>();

            var momentos = Session
                .Session
                .Database
                .List<Momento, object>("TagAlbum_GetMomentosByNameAndUsername", args);

            GetMedia(momentos, homepages);

            return homepages;
        }
    }

    public class AlbumMomentosParameters
    {
        public string Username { get; set; }

        public string Name { get; set; }
    }
}
