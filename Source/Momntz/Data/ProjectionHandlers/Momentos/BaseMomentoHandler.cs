using System.Collections.Generic;
using System.Linq;
using Hypersonic;
using Momntz.Data.Projections.Momentos;
using Momntz.Model;
using Momntz.Model.Configuration;

namespace Momntz.Data.ProjectionHandlers.Momentos
{
    public abstract class BaseMomentoHandler
    {
      protected readonly ISession Session;
        private readonly ISettings _settings;

        protected BaseMomentoHandler(ISession session, ISettings settings)
        {
            Session = session;
            _settings = settings;
        }

        protected void GetMedia(IEnumerable<Momento> momentos, ICollection<MomentoWithMedia> homepages)
        {
            string rootUrl = _settings.CloudUrl;

            foreach (MomentoWithMedia item in
                from momento in momentos
                let media = Session.Query<MomentoMedia>().Where(m => m.MomentoId == momento.Id).And(string.Format("MediaType = '{0}'", MediaType.MediumImage)).Single()
                let tags = Session.Database.List<Tag, object>("Momento_RetrieveTagsByMomentoId", new { MomentoId = momento.Id }).ToList()
                where media != null
                select new MomentoWithMedia { Momento = momento, Media = media, Tags = tags})
                {
                    item.Media.Url = string.Format("{0}/{1}", rootUrl, item.Media.Url);

                homepages.Add(item);
            }
        }
    }
}
