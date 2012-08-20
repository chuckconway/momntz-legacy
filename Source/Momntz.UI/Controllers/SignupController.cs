using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Momntz.Data.Commands.Users;
using Momntz.Infrastructure;
using Momntz.UI.Core.Controllers;
using Momntz.UI.Models.Login;

namespace Momntz.UI.Controllers
{
    public class SignupController : BaseController
    {
        private readonly ICommandProcessor _processor;

        public SignupController(ICommandProcessor processor)
        {
            _processor = processor;
        }

        public ActionResult Welcome()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View(new LoginView());
        }

        [HttpPost]
        public ActionResult Index(string email, string firstname, string lastname, string displayname, string username, string password)
        {
            var user = new CreateUserCommand(username, username, email, displayname, firstname, lastname, password);
            _processor.Process(user);

            FormsAuthentication.SetAuthCookie(username, true); 

            return Redirect("SignUp/Welcome");
        }

    }
}
