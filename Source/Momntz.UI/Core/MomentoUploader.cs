using System;
using System.IO;
using Momntz.Data.Commands.Queue;
using Momntz.Infrastructure.Processors;
using Momntz.Messaging.Models;

namespace Momntz.UI.Core
{
    public class MomentoUploader
    {
        private readonly ICommandProcessor _commandProcessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="MomentoUploader" /> class.
        /// </summary>
        /// <param name="commandProcessor">The command processor.</param>
        public MomentoUploader(ICommandProcessor commandProcessor)
        {
            _commandProcessor = commandProcessor;
        }


        /// <summary>
        /// Adds the specified filename.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="username">The username.</param>
        /// <param name="bytes">The bytes.</param>
        /// <returns>Guid.</returns>
        public Guid Add(string filename, string username, byte[] bytes)
        {
            var extension = Path.GetExtension(filename).Replace(".", string.Empty);

               var id = Guid.NewGuid();
            var media = new Media
                {
                    Extension = extension,
                    Filename = filename,
                    Id = id,
                    Size = bytes.Length,
                    Username = username
                };

            //Save the media to storage
            var command = new CreateMediaCommand(id, bytes);
            _commandProcessor.Process(command);

            //Add a message to the queue for processing the message
            var queue = new CreateQueueCommand(media);
            _commandProcessor.Process(queue);

            //Make request to service to process image.

            return id;
        }
    }
}