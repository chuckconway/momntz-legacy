﻿using System;
using System.Linq;
using Momntz.Core.Extensions;
using Momntz.Data.Projections.Momentos;
using Momntz.Data.Schema;
using Momntz.Infrastructure.Configuration;
using NHibernate;

namespace Momntz.Data.ProjectionHandlers.MomentoMedia
{
    public class FindMomentoBySizeAndNameProjectionHandler : IProjectionHandler<FindMomentoBySizeAndNameInParameters, Tile>
    {
        private readonly ISession _session;
        private readonly ISettings _settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="FindMomentoBySizeAndNameProjectionHandler" /> class.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <param name="settings">The settings.</param>
        public FindMomentoBySizeAndNameProjectionHandler(ISession session, ISettings settings)
        {
            _session = session;
            _settings = settings;
        }

        /// <summary>
        /// Executes the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>Momento.</returns>
        public Tile Execute(FindMomentoBySizeAndNameInParameters args)
        {
            using (var trans = _session.BeginTransaction())
            {
                var momento = _session.QueryOver<Schema.MomentoMedia>()
                    .Where(m => m.MediaType == MomentoMediaType.OriginalImage)
                    .And(m=>m.Filename == args.Filename)
                    .And(m=>m.Size == args.Size)
                    .Where(m=>m.CreateDate > DateTime.UtcNow.AddHours(-1))

                    .JoinQueryOver(a => a.Momento)
                    .Where(e => e.User.Username == args.Username)
                    .Select(f=>f.Momento)
                    .List<Momento>();

                trans.Commit();

                if (momento.Count() == 1)
                {
                    return momento.Single().ConvertToTile(_settings);
                }
                
                return null;
            }
        }
    }

    public class FindMomentoBySizeAndNameInParameters
    {
        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>The size.</value>
        public int Size { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Filename { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        public string Username { get; set; }

    }
}