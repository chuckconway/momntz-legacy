using Hypersonic;
using Momntz.Data.Commands.Queue;
using Momntz.Model.Configuration;

namespace Momntz.Data.CommandHandlers.Queue
{
    public class CreateQueueCommandHandler : ICommandHandler<CreateQueueCommand>
    {
        private readonly IDatabase _database;
        private readonly ISettings _settings;

        public CreateQueueCommandHandler(IDatabase database, ISettings settings)
        {
            _database = database;
            _settings = settings;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        public void Execute(CreateQueueCommand command)
        {
            _database.ConnectionString = _settings.QueueDatabase;
            _database.NonQuery("Queue_Save", new { command.Implementation, command.Payload, MessageStatus = MessageStatus.Queued.ToString() });
        }
    }
}
