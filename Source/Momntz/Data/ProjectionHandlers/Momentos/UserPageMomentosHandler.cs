using System.Collections.Generic;
using Hypersonic;
using Momntz.Data.Projections.Momentos;
using Momntz.Model;
using Momntz.Model.Configuration;

namespace Momntz.Data.ProjectionHandlers.Momentos
{
    public class UserPageMomentosHandler : BaseMomentoHandler, IProjectionHandler<string, List<MomentoWithMedia>>
    {
        private readonly NHibernate.ISession _session;
        private readonly IDatabase _database;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserPageMomentosHandler" /> class.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <param name="settings">The settings.</param>
        public UserPageMomentosHandler(NHibernate.ISession session, IDatabase database, ISettings settings) : base(database, settings)
        {
            _session = session;
            _database = database;
        }

        /// <summary>
        /// Executes the specified username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>List{MomentoWithMedia}.</returns>
        public List<MomentoWithMedia> Execute(string username)
        {
            var homepages = new List<MomentoWithMedia>();

            using (var trans = _session.BeginTransaction())
            {
                var items = _session.QueryOver<Momento>()
                         .And(m => m.Username == username)
                         .OrderBy(m => m.CreateDate).Desc
                         .Take(40)
                         .List();

                trans.Commit();

                GetMedia(items, homepages);
            }
                

            return homepages;
        }
    }
}
