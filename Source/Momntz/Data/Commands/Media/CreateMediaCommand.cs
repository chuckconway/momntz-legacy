using System;
using Momntz.Messaging.Models;

namespace Momntz.Data.Commands.Media
{
    public class CreateMediaCommand : ICommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMediaCommand" /> class.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="extension">The extension.</param>
        /// <param name="bytes">The bytes.</param>
        public CreateMediaCommand(Guid id, byte[] bytes, MediaMessage message)
        {
            Id = id;
            Bytes = bytes;
            Message = message;
        }

        /// <summary>
        /// Gets the id.
        /// </summary>
        /// <value>The id.</value>
        public Guid Id { get; private set; }

        /// <summary>
        /// Gets the bytes.
        /// </summary>
        /// <value>The bytes.</value>
        public byte[] Bytes { get; private set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public MediaMessage Message { get; private set; }
    }
}
