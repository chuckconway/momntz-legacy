using System.Collections.Generic;
using System.Web.Mvc;
using Momntz.Data.ProjectionHandlers.Api;
using Momntz.Data.Projections.Api;
using Momntz.Infrastructure;
using Momntz.UI.Core.Controllers;

namespace Momntz.UI.Controllers
{
    public class ApiController : BaseController
    {
        private readonly IProjectionProcessor _processor;

        public ApiController(IProjectionProcessor processor)
        {
            _processor = processor;
        }

        public ActionResult NameAutoComplete(string name)
        {
            NameAndUsername search = new NameAndUsername(){Name = name, Username = GetUsername()};
            var results = _processor.Process<NameAndUsername, List<NameSearchResult>>(search);

            return Json(results);
        }

    }
}
