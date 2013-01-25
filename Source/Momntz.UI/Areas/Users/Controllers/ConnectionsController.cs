﻿using System.Collections.Generic;
using System.Web.Mvc;
using Momntz.Data.ProjectionHandlers.Connections;
using Momntz.Data.Projections;
using Momntz.Data.Projections.Connections;
using Momntz.Infrastructure;
using Momntz.Infrastructure.Processors;
using Momntz.UI.Core.Controllers;

namespace Momntz.UI.Areas.Users.Controllers
{
    public class ConnectionsController : BaseController
    {
        private readonly IProjectionProcessor _processor;

        public ConnectionsController(IProjectionProcessor processor)
        {
            _processor = processor;
        }

        public ActionResult Index()
        {
            var username = CurrentLandingPageUsername();
            var results = _processor.Process<ConnectionResultParameters, List<IGroupItem>>(new ConnectionResultParameters(){Username = username});

            return View(results);
        }

    }
}
