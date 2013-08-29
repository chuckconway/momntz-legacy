using System;
using System.Collections.Generic;
using System.Linq;
using ChuckConway.Cloud.Storage;
using Momntz.Infrastructure.Configuration;
using Momntz.Infrastructure.Instrumentation.Logging;
using Momntz.Media.Types;
using Momntz.Media.Types.Documents;
using Momntz.Media.Types.Images;
using Momntz.Media.Types.Videos;
using Momntz.Messaging;
using Momntz.Messaging.Models;
using NHibernate;

namespace Momntz.Media
{
    public class MediaSaga : IMediaSaga
    {
        private readonly ILog _log;
        private readonly List<MediaType> _processors;

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaSaga"/> class.
        /// </summary>
        /// <param name="storage">The storage.</param>
        /// <param name="settings">The settings.</param>
        public MediaSaga(IStorage storage, ISettings settings, ISessionFactory factory, ILog log)
        {
            _log = log;
            _processors = GetProcessors(storage, settings, factory);
        }

        /// <summary>
        /// Gets the processors.
        /// </summary>
        /// <param name="storage">The storage.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="factory">The factory.</param>
        /// <returns>List{MomentoMediaType}.</returns>
        private List<MediaType> GetProcessors(IStorage storage, ISettings settings, ISessionFactory factory)
        {
            return new List<MediaType>
                {
                    new MediaType {MediaProcessor = new ImageProcessor(storage, settings, factory) , Extensions = new[]{"bmp", "gif", "jpg", "jpeg", "png", "tiff", "tif"}},
                    new MediaType {MediaProcessor = new VideoProcessor(storage), Extensions = new[]{"mp4"}},
                    new MediaType {MediaProcessor = new DocumentProcessor(), Extensions = new[]{ "doc", "docx", "pdf", "txt"}}
                };
        }

        /// <summary>
        /// Consumes the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Consume(MediaMessage message)
        {
            try
            {
                var processor = _processors.First(m => m.Extensions.Contains(message.Extension.ToLower()));
                processor.MediaProcessor.Consume(message);
            }
            catch (Exception ex)
            {
                string error = "MediaSaga exception ";

                if (message != null)
                {
                    error += message.ToString();
                }

                _log.Exception(ex, error);
            }
        }

        /// <summary>
        /// Gets the type. In Windows Azure Service Bus this is the same as a Subscription
        /// </summary>
        /// <value>The type.</value>
        public string Type { get { return QueueConstants.MediaQueue; } }

        private class MediaType
        {
            /// <summary>
            /// Gets or sets the extensions.
            /// </summary>
            /// <value>The extensions.</value>
            public string[] Extensions { get; set; }

            /// <summary>
            /// Gets or sets the media.
            /// </summary>
            /// <value>The media.</value>
            public IMedia MediaProcessor { get; set; }
        }
    }
}
