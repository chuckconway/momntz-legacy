using System;
using System.Collections.Generic;
using System.Linq;
using Momntz.Core.Extensions;
using Momntz.Data.ProjectionHandlers.MomentoMedia;
using Momntz.Data.Projections;
using Momntz.Data.Projections.Momentos;
using Momntz.Data.Schema;
using Momntz.Infrastructure.Configuration;
using NHibernate;

namespace Momntz.Data.ProjectionHandlers.Albums
{
    public class FindAlbumByNameHandler : IProjectionHandler<FindAlbumByNameInParameters, List<IGroupItem>>
    {
        private readonly ISession _session;
        private readonly ISettings _settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="FindMomentoBySizeAndNameProjectionHandler" /> class.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <param name="settings">The settings.</param>
        public FindAlbumByNameHandler(ISession session, ISettings settings)
        {
            _session = session;
            _settings = settings;
        }

        /// <summary>
        /// Executes the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>Momento.</returns>
        public List<IGroupItem> Execute(FindAlbumByNameInParameters args)
        {
            using (var trans = _session.BeginTransaction())
            {
                var album = _session.QueryOver<Album>()
                    .Where(m => m.Name == args.Name)
                    .And(a => a.Username == args.Username)
                    .And(m => m.CreateDate > DateTime.UtcNow.AddHours(-1))
                    .List();

                trans.Commit();

                if (album.Count() == 1)
                {
                    return album.ConvertToGroupItems(_settings.CloudUrl);
                }
                
                return null;
            }
        }
    }

    public class FindAlbumByNameInParameters
    {

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        public string Username { get; set; }

    }
}