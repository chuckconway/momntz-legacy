using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Momntz.Data.ProjectionHandlers.Albums;
using Momntz.Data.Projections;
using Momntz.Data.Projections.Momentos;
using Momntz.Infrastructure.Processors;
using Momntz.UI.Areas.Users.Models;
using Momntz.UI.Core.Controllers;

namespace Momntz.UI.Areas.Users.Controllers
{
    public class AlbumsController : BaseController
    {
        private readonly IProjectionProcessor _processor;

        /// <summary>
        /// Initializes a new instance of the <see cref="AlbumsController"/> class.
        /// </summary>
        /// <param name="processor">The processor.</param>
        public AlbumsController(IProjectionProcessor processor)
        {
            _processor = processor;
        }

        /// <summary>
        /// Names the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Name(string name)
        {
            var view = CurrentSignedInUser<ContentWithTitleView>();
            var results = _processor.Process<AlbumMomentosParameters, List<MomentoWithMedia>>(new AlbumMomentosParameters() { Name = name, Username = view.Username });
            view.Items = results;
            view.Title = HttpUtility.HtmlEncode(name);

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
            view.Items = _processor.Process<AlbumResultsParameters, List<IGroupItem>>(new AlbumResultsParameters
            {
                Username = view.Username,

            });

            return View(view);
        }

    }
}
