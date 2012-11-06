using System;
using Hypersonic.Attributes;

namespace Momntz.Data.Commands.Queue
{
    public class CreateMediaCommand : ICommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMediaCommand" /> class.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="filename">The filename.</param>
        /// <param name="extension">The extension.</param>
        /// <param name="size">The size.</param>
        /// <param name="username">The username.</param>
        /// <param name="mediaType">Type of the media.</param>
        /// <param name="bytes">The bytes.</param>
        public CreateMediaCommand(Guid id, string filename, string extension, int size, string username, string mediaType, byte[] bytes)
        {
            Id = id;
            Filename = filename;
            Extension = extension;
            Size = size;
            Username = username;
            MediaType = mediaType;
            Bytes = bytes;
        }

        /// <summary>
        /// Gets the id.
        /// </summary>
        /// <value>The id.</value>
        public Guid Id { get; private set; }

        /// <summary>
        /// Gets the filename.
        /// </summary>
        /// <value>The filename.</value>
        public string Filename { get; private set; }

        /// <summary>
        /// Gets the extension.
        /// </summary>
        /// <value>The extension.</value>
        public string Extension { get; private set; }

        /// <summary>
        /// Gets the size.
        /// </summary>
        /// <value>The size.</value>
        public int Size { get; private set; }

        /// <summary>
        /// Gets the username.
        /// </summary>
        /// <value>The username.</value>
        public string Username { get; private set; }

        /// <summary>
        /// Gets the type of the media.
        /// </summary>
        /// <value>The type of the media.</value>
        public string MediaType { get; private set; }

        /// <summary>
        /// Gets the bytes.
        /// </summary>
        /// <value>The bytes.</value>
        [Ignore]
        public byte[] Bytes { get; private set; }
    }
}
