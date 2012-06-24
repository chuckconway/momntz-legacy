using System.Web.Security;
using Momntz.Data.ProjectionHandlers.Users;
using Momntz.Data.Projections.Users;
using Momntz.Infrastructure;
using Momntz.UI.Core;
using Momntz.UI.Models.Login;

namespace Momntz.UI.Handlers.Login
{
    public class AuthenticateUserHandler : HandlerBase, IFormHandler<UsernameAndPassword>
    {
        private readonly IProjectionProcessor _processor;

        public AuthenticateUserHandler(IProjectionProcessor processor)
        {
            _processor = processor;
        }

        public void Handle(UsernameAndPassword args)
        {
            var user = _processor.Process<UsernameAndPassword, AuthenticatedUser>(args);

            if (user == null)
            {
                Controller.ViewData.Model = new LoginView {Message = "Invalid username or password."};
            }
            else
            {
                FormsAuthentication.SetAuthCookie(args.Username, true); 
            }
        }
    }
}