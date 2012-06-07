using Chucksoft.Storage;
using Hypersonic;

namespace Momntz.Worker.Core.Implementations.Media.MediaTypes
{
    public class ImageProcessor : MediaBase, IMedia
    {
        private readonly ISession _session;

        public ImageProcessor(IStorage storage, ISession session) :base(storage)
        {
            _session = session;
        }

        public MediaType Media
        {
            get { return MediaType.Image; }
        }

        public void Process(MediaItem message)
        {
            AddToStorage("img", "image", message);
        }
    }
}
