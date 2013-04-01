using System.Collections.Generic;
using System.Web.Mvc;
using Momntz.Data.ProjectionHandlers.Momentos;
using Momntz.Data.Projections.Momentos;
using Momntz.Infrastructure.Processors;
using Momntz.UI.Areas.Users.Models;
using Momntz.UI.Core.Controllers;

namespace Momntz.UI.Areas.Users.Controllers
{
    public class IndexController : BaseController
    {
        private readonly IProjectionProcessor _processor;

        public IndexController(IProjectionProcessor processor)
        {
            _processor = processor;
        }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Index()
        {
            var item = CurrentSignedInUser<UserView>();

            item.Items =_processor.Process<UserPageMomentosInParameters, List<Tile>>(new UserPageMomentosInParameters()
            {
                Username = item.Username
            });

            return View(item);
       }

    }
}
