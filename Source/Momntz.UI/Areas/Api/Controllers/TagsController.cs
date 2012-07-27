using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Momntz.Data.ProjectionHandlers.Api;
using Momntz.Data.Projections.Api;
using Momntz.Infrastructure;
using Momntz.UI.Areas.Api.Models;
using Momntz.UI.Core.Controllers;

namespace Momntz.UI.Areas.Api.Controllers
{
    public class TagsController : BaseController
    {
        private readonly IProjectionProcessor _processor;

        public TagsController(IProjectionProcessor processor)
        {
            _processor = processor;
        }

        public ActionResult Names(string name)
        {
            NameAndUsername search = new NameAndUsername() { Name = name, Username = GetUsername() };
            var results = _processor.Process<NameAndUsername, List<NameSearchResult>>(search);

            return Json(results);
        }

        public ActionResult Retrieve(int momentoid)
        {
            var momentoTag = _processor.Process<int, IList<MomentoTag>>(momentoid);
            var ts = GetTags(momentoTag);

            var tags = new { Image = new[] { new{ id = momentoid, Tags = ts }} };

            return Json(tags, JsonRequestBehavior.AllowGet);
        }

        private static List<object> GetTags(IEnumerable<MomentoTag> momentoTag)
        {
            List<object> ts = momentoTag.Select(o => new
                {
                    id = o.Id,
                    text = o.DisplayName,
                    left = o.YAxis,
                    top = o.XAxis,
                    url = "/" + o.Username,
                    isDeleteEnable = true
                }).Cast<object>().ToList();

            return ts;
        }

        public ActionResult Add(NewTag tag)
        {
            return Json(1);
        }

    }
}
