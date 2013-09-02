using System.Web;
using System.Web.Mvc;
using Momntz.Data.Repositories.Albums;
using Momntz.UI.Areas.Users.Models;
using Momntz.UI.Core.Controllers;

namespace Momntz.UI.Areas.Users.Controllers
{
    public class AlbumsController : BaseController
    {
        private readonly IAlbumRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AlbumsController" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public AlbumsController(IAlbumRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Names the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="id">The unique identifier.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Name(string name, int id)
        {
            var view = CurrentSignedInUser<ContentWithTitleView>();
            view.Items = _repository.GetMomentosById(id, view.Username);
            view.Title = HttpUtility.HtmlEncode(name);
            view.Id = id;

            return View(view);
        }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Index()
        {
            var view = CurrentSignedInUser<GroupView>();
            view.Path = "albums";
            view.Items = _repository.GetAlbumsForUser(view.Username);

            return View(view);
        }

    }
}
