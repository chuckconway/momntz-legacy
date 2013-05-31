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
        /// <param name="extension">The extension.</param>
        /// <param name="mediaType">Type of the media.</param>
        /// <param name="bytes">The bytes.</param>
        public CreateMediaCommand(Guid id, string extension, string mediaType, byte[] bytes)
        {
            Id = id;
            Extension = extension;
            MediaType = mediaType;
            Bytes = bytes;
        }

        /// <summary>
        /// Gets the id.
        /// </summary>
        /// <value>The id.</value>
        public Guid Id { get; private set; }


        /// <summary>
        /// Gets the extension.
        /// </summary>
        /// <value>The extension.</value>
        public string Extension { get; private set; }


        /// <summary>
        /// Gets the type of the media.
        /// </summary>
        /// <value>The type of the media.</value>
        public string MediaType { get; private set; }

        /// <summary>
        /// Gets the bytes.
        /// </summary>
        /// <value>The bytes.</value>
        public byte[] Bytes { get; private set; }
    }
}
