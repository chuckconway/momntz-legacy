using System.Collections.Generic;
using System.Linq;
using Momntz.Core.Extensions;
using Momntz.Data.Projections.Momentos;
using Momntz.Model;
using Momntz.Model.Configuration;
using NHibernate;
using NHibernate.Linq;

namespace Momntz.Data.ProjectionHandlers.Momentos
{
    public class HomepageMomentosHandler : IProjectionHandler<HomepageInParameters, List<Tile>>
    {
        private readonly ISession _session;
        private readonly ISettings _settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomepageMomentosHandler"/> class.
        /// </summary>
        /// <param name="session">The session.</param>
        public HomepageMomentosHandler(ISession session, ISettings settings)
        {
            _session = session;
            _settings = settings;
        }

        //private readonly IDatabase _database;

        //public HomepageMomentosHandler(IDatabase database, ISettings settings)
        //    : base(database, settings)
        //{
        //    _database = database;
        //}

        /// <summary>
        /// Executes the specified args.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns>List{Tile}.</returns>
        public List<Tile> Execute(HomepageInParameters args)
        {
            using (var trans =_session.BeginTransaction())
            {
               var items = _session.QueryOver<Momento>()
                        .OrderBy(m => m.CreateDate).Desc
                        .Take(40)
                        .List();
                   
                trans.Commit();

                return items.ConvertToTiles(_settings);
            }
            //var homepages = new List<MomentoWithMedia>();

            //    var momentos = _database.List<Momento>("[dbo].[Momento_RetrieveRandom20]");

            //    GetMedia(momentos, homepages);

            //return homepages;
        }
    }

    public class HomepageInParameters
    {
        
    }
}
