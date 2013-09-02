using System;
using System.Web.Security;
using Momntz.Data.Repositories.Users;
using Momntz.Data.Repositories.Users.Parameters;
using Momntz.UI.Core;
using Momntz.UI.Models.Login;

namespace Momntz.UI.Handlers.Login
{
    public class AuthenticateUserHandler : HandlerBase, IFormHandler<UsernameAndPassword>
    {
        private readonly IUserRepository _repository;


        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticateUserHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public AuthenticateUserHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Handles the specified args.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <exception cref="System.Exception"></exception>
        public void Handle(UsernameAndPassword args)
        {
            var user = _repository.AuthenticateUser(args);

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