using System;
using System.Collections.Generic;
using Momntz.Data.Projections.Momentos;
using Momntz.Model;
using Momntz.Model.Configuration;
using NHibernate;

namespace Momntz.Data.ProjectionHandlers.Momentos
{
    public class GetUserHomepageInfiniteScrollTilesHandler : TileHandler<UserHomepageInfiniteScrollInParameters>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetHomepageInfiniteScrollTilesHandler"/> class.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <param name="settings">The settings.</param>
        public GetUserHomepageInfiniteScrollTilesHandler(ISession session, ISettings settings) : base(session, settings){}

        /// <summary>
        /// Executes the specified args.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns>List{Tile}.</returns>
        public override List<Tile> Execute(UserHomepageInfiniteScrollInParameters args)
        {
            using (var trans = _session.BeginTransaction())
            {
                var items = _session.QueryOver<Momento>()
                         .Where(m => m.CreateDate < args.CreateDate)
                         .And(m=>m.Username == args.Username)
                         .OrderBy(m => m.CreateDate).Desc
                         .Take(20)
                         .List();

                trans.Commit();

                return ConvertMomentosToTiles(items);
            }
        }
    }

    public class UserHomepageInfiniteScrollInParameters
    {
        /// <summary>
        /// Gets or sets the create date.
        /// </summary>
        /// <value>The create date.</value>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        public string Username { get; set; }
    }
}
