using System;
using System.Collections.Generic;
using System.Linq;
using Momntz.Core.Extensions;
using Momntz.Data.CommandHandlers.Albums.Parameters;
using Momntz.Data.Commands.Albums;
using Momntz.Data.Projections;
using Momntz.Data.Projections.Momentos;
using Momntz.Data.Schema;
using Momntz.Infrastructure.Configuration;
using NHibernate.Criterion;
using ISession = NHibernate.ISession;

namespace Momntz.Data.CommandHandlers.Albums
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly ISession _session;
        private readonly ISettings _settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="AlbumRepository" /> class.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <param name="settings">The settings.</param>
        public AlbumRepository(ISession session, ISettings settings)
        {
            _session = session;
            _settings = settings;
        }


        /// <summary>
        /// News the specified command.
        /// </summary>
        /// <param name="parameters">The command.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void New(NewAlbumParameters parameters)
        {
            using (var trans = _session.BeginTransaction())
            {
                var album = new Album { Name = parameters.Name, Story = parameters.Story, Username = parameters.Username, CreateDate = DateTime.UtcNow };
                _session.Save(album);

                trans.Commit();
            }
        }


        /// <summary>
        /// Gets the by unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier.</param>
        /// <param name="username">The username.</param>
        /// <returns>List{Tile}.</returns>
        public List<Tile> GetMomentosById(int id, string username)
        {
            using (var trans = _session.BeginTransaction())
            {
                var items = _session.QueryOver<Momento>()
                                    .Where((m) => m.User.Username == username)
                                    .OrderBy(m => m.CreateDate).Desc
                                    .JoinQueryOver<Album>(m => m.Albums)
                                    .Where(a => a.Id == id)
                                    .Take(40)
                                    .List<Momento>();

                trans.Commit();

                return items.ConvertToTiles(_settings);
            }
        }

        /// <summary>
        /// Gets the next albums.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>List{Tile}.</returns>
        public List<Tile> GetNextMomentos(AlbumTileScrollInParamters args)
        {
            using (var trans = _session.BeginTransaction())
            {
                var items = _session.CreateQueryProcedure<object>("Album_GetNext40Momentos", args)
                    .List<object>();

                var ids = items.Cast<IDictionary<string, string>>().Select(i => (object)i["Id"]).ToArray();

                var momentos = _session.QueryOver<Momento>()
                     .Where(Restrictions.In("Id", ids))
                     .List()
                     .ToList()
                     .ConvertToTiles(_settings);

                trans.Commit();
                return momentos;
            }
        }

        /// <summary>
        /// Gets the next albums.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>List{IGroupItem}.</returns>
        public List<IGroupItem> GetNextAlbums(AutoScrollInParameters args)
        {
            string rootUrl = _settings.CloudUrl;

            using (var trans = _session.BeginTransaction())
            {
                var items = _session.CreateQueryProcedure<object>("Album_GetNext40Albums", args)
                    .List<object>();

                var ids = items.Cast<IDictionary<string, string>>().Select(i => (object)i["AlbumId"]).ToArray();

                var album = _session.QueryOver<Album>()
                     .Where(Restrictions.In("Id", ids))
                     .List()
                     .ToList()
                     .ConvertToGroupItems(rootUrl);

                trans.Commit();
                return album;
            }
        }

        /// <summary>
        /// Gets the albums for user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>List{IGroupItem}.</returns>
        public List<IGroupItem> GetAlbumsForUser(string username)
        {
            string rootUrl = _settings.CloudUrl;

            using (var trans = _session.BeginTransaction())
            {
                var items = _session.QueryOver<Album>()
                         .Where(a => a.Username == username)
                         .OrderBy(a => a.CreateDate).Desc
                         .Take(40)
                         .List();

                trans.Commit();

                return items.ConvertToGroupItems(rootUrl);
            }
        }

        /// <summary>
        /// Finds the name of the by.
        /// </summary>
        /// <param name="byName">Name of the by.</param>
        /// <returns>List{IGroupItem}.</returns>
        public List<IGroupItem> FindNewlyAddedByName(FindAlbumByNameInParameters byName)
        {
            using (var trans = _session.BeginTransaction())
            {
                var album = _session.QueryOver<Album>()
                    .Where(m => m.Name == byName.Name)
                    .And(a => a.Username == byName.Username)
                    .And(m => m.CreateDate > DateTime.UtcNow.AddHours(-1))
                    .List();

                trans.Commit();

                const int expectedCount = 1;

                if (album.Count() == expectedCount)
                {
                    return album.ConvertToGroupItems(_settings.CloudUrl);
                }

                return null;
            }
        }
    }
}