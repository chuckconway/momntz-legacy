using System;
using System.IO;
using System.Linq;
using System.Web.Script.Serialization;
using Momntz.Data.Commands.Queue;
using Momntz.Infrastructure;
using Momntz.Model.Core;

namespace Momntz.UI.Core
{
    public class MomentoUploader
    {
        private readonly ICommandProcessor _commandProcessor;
        readonly string[] _images = new[] { "jpg", "jpeg", "png", "gif", "tiff" };
        readonly string[] _documents = new[] { "pdf", "doc", "docx", "txt" };
        readonly string[] _videos = new[] { "avi", "mp4" };

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
            var extension = Path.GetExtension(filename);
            var mediaType = GetMediaType(extension);

            var id = Guid.NewGuid();
            var command = new CreateMediaCommand(id, filename, extension, bytes.Length, username, mediaType, bytes);
            _commandProcessor.Process(command);

            var message = GetMediaMessage(id, mediaType);
            var queue = new CreateQueueCommand("Momntz.Model.Core.MediaMessage", message);
            _commandProcessor.Process(queue);

            return id;
        }

        /// <summary>
        /// Gets the media message.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="mediaType">Type of the media.</param>
        /// <returns>System.String.</returns>
        private string GetMediaMessage(Guid id, string mediaType)
        {
            var mediaMessage = new MediaMessage { Id = id, MediaType = mediaType };
            var serializer = new JavaScriptSerializer();
            return serializer.Serialize(mediaMessage);
        }

        /// <summary>
        /// Gets the type of the media.
        /// </summary>
        /// <param name="extension">The extension.</param>
        /// <returns>System.String.</returns>
        private string GetMediaType(string extension)
        {
            string mediaType = "Unsupported";

            var types = new[]
                            {
                                new{Types = _images, MediaType = "Image"},
                                new {Types = _documents, MediaType = "Document"},
                                new {Types = _videos, MediaType = "Video"}
                            };

            extension = extension.TrimStart('.');

            foreach (var type in types.Where(type => type.Types.Any(s => string.Equals(s, extension, StringComparison.InvariantCultureIgnoreCase))))
            {
                mediaType = type.MediaType;
            }

            return mediaType;
        }
    }
}