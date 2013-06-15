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
        /// <param name="bytes">The bytes.</param>
        public CreateMediaCommand(Guid id, byte[] bytes)
        {
            Id = id;
            Bytes = bytes;
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
    }
}
