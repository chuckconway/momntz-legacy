using ChuckConway.Cloud.Storage;
using Momntz.Data.Commands.Media;
using Momntz.Media;
using Momntz.Messaging;

namespace Momntz.Data.CommandHandlers.Media
{
    public class CreateMediaCommandHandler : ICommandHandler<CreateMediaCommand>
    {
        private readonly IStorage _storage;
        private readonly IMediaSaga _saga;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMediaCommandHandler" /> class.
        /// </summary>
        /// <param name="storage">The storage.</param>
        /// <param name="saga">The saga.</param>
        public CreateMediaCommandHandler(IStorage storage, IMediaSaga saga)
        {
            _storage = storage;
            _saga = saga;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="parameters">The command.</param>
        public void Execute(CreateMediaCommand parameters)
        {
            _storage.AddFile(QueueConstants.MediaQueue, parameters.Id.ToString(), "application/octet-stream", parameters.Bytes);
            _saga.Consume(parameters.Message);
        }
    }
}
