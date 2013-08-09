using Momntz.Data.CommandHandlers;
using Momntz.Data.Commands.Users;
using Momntz.Infrastructure.Extensions;
using Momntz.UI.Areas.Join.Models;
using Momntz.UI.Core;

namespace Momntz.UI.Areas.Join.Handlers.RegisterHandlers
{
    public class RegisterPostIndexHandler : HandlerBase, IFormHandler<JoinIndexModel>
    {
        private readonly ICommandHandler<CreateUserCommand> _createUser;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="createUser">The create user.</param>
        public RegisterPostIndexHandler(ICommandHandler<CreateUserCommand> createUser)
        {
            _createUser = createUser;
        }

        /// <summary> Handles the model. </summary>
        /// <param name="model"> The model. </param>
        public void Handle(JoinIndexModel model)
        {
            var command = model.To<CreateUserCommand>();
            command.CreatedBy = command.Username;
            _createUser.Execute(command);
        }
    }
}