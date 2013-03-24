using Momntz.Data.Commands.Users;
using Momntz.Infrastructure.Extensions;
using Momntz.Infrastructure.Processors;
using Momntz.UI.Areas.Register.Models;
using Momntz.UI.Core;

namespace Momntz.UI.Areas.Register.Handlers.RegisterHandlers
{
    public class RegisterPostIndexHandler : HandlerBase, IFormHandler<RegisterIndexModel>
    {
        private readonly ICommandProcessor _processor;

        /// <summary> Constructor. </summary>
        /// <param name="processor"> The processor. </param>
        public RegisterPostIndexHandler(ICommandProcessor processor)
        {
            _processor = processor;
        }

        /// <summary> Handles the model. </summary>
        /// <param name="model"> The model. </param>
        public void Handle(RegisterIndexModel model)
        {
            var command = model.To<CreateUserCommand>();
            command.CreatedBy = command.Username;
            _processor.Process(command);
        }
    }
}