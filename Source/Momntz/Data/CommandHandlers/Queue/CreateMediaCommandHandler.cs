using ChuckConway.Cloud.Queue;
using ChuckConway.Cloud.Storage;

using Momntz.Data.Commands.Queue;
using Momntz.Messaging;

namespace Momntz.Data.CommandHandlers.Queue
{
    public class CreateMediaCommandHandler : ICommandHandler<CreateMediaCommand>
    {
        private readonly IStorage _storage;
        private readonly IQueue _queue;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMediaCommandHandler" /> class.
        /// </summary>
        /// <param name="storage">The storage.</param>
        /// <param name="queue">The queue.</param>
        public CreateMediaCommandHandler(IStorage storage, IQueue queue)
        {
            _storage = storage;
            _queue = queue;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        public void Execute(CreateMediaCommand command)
        {
            _storage.AddFile(QueueConstants.MediaQueue, command.Id.ToString(), "application/octet-stream", command.Bytes);

            _queue.Send(QueueConstants.MediaQueue, command.Message);
            
        }
    }
}
