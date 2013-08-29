using System.Collections.Generic;
using System.Web.Mvc;
using Momntz.Data.ProjectionHandlers;
using Momntz.Data.ProjectionHandlers.Albums;
using Momntz.Data.Projections;
using Momntz.Data.Projections.Momentos;
using Momntz.UI.Areas.Users.Models;
using Momntz.UI.Core.Controllers;

namespace Momntz.UI.Areas.Users.Controllers
{
    public class AlbumsController : BaseController
    {
        private readonly IProjectionHandler<AlbumMomentosParameters, List<Tile>> _processor;
        private readonly IProjectionHandler<AlbumResultsParameters, List<IGroupItem>> _getAlbums;

        /// <summary>
        /// Initializes a new instance of the <see cref="AlbumsController" /> class.
        /// </summary>
        /// <param name="processor">The processor.</param>
        /// <param name="getAlbums">The get albums.</param>
        public AlbumsController(IProjectionHandler<AlbumMomentosParameters, List<Tile>> processor, IProjectionHandler<AlbumResultsParameters, List<IGroupItem>> getAlbums)
        {
            _processor = processor;
            _getAlbums = getAlbums;
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
            var results = _processor.Execute(new AlbumMomentosParameters { Name = name, Username = view.Username });
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
            view.Items = _getAlbums.Execute(new AlbumResultsParameters
            {
                Username = view.Username,

            });

            return View(view);
        }

    }
}
