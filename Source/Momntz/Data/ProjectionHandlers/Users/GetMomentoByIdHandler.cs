using System.Collections.Generic;
using System.Linq;
using Momntz.Core.Extensions;
using Momntz.Data.Projections.Momentos;
using Momntz.Model;
using Momntz.Model.Configuration;
using NHibernate;

namespace Momntz.Data.ProjectionHandlers.Users
{
    public class GetMomentoByIdHandler : IProjectionHandler<int, Tile>
    {
        private readonly ISession _session;
        private readonly ISettings _settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMomentoByIdHandler" /> class.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <param name="settings">The settings.</param>
        public GetMomentoByIdHandler(ISession session, ISettings settings)
        {
            _session = session;
            _settings = settings;
        }

        /// <summary>
        /// Executes the specified args.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>MomentoWithMedia.</returns>
        public Tile Execute(int id)
        {
            using (var trans = _session.BeginTransaction())
            {
                var items = _session.QueryOver<Momento>()
                                    .Where(m => m.Id == id)
                                    .List();

                trans.Commit();

                return items.ConvertToTiles(_settings).First();
            }
        }
    }
}
