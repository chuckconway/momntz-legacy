using Momntz.Data.Repositories.Users;
using Momntz.Data.Repositories.Users.Parameters;
using Momntz.Infrastructure.Extensions;
using Momntz.UI.Areas.Join.Models;
using Momntz.UI.Core;

namespace Momntz.UI.Areas.Join.Handlers.RegisterHandlers
{
    public class RegisterPostIndexHandler : HandlerBase, IFormHandler<JoinIndexModel>
    {
        private readonly IUserRepository _repository;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="createUser">The create user.</param>
        public RegisterPostIndexHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        /// <summary> Handles the model. </summary>
        /// <param name="model"> The model. </param>
        public void Handle(JoinIndexModel model)
        {
            var command = model.To<CreateUserParameters>();
            
            command.CreatedBy = command.Username;
            _repository.Create(command);
        }
    }
}