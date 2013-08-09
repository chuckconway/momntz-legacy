using System.Collections.Generic;
using System.Web.Mvc;
using Momntz.Data.ProjectionHandlers;
using Momntz.Data.ProjectionHandlers.Momentos;
using Momntz.Data.Projections.Momentos;
using Momntz.UI.Areas.Users.Models;
using Momntz.UI.Core.Controllers;

namespace Momntz.UI.Areas.Users.Controllers
{
    public class IndexController : BaseController
    {
        private readonly IProjectionHandler<UserPageMomentosInParameters, List<Tile>> _processor;

        /// <summary>
        /// Initializes a new instance of the <see cref="IndexController"/> class.
        /// </summary>
        /// <param name="processor">The processor.</param>
        public IndexController(IProjectionHandler<UserPageMomentosInParameters, List<Tile>> processor)
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

            item.Items =_processor.Execute(new UserPageMomentosInParameters()
            {
                Username = item.Username
            });

            return View(item);
       }

    }
}
