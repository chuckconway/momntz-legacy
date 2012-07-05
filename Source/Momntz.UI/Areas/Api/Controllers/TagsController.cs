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

        public ActionResult NameAutoComplete(string name)
        {
            NameAndUsername search = new NameAndUsername() { Name = name, Username = GetUsername() };
            var results = _processor.Process<NameAndUsername, List<NameSearchResult>>(search);

            return Json(results);
        }

        public ActionResult Add(NewTag tag)
        {
            return Json(1);
        }

    }
}
