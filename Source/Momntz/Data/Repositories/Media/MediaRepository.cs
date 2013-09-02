using ChuckConway.Cloud.Storage;
using Momntz.Data.Repositories.Media.Parameters;
using Momntz.Media;
using Momntz.Messaging;

namespace Momntz.Data.Repositories.Media
{
    public class MediaRepository : IMediaRepository
    {
        private readonly IMediaSaga _saga;
        private readonly IStorage _storage;

        /// <summary>
        ///     Initializes a new instance of the <see cref="CreateMediaCommandHandler" /> class.
        /// </summary>
        /// <param name="storage">The storage.</param>
        /// <param name="saga">The saga.</param>
        public MediaRepository(IStorage storage, IMediaSaga saga)
        {
            _storage = storage;
            _saga = saga;
        }


        /// <summary>
        ///     Saves the specified parameters.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        public void Save(SaveMediaParameters parameters)
        {
            _storage.AddFile(QueueConstants.MediaQueue, parameters.Id.ToString(), "application/octet-stream",
                parameters.Bytes);
            _saga.Consume(parameters.Message);
        }
    }
}