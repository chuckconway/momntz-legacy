using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Momntz.Data.Projections.Api;
using Momntz.Infrastructure;
using Momntz.Model;
using Momntz.UI.Areas.Api.Models;

namespace Momntz.UI.Areas.Api.Controllers
{
    public class MomentoController : Controller
    {
         static readonly string[] _months = new[] { "", "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        private readonly ICommandProcessor _processor;
        private readonly IProjectionProcessor _projection;

        public MomentoController(ICommandProcessor processor, IProjectionProcessor projection)
        {
            _processor = processor;
            _projection = projection;
        }

        [HttpPost]
        public ActionResult Save(int id, string title, string story, string day, string month, string year, string albums)
        {
            return Content(string.Empty);
        }

        [HttpPost]
        public ActionResult ById(int id)
        {
            MomentoDetail detail = _projection.Process<int, MomentoDetail>(id) ?? new MomentoDetail();

                //Dummy data
                detail.Location = "Chico, California";
                detail.People = GetPeople();

                return Json(new
                                {
                                    Added = detail.Added.HasValue ? detail.Added.Value.ToString("MMMM dd, yyyy") : string.Empty,
                                    detail.AddedUsername,
                                    Albums = Albums(detail.Albums),
                                    detail.Day,
                                    detail.DisplayName,
                                    detail.Location,
                                    Month = Month(detail.Month),
                                    detail.People,
                                    detail.Story,
                                    detail.Username,
                                    detail.Title,
                                    detail.Year
                                });

        }

        private static string[] Albums(TagCollection collection)
        {
            return new[] {"Doggie", "Christmas 2005", "Kitty Cat"};
        }

        private static List<People> GetPeople()
        {
            return new List<People> {new People() {DisplayName = "John Conway", Username = "johnconway"}, new People(){DisplayName = "Erin Meraz", Username = "erinmeraz"}, new People(){DisplayName = "Bill Gates", Username = "billgates"}};
        }

        private static string Month(string month)
        {
            if (!string.IsNullOrEmpty(month))
            {
                int m = Convert.ToInt32(month);
                month = _months[m];
            }

            return month;
        }

    }
}
