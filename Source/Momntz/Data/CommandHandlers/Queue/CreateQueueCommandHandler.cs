using Hypersonic;
using Momntz.Data.Commands.Queue;
using Momntz.Model.Configuration;

namespace Momntz.Data.CommandHandlers.Queue
{
    public class CreateQueueCommandHandler : ICommandHandler<CreateQueueCommand>
    {
        private readonly IMomntzQueueSession _session;
        private readonly ISettings _settings;

        public CreateQueueCommandHandler(IMomntzQueueSession session, ISettings settings)
        {
            _session = session;
            _settings = settings;
        }

        public void Execute(CreateQueueCommand command)
        {
                _session.Session.Save(new {command.Implementation, command.Payload, MessageStatus = MessageStatus.Queued.ToString()}, "Queue");
        }
    }
}
