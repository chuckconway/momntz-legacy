using Hypersonic;
using Momntz.Data.Commands.Queue;

namespace Momntz.Data.CommandHandlers.Queue
{
    public class CreateQueueCommandHandler : ICommandHandler<CreateQueueCommand>
    {
        private readonly ISession _session;

        public CreateQueueCommandHandler(ISession session)
        {
            _session = session;
        }

        public void Execute(CreateQueueCommand command)
        {
            try
            {
                _session.Database.ConnectionStringName = "queue";
                _session.Save(new {command.Implementation, command.Payload, MessageStatus = MessageStatus.Queued.ToString()}, "Queue");
            }
            finally 
            {
                _session.Database.ConnectionStringName = null;
            }
           
        }
    }
}
