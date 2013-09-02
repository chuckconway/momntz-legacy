using System.Web.Mvc;
using Momntz.Data.Repositories.Momentos;
using Momntz.UI.Areas.Users.Models;
using Momntz.UI.Core.Controllers;

namespace Momntz.UI.Areas.Users.Controllers
{
    public class IndexController : BaseController
    {
        private readonly IMomentoRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="IndexController"/> class.
        /// </summary>
        /// <param name="processor">The processor.</param>
        public IndexController(IMomentoRepository repository )
        {
            _repository = repository;
        }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Index()
        {
            var view = CurrentSignedInUser<UserView>();
            var items =_repository.First40(view.Username);
            view.Items = items;

            return View(view);
       }

    }
}
