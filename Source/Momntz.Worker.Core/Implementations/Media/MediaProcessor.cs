using System.Linq;
using System.Collections.Generic;
using Hypersonic;
using Momntz.Worker.Core.Implementations.Media.MediaTypes;

namespace Momntz.Worker.Core.Implementations.Media
{
    public class MediaProcessor : IMessageProcessor
    {
        private readonly ISession _session;

        public MediaProcessor(ISession session)
        {
            _session = session;
        }

        public string MessageType
        {
            get { return typeof (MediaMessage).FullName; }
        }

        public void Process(object message)
        {
            MediaMessage msg = (MediaMessage)message;
            var list = GetMediaTypes();
            var single = list.Single(m => m.Media == msg.MediaType);

            var item = _session.Query<MediaItem>("Media")
                .Where(i => i.Id == msg.Id)
                .Single();

            single.Process(item);
        }

        private IEnumerable<IMedia> GetMediaTypes()
        {
            return new List<IMedia>
                       {
                           new DocumentProcessor(),
                           new ImageProcessor(),
                           new VideoProcessor()
                       };
        }
    }
}
