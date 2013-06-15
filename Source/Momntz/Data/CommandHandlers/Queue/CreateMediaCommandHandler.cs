using ChuckConway.Cloud.Storage;

using Momntz.Data.Commands.Queue;

namespace Momntz.Data.CommandHandlers.Queue
{
    public class CreateMediaCommandHandler : ICommandHandler<CreateMediaCommand>
    {
        private readonly IStorage _storage;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMediaCommandHandler"/> class.
        /// </summary>
        /// <param name="storage">The storage.</param>
        public CreateMediaCommandHandler(IStorage storage)
        {
            _storage = storage;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        public void Execute(CreateMediaCommand command)
        {
            _storage.AddFile(StorageConstants.QueueBucket, command.Id.ToString(), "application/octet-stream", command.Bytes);
        }
    }
}
