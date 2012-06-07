using System;
using Hypersonic.Attributes;

namespace Momntz.Data.Commands.Queue
{
    public class CreateMediaCommand : ICommand
    {
        public CreateMediaCommand(Guid id, string filename, string extension, int size, string username, string contentType, string mediaType, byte[] bytes)
        {
            Id = id;
            Filename = filename;
            Extension = extension;
            Size = size;
            Username = username;
            ContentType = contentType;
            MediaType = mediaType;
            Bytes = bytes;
        }

        public Guid Id { get; private set; }

        public string Filename { get; private set; }

        public string Extension { get; private set; }

        public int Size { get; private set; }

        public string Username { get; private set; }

        public string ContentType { get; private set; }

        public string MediaType { get; private set; }

        [Ignore]
        public byte[] Bytes { get; private set; }
    }
}
