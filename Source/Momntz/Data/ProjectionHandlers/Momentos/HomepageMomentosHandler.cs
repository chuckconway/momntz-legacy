using System.Collections.Generic;
using System.Linq;
using Hypersonic;
using Momntz.Data.Projections.Momentos;
using Momntz.Model;

namespace Momntz.Data.ProjectionHandlers.Momentos
{
    public class HomepageMomentosHandler : IProjectionHandler<object, IList<HomepageMomento>>
    {
        private readonly ISession _session;

        public HomepageMomentosHandler(ISession session)
        {
            _session = session;
        }

        public IList<HomepageMomento> Execute(object args)
        {
            List<HomepageMomento> homepages = new List<HomepageMomento>();

            using (_session)
            {
                var momentos = _session.Database.List<Momento>("[dbo].[Momento_RetrieveRandom20]");
                GetMedia(momentos, homepages);
            }

            return homepages;
        }

        private void GetMedia(IEnumerable<Momento> momentos, ICollection<HomepageMomento> homepages)
        {
            foreach (HomepageMomento homepage in 
                from momento in momentos 
                let media = _session.Query<MomentoMedia>().Where(m=>m.MomentoId == momento.Id).And(string.Format("MediaType = '{0}'", MediaType.MediumImage)).Single()
                where media != null 
                select new HomepageMomento {Momento = momento, Media = media})
            {
                homepages.Add(homepage);
            }
        }
    }
}
