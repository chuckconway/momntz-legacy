using ChuckConway.Cloud.Storage;
using Momntz.Data.CommandHandlers.Media.Parameters;
using Momntz.Media;
using Momntz.Messaging;

namespace Momntz.Data.CommandHandlers.Media
{
    public class MediaRepository : IMediaRepository
    {
        private readonly IStorage _storage;
        private readonly IMediaSaga _saga;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMediaCommandHandler" /> class.
        /// </summary>
        /// <param name="storage">The storage.</param>
        /// <param name="saga">The saga.</param>
        public MediaRepository(IStorage storage, IMediaSaga saga)
        {
            _storage = storage;
            _saga = saga;
        }


        /// <summary>
        /// Saves the specified parameters.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        public void Save(SaveMediaParameters parameters)
        {
            _storage.AddFile(QueueConstants.MediaQueue, parameters.Id.ToString(), "application/octet-stream", parameters.Bytes);
            _saga.Consume(parameters.Message);
        }
    }
}