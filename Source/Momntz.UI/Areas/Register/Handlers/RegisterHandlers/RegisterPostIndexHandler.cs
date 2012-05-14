using Momntz.Data.Commands.Users;
using Momntz.Infrastructure;
using Momntz.Infrastructure.Extensions;
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
            CreateUserCommand command = model.To<CreateUserCommand>();
            _processor.Process(command);
        }
    }
}