using System.Collections.Generic;
using System.Web.Mvc;
using Momntz.Data.CommandHandlers.Albums;
using Momntz.Data.CommandHandlers.Albums.Parameters;
using Momntz.Data.ProjectionHandlers;
using Momntz.Data.Projections.Momentos;
using Momntz.UI.Areas.Users.Models;
using Momntz.UI.Core.Controllers;

namespace Momntz.UI.Areas.Users.Controllers
{
    public class AlbumsController : BaseController
    {
        private readonly IProjectionHandler<AlbumMomentosParameters, List<Tile>> _processor;
        private readonly IAlbumRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AlbumsController" /> class.
        /// </summary>
        /// <param name="processor">The processor.</param>
        /// <param name="repository">The repository.</param>
        public AlbumsController(IProjectionHandler<AlbumMomentosParameters, List<Tile>> processor, IAlbumRepository repository)
        {
            _processor = processor;
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
            var results = _processor.Execute(new AlbumMomentosParameters { AlbumId = id, Username = view.Username });
            view.Items = results;
            view.Title = name;
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
