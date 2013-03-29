using System.Collections.Generic;
using System.Web.Mvc;
using Momntz.Data.ProjectionHandlers.Albums;
using Momntz.Data.ProjectionHandlers.Connections;
using Momntz.Data.Projections;
using Momntz.Infrastructure.Processors;
using Momntz.UI.Areas.Users.Models;
using Momntz.UI.Core.Controllers;

namespace Momntz.UI.Areas.Users.Controllers
{
    public class ConnectionsController : BaseController
    {
        private readonly IProjectionProcessor _processor;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionsController"/> class.
        /// </summary>
        /// <param name="processor">The processor.</param>
        public ConnectionsController(IProjectionProcessor processor)
        {
            _processor = processor;
        }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Index()
        {
           var view = CurrentSignedInUser<GroupView>();

            view.Items = _processor.Process<ConnectionResultParameters, List<IGroupItem>>(new ConnectionResultParameters
                {
                    Username = view.Username,
                    
                });

            return View(view);
        }

    }
}
