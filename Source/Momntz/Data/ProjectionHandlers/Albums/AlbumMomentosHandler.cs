using System.Collections.Generic;
using Momntz.Core.Extensions;
using Momntz.Data.Projections.Momentos;
using Momntz.Data.Schema;
using Momntz.Infrastructure.Configuration;

using ISession = NHibernate.ISession;

namespace Momntz.Data.ProjectionHandlers.Albums
{
    public class AlbumMomentosHandler : IProjectionHandler<AlbumMomentosParameters, List<Tile>>
    {
        private readonly ISession _session;
        private readonly ISettings _settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="AlbumMomentosHandler"/> class.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <param name="settings">The settings.</param>
        public AlbumMomentosHandler(ISession session, ISettings settings)
        {
            _session = session;
            _settings = settings;
        }

        /// <summary>
        /// Executes the specified args.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns>List{Tile}.</returns>
        public List<Tile> Execute(AlbumMomentosParameters args)
        {
            using (var trans = _session.BeginTransaction())
            {
                var items = _session.QueryOver<Momento>()
                                    .Where((m) => m.User.Username == args.Username)
                                    .OrderBy(m=>m.CreateDate).Desc
                                    .JoinQueryOver<Album>(m=>m.Albums)
                                    .Where(a=>a.Id == args.AlbumId)
                                    .Take(40)
                                    .List<Momento>();

                trans.Commit();

                return items.ConvertToTiles(_settings);
            }
        }
    }

    public class AlbumMomentosParameters
    {
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public int AlbumId { get; set; }
    }
}
