using System.Collections.Generic;
using System.Web.Mvc;
using Momntz.Data.ProjectionHandlers;
using Momntz.Data.ProjectionHandlers.Connections;
using Momntz.Data.Projections;
using Momntz.UI.Areas.Users.Models;
using Momntz.UI.Core.Controllers;

namespace Momntz.UI.Areas.Users.Controllers
{
    public class ConnectionsController : BaseController
    {
        private readonly IProjectionHandler<ConnectionResultParameters, List<IGroupItem>> _processor;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionsController"/> class.
        /// </summary>
        /// <param name="processor">The processor.</param>
        public ConnectionsController(IProjectionHandler<ConnectionResultParameters, List<IGroupItem>> processor)
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

            view.Items = _processor.Execute(new ConnectionResultParameters
                {
                    Username = view.Username,
                    
                });

            return View(view);
        }

    }
}
