using System;
using System.Linq;

using System.Web.Mvc;
using Momntz.Data.Repositories.Momentos;
using Momntz.Data.Repositories.Momentos.Parameters;
using Momntz.Data.Schema;
using Momntz.UI.Core.Controllers;

namespace Momntz.UI.Areas.Api.Controllers
{
    public class MomentoController : BaseController
    {
        private readonly IMomentoRepository _repository;
        //private readonly ICommandHandler<SaveMomentoDetailsCommand> _processor;
        //private readonly IProjectionHandler<LocationAutoCompleteParameters, List<LocationAutoComplete>> _projection;
        //private readonly IProjectionHandler<DateTime, List<Tile>> _scroll;
        //private readonly IProjectionHandler<UserHomepageInfiniteScrollInParameters, List<Tile>> _getuserScroll;
        //private readonly IProjectionHandler<int, Momento> _getMomentoById;

        /// <summary>
        /// Initializes a new instance of the <see cref="MomentoController"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public MomentoController(IMomentoRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Saves the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="title">The title.</param>
        /// <param name="story">The story.</param>
        /// <param name="day">The day.</param>
        /// <param name="month">The month.</param>
        /// <param name="year">The year.</param>
        /// <param name="albums">The albums.</param>
        /// <param name="location">The location.</param>
        /// <returns>ActionResult.</returns>
        //[HttpPost]
        //public ActionResult Save(int id, string title, string story, int? day, int? month, int? year, string albums, string location)
        //{
        //    _processor.Execute(new SaveMomentoDetailsCommand(id, title, story, day, month, year, albums, location, GetUsername()));
        //    return Content("1");
        //}

        ///// <summary>
        ///// Locations the search.
        ///// </summary>
        ///// <param name="term">The term.</param>
        ///// <returns>ActionResult.</returns>
        //public ActionResult LocationSearch(string term)
        //{
        //    string username = GetUsername();
        //    var results =
        //        _projection.Execute(
        //            new LocationAutoCompleteParameters() {Term = term, Username = username});
            
        //    return Json(results.Select(a=> new AutoComplete(a.Location)), JsonRequestBehavior.AllowGet);
        //}

        /// <summary>
        /// Scrolls the specified oldest.
        /// </summary>
        /// <param name="oldest">The oldest.</param>
        /// <returns>ActionResult.</returns>
        //[HttpPost]
        //public ActionResult Scroll(string oldest)
        //{
        //    DateTime parsed = DateTime.Parse(oldest);
        //    var items = _.Execute(parsed);

        //    return Json(items);
        //}


        
        /// <summary>
        /// Bies the id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public ActionResult ById(int id)
        {
           Momento detail = _repository.GetById(id);
            detail = detail ?? new Momento();

            Func<string, string> convertNullToEmptyString = (s => s ?? string.Empty); 

                return Json(new
                                {
                                    Added = detail.CreateDate.HasValue ? detail.CreateDate.Value.ToString("MMMM dd, yyyy") : string.Empty,
                                    AddedUrl = detail.CreateDate.HasValue ? string.Format("{0}/{1}/{2}", detail.CreateDate.Value.Year, detail.CreateDate.Value.Month, detail.CreateDate.Value.Day) : string.Empty,
                                    detail.UploadedBy,
                                    Albums = detail.Albums.Select(a=> new {id= a.Id, name=a.Name}).ToArray(),
                                    detail.Day,
                                    DisplayName = convertNullToEmptyString(detail.User.FullName),
                                    Location = convertNullToEmptyString(detail.Location),
                                    Month = convertNullToEmptyString(Convert.ToString(detail.Month)),
                                    People = detail.People.Select(p=>new {p.Username, p.Name}),
                                    Story = convertNullToEmptyString(detail.Story),
                                    Username = convertNullToEmptyString(detail.User.Username),
                                    Title = convertNullToEmptyString(detail.Title), 
                                    Year = convertNullToEmptyString(Convert.ToString(detail.Year)) 
                                });

        }
    }
}
