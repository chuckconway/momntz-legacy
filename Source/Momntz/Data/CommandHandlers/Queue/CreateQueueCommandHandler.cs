using Hypersonic;
using Momntz.Data.Commands.Queue;
using Momntz.Model.Configuration;

namespace Momntz.Data.CommandHandlers.Queue
{
    public class CreateQueueCommandHandler : ICommandHandler<CreateQueueCommand>
    {
        private readonly ISession _session;
        private readonly ISettings _settings;

        public CreateQueueCommandHandler(ISession session, ISettings settings)
        {
            _session = session;
            _settings = settings;
        }

        public void Execute(CreateQueueCommand command)
        {
            try
            {
                _session.Database.ConnectionString = _settings.QueueDatabase;
                _session.Save(new {command.Implementation, command.Payload, MessageStatus = MessageStatus.Queued.ToString()}, "Queue");
            }
            finally 
            {
                _session.Database.ConnectionString = null;
            }
           
        }
    }
}
