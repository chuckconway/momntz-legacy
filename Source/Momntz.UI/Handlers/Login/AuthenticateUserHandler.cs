using System;
using System.Web.Security;
using Momntz.Data.ProjectionHandlers.Users;
using Momntz.Data.Projections.Users;
using Momntz.Infrastructure.Processors;
using Momntz.UI.Core;
using Momntz.UI.Models.Login;

namespace Momntz.UI.Handlers.Login
{
    public class AuthenticateUserHandler : HandlerBase, IFormHandler<UsernameAndPassword>
    {
        private readonly IProjectionProcessor _processor;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticateUserHandler" /> class.
        /// </summary>
        /// <param name="processor">The processor.</param>
        public AuthenticateUserHandler(IProjectionProcessor processor)
        {
            _processor = processor;
        }

        /// <summary>
        /// Handles the specified args.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <exception cref="System.Exception"></exception>
        public void Handle(UsernameAndPassword args)
        {
            var user = _processor.Process<UsernameAndPassword, AuthenticatedUser>(args);

            if (user == null)
            {
                const string message = "Invalid username or password.";

                Controller.ViewData.Model = new LoginView { Message = message };
                throw new Exception(message);
            }

            FormsAuthentication.SetAuthCookie(args.Username, true);
        }
    }
}