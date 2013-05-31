using System.Collections.Generic;
using Momntz.Core.Extensions;
using Momntz.Data.Projections;
using Momntz.Data.Schema;
using Momntz.Infrastructure.Configuration;
using NHibernate;

namespace Momntz.Data.ProjectionHandlers.Albums
{
    public class AlbumResultHandler : BaseGroupItem, IProjectionHandler<AlbumResultsParameters, List<IGroupItem>>
    {
        private readonly ISession _session;
        private readonly ISettings _settings;

        public AlbumResultHandler(ISession session, ISettings settings)
        {
            _session = session;
            _settings = settings;
        }

        /// <summary>
        /// Executes the specified args.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns>List{IGroupItem}.</returns>
        public List<IGroupItem> Execute(AlbumResultsParameters args)
        {
            string rootUrl = _settings.CloudUrl;

            using (var trans = _session.BeginTransaction())
            {
               var items = _session.QueryOver<Album>()
                        .Where(a => a.Username == args.Username)
                        .OrderBy(a=>a.CreateDate).Desc
                        .Take(40)
                        .List();

                trans.Commit();

                return items.ConvertToGroupItems(rootUrl);
            }
        }
    }

    public class AlbumResultsParameters
    {
        public string Username { get; set; }
    }
}
