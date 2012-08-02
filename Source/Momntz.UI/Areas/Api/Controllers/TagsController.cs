using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Momntz.Data.Commands.Tags;
using Momntz.Data.ProjectionHandlers.Api;
using Momntz.Data.Projections.Api;
using Momntz.Infrastructure;
using Momntz.Model;
using Momntz.UI.Areas.Api.Models;
using Momntz.UI.Core.Controllers;

namespace Momntz.UI.Areas.Api.Controllers
{
    public class TagsController : BaseController
    {
        private readonly IProjectionProcessor _processor;
        private readonly ICommandProcessor _commandProcessor;

        public TagsController(IProjectionProcessor processor, ICommandProcessor commandProcessor)
        {
            _processor = processor;
            _commandProcessor = commandProcessor;
        }

        public ActionResult Delete(int momentoId, int tagid)
        {
            _commandProcessor.Process(new DeleteTagCommand(momentoId, tagid));
            return Json(new {result=true}, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Names(string term)
        {
            NameAndUsername search = new NameAndUsername() { Name = term, Username = GetUsername() };
            var results = _processor.Process<NameAndUsername, List<NameSearchResult>>(search);

            return Json(results, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Retrieve(int momentoid)
        {
            var momentoTag = _processor.Process<int, IList<MomentoTag>>(momentoid);
            var ts = GetTags(momentoTag);

            var tags = new { Image = new[] { new { id = momentoid, Tags = ts } } };

            return Json(tags, JsonRequestBehavior.AllowGet);
        }

        private static List<object> GetTags(IEnumerable<MomentoTag> momentoTag)
        {
            List<object> ts = momentoTag.Select(o => new
                {
                    id = o.Id,
                    text = o.DisplayName,
                    left = o.XAxis,
                    width = o.Width,
                    height = o.Height,
                    top = o.YAxis,
                    url = "/" + o.Username,
                    isDeleteEnable = true
                }).Cast<object>().ToList();

            return ts;
        }
        
        public ActionResult Add(NewTag tag)
        {
            string username = GetUsername();
            _commandProcessor.Process(new CreateTagCommand(tag.Name, tag.Left, tag.Top, tag.Width, tag.Height, username, tag.MomentoId));

            var momentoTags = _processor.Process<int, IList<MomentoTag>>(tag.MomentoId);
            MomentoTag t = momentoTags.SingleOrDefault(m => m.MomentoId == tag.MomentoId && m.DisplayName == tag.Name);

            var tags = GetTags(new List<MomentoTag> {t});

            return Json(new
            {
                result = true,
                tag = tags.Single()
            }, JsonRequestBehavior.AllowGet);
        }

    }
}
