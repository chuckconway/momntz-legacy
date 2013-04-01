using System.Collections.Generic;
using Momntz.Core.Extensions;
using Momntz.Data.Projections.Momentos;
using Momntz.Model;
using Momntz.Model.Configuration;

namespace Momntz.Data.ProjectionHandlers.Momentos
{
    public class UserPageMomentosHandler : IProjectionHandler<UserPageMomentosInParameters, List<Tile>>
    {
        private readonly NHibernate.ISession _session;
        private readonly ISettings _settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserPageMomentosHandler" /> class.
        /// </summary>
        /// <param name="session">The session.</param>
        public UserPageMomentosHandler(NHibernate.ISession session, ISettings settings)
        {
            _session = session;
            _settings = settings;
        }

        /// <summary>
        /// Executes the specified username.
        /// </summary>
        /// <param name="arg">The arg.</param>
        /// <returns>List{MomentoWithMedia}.</returns>
        public List<Tile> Execute(UserPageMomentosInParameters arg)
        {
            using (var trans = _session.BeginTransaction())
            {
                var items = _session.QueryOver<Momento>()
                         .And(m => m.Username == arg.Username)
                         .OrderBy(m => m.CreateDate).Desc
                         .Take(40)
                         .List();

                trans.Commit();

                return items.ConvertToTiles(_settings);
            }
        }
    }

    public class UserPageMomentosInParameters
    {
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        public string Username { get; set; }
    }
}
