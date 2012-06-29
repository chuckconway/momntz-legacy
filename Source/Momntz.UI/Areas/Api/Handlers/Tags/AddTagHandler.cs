using Momntz.Infrastructure;
using Momntz.UI.Areas.Api.Models;
using Momntz.UI.Core;

namespace Momntz.UI.Areas.Api.Handlers.Tags
{
    public class AddTagHandler : HandlerBase, IFormHandler<NewTag>
    {
        private readonly ICommandProcessor _commandProcessor;
        private readonly IProjectionProcessor _projectionProcessor;

        public AddTagHandler(ICommandProcessor commandProcessor, IProjectionProcessor projectionProcessor )
        {
            _commandProcessor = commandProcessor;
            _projectionProcessor = projectionProcessor;
        }

        public void Handle(NewTag args)
        {
            
        }
    }
}