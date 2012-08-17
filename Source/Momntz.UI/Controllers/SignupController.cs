using System.Web.Mvc;
using Momntz.Data.Commands.Users;
using Momntz.Infrastructure;
using Momntz.UI.Models.Login;

namespace Momntz.UI.Controllers
{
    public class SignupController : Controller
    {
        private readonly ICommandProcessor _processor;

        public SignupController(ICommandProcessor processor)
        {
            _processor = processor;
        }

        public ActionResult Index()
        {
            return View(new LoginView());
        }

        public ActionResult Success()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string email, string firstname, string lastname, string displayname, string username, string password)
        {
            var user = new CreateUserCommand(username, username, email, displayname, firstname, lastname, password);
            _processor.Process(user);

            return Redirect("SignUp/Success");
        }
    }
}
