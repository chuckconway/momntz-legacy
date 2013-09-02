using System.Web.Mvc;
using Momntz.Data.Repositories.Connections;
using Momntz.UI.Areas.Users.Models;
using Momntz.UI.Core.Controllers;

namespace Momntz.UI.Areas.Users.Controllers
{
    public class ConnectionsController : BaseController
    {
        private readonly IConnectionRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionsController"/> class.
        /// </summary>
        /// <param name="processor">The processor.</param>
        public ConnectionsController(IConnectionRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Index()
        {
           var view = CurrentSignedInUser<GroupView>();
            view.Items = _repository.GetConnectionsForUser(view.Username);

            return View(view);
        }

    }
}
