using Hypersonic;
using Momntz.Worker.Core.Storage;

namespace Momntz.Worker.Core.Implementations.Media.MediaTypes
{
    public class VideoProcessor : IMedia
    {
        private readonly IStorage _storage;
        private readonly ISession _session;

        public VideoProcessor(IStorage storage, ISession session)
        {
            _storage = storage;
            _session = session;
        }

        public MediaType Media
        {
            get { return MediaType.Video; }
        }

        public void Process(MediaItem message)
        {
            
        }
    }
}
