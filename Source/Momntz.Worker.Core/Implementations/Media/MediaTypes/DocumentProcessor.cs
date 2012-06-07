using System;
using Chucksoft.Storage;
using Hypersonic;


namespace Momntz.Worker.Core.Implementations.Media.MediaTypes
{
    public class DocumentProcessor : IMedia
    {
        private readonly IStorage _storage;
        private readonly ISession _session;

        public DocumentProcessor(IStorage storage, ISession session)
        {
            _storage = storage;
            _session = session;
        }

        public MediaType Media
        {
            get { return MediaType.Document; }
        }

        public void Process(MediaItem message)
        {
            throw new NotImplementedException();
        }
    }
}
