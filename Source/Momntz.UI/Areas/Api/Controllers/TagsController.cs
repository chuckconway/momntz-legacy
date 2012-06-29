using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Momntz.UI.Areas.Api.Models;

namespace Momntz.UI.Areas.Api.Controllers
{
    public class TagsController : Controller
    {

        public ActionResult Add(NewTag tag)
        {
            return Json(1);
        }

    }
}
