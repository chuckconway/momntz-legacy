﻿using System.Collections.Generic;
using Momntz.Core.Extensions;
using Momntz.Data.Projections.Momentos;
using Momntz.Data.Schema;
using Momntz.Infrastructure.Configuration;
using NHibernate;

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
        }
    }

    public class HomepageInParameters
    {
        
    }
}
