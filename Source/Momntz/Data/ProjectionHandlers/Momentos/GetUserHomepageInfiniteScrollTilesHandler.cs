using System.Collections.Generic;
using System.Linq;
using Momntz.Core.Extensions;
using Momntz.Data.Projections.Momentos;
using Momntz.Data.Schema;
using Momntz.Infrastructure.Configuration;
using NHibernate;
using NHibernate.Criterion;

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
                var items = _session.CreateQueryProcedure<object>("Momento_GetNext40Momentos", args)
                    .List<object>();

                var ids = items.Cast<IDictionary<string, string>>().Select(i => (object)i["MomentoId"]).ToArray();

                Momento m = null;
                var momentos = _session.QueryOver<Momento>()
                     .Where(Restrictions.In("Id", ids))
                     .List()
                     .ToList()
                     .ConvertToTiles(_settings);

                trans.Commit();
                return momentos;
            }
        }
    }

    public class UserHomepageInfiniteScrollInParameters
    {
        /// <summary>
        /// Gets or sets the create date.
        /// </summary>
        /// <value>The create date.</value>
        public int MomentoId { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        public string Username { get; set; }
    }
}
