using System;
using System.Collections.Generic;
using Momntz.Core.Extensions;
using Momntz.Data.Projections.Momentos;
using Momntz.Model;
using Momntz.Model.Configuration;
using NHibernate;

namespace Momntz.Data.ProjectionHandlers.Momentos
{
    public class GetUserHomepageInfiniteScrollTilesHandler : IProjectionHandler<UserHomepageInfiniteScrollInParameters, List<Tile>>
    {
        private readonly ISession _session;
        private readonly ISettings _settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetHomepageInfiniteScrollTilesHandler"/> class.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <param name="settings">The settings.</param>
        public GetUserHomepageInfiniteScrollTilesHandler(ISession session, ISettings settings)
        {
            _session = session;
            _settings = settings;
        }

        /// <summary>
        /// Executes the specified args.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns>List{Tile}.</returns>
        public List<Tile> Execute(UserHomepageInfiniteScrollInParameters args)
        {
            using (var trans = _session.BeginTransaction())
            {
                var items = _session.QueryOver<Momento>()
                         .Where(m => m.CreateDate < args.CreateDate)
                         .And(m=>m.User.Username == args.Username)
                         .OrderBy(m => m.CreateDate).Desc
                         .Take(20)
                         .List();

                trans.Commit();

                return items.ConvertToTiles(_settings);
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
