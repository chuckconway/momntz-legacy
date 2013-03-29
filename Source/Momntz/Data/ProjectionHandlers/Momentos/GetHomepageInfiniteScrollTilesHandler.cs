using System;
using System.Collections.Generic;
using Momntz.Data.Projections.Momentos;
using Momntz.Model;
using Momntz.Model.Configuration;
using NHibernate;

namespace Momntz.Data.ProjectionHandlers.Momentos
{
    public class GetHomepageInfiniteScrollTilesHandler : TileHandler<DateTime>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetHomepageInfiniteScrollTilesHandler"/> class.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <param name="settings">The settings.</param>
        public GetHomepageInfiniteScrollTilesHandler(ISession session, ISettings settings) : base(session, settings){}

        /// <summary>
        /// Executes the specified args.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns>List{Tile}.</returns>
        public override List<Tile> Execute(DateTime args)
        {
            using (var trans = _session.BeginTransaction())
            {
                var items = _session.QueryOver<Momento>()
                         .Where(m => m.CreateDate < args)
                         .OrderBy(m => m.CreateDate).Desc
                         .Take(20)
                         .List();

                trans.Commit();

                return ConvertMomentosToTiles(items);
            }
        }
    }
}
