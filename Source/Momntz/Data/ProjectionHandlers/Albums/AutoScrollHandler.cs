﻿using System;
using System.Collections.Generic;
using Momntz.Data.Projections;
using Momntz.Data.Schema;
using Momntz.Infrastructure.Configuration;

using NHibernate;
using Momntz.Core.Extensions;

namespace Momntz.Data.ProjectionHandlers.Albums
{
    public class AutoScrollHandler : BaseGroupItem, IProjectionHandler<AutoScrollInParameters, List<IGroupItem>>
    {
        private readonly ISession _session;
        private readonly ISettings _settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="AutoScrollHandler" /> class.
        /// </summary>
        /// <param name="session"></param>
        /// <param name="settings">The settings.</param>
        public AutoScrollHandler(ISession session, ISettings settings)
        {
            _session = session;
            _settings = settings;
        }

        /// <summary>
        /// Executes the specified args.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns>List{IGroupItem}.</returns>
        public List<IGroupItem> Execute(AutoScrollInParameters args)
        {
            string rootUrl = _settings.CloudUrl;

            using (var trans = _session.BeginTransaction())
            {
                var items = _session.QueryOver<Album>()
                         .Where(a => a.Username == args.Username)
                         .And(a=>a.CreateDate < args.CreateDate)
                         .OrderBy(a => a.CreateDate).Desc
                         .Take(40)
                         .List();

                trans.Commit();

                return items.ConvertToGroupItems(rootUrl);
            }
        }
    }

    public class AutoScrollInParameters
    {
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the create date.
        /// </summary>
        /// <value>The create date.</value>
        public DateTime CreateDate { get; set; }
    }
}