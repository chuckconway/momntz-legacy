using System;

namespace Momntz.Worker.Core.Implementations.Media.MediaTypes
{
    public class MediaItem
    {
        public Guid Id { get; set; }

        public string Filename { get; set; }

        public string Extension { get; set; }

        public int Size { get; set; }

        public string Username { get; set; }

        public string ContentType { get; set; }

        public string MediaType { get; set; }

        public byte[] Bytes { get; set; }
    }
}
