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
        private readonly IDatabase _database;
        private readonly ISettings _settings;

        protected BaseMomentoHandler(IDatabase database, ISettings settings)
        {
            _database = database;
            _settings = settings;
        }

        protected void GetMedia(IEnumerable<Momento> momentos, ICollection<MomentoWithMedia> homepages)
        {
            string rootUrl = _settings.CloudUrl;

            foreach (MomentoWithMedia item in
                from momento in momentos
                let media = _database.Single("MomentoMedia_GetByMomentoIdAndMediaType", _database.ConvertToParameters(new { MomentoId = momento.Id, MediaType = MediaType.MediumImage.ToString()}), r => _database.AutoPopulate<MomentoMedia>(r)) //.Where(m => m.MomentoId == momento.Id).And(string.Format("MediaType = '{0}'", MediaType.MediumImage)).Single()
                let tags = _database.List<Tag, object>("Momento_RetrieveTagsByMomentoId", new { MomentoId = momento.Id }).ToList()
                where media != null
                select new MomentoWithMedia { Momento = momento, Media = media, Tags = tags})
                {
                    item.Media.Url = string.Format("{0}/{1}", rootUrl, item.Media.Url);

                homepages.Add(item);
            }
        }
    }
}
