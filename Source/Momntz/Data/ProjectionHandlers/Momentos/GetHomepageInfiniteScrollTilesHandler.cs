using System;
using System.Collections.Generic;
using Momntz.Core.Extensions;
using Momntz.Data.Projections.Momentos;
using Momntz.Data.Schema;
using Momntz.Infrastructure.Configuration;

using NHibernate;

namespace Momntz.Data.ProjectionHandlers.Momentos
{
    public class GetHomepageInfiniteScrollTilesHandler : IProjectionHandler<DateTime, List<Tile>>
    {
        private readonly ISession _session;
        private readonly ISettings _settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetHomepageInfiniteScrollTilesHandler"/> class.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <param name="settings">The settings.</param>
        public GetHomepageInfiniteScrollTilesHandler(ISession session, ISettings settings)
        {
            _session = session;
            _settings = settings;
        }

        /// <summary>
        /// Executes the specified args.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns>List{Tile}.</returns>
        public List<Tile> Execute(DateTime args)
        {
            using (var trans = _session.BeginTransaction())
            {
                var items = _session.QueryOver<Momento>()
                         .Where(m => m.CreateDate < args)
                         .OrderBy(m => m.CreateDate).Desc
                         .Take(20)
                         .List();

                trans.Commit();

                return items.ConvertToTiles(_settings);
            }
        }
    }
}
