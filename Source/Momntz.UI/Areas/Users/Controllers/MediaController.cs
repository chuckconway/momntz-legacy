using System.Web.Mvc;
using Momntz.Data.Repositories.Momentos;
using Momntz.UI.Areas.Users.Models;
using Momntz.UI.Core.Controllers;
using Momntz.UI.Models.Media;

namespace Momntz.UI.Areas.Users.Controllers
{
    public class MediaController : BaseController
    {
        private readonly IMomentoRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaController" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public MediaController(IMomentoRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Indexes the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Index(int id)
        {
           var signedIn = CurrentSignedInUser<SignedUser>();

            var tile = _repository.GetTileById(id);
            return View(new SingleMediaView { SignedUser = signedIn, Tile = tile});
        }

    }
}
