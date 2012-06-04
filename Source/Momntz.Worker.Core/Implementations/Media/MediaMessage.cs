using System;

namespace Momntz.Worker.Core.Implementations.Media
{
    public class MediaMessage
    {
        public Guid Id { get; set; }

        public MediaType MediaType { get; set; }
    }

    public enum MediaType
    {
        Image,
        Video,
        Document,
        Unsupported
    }
}

