using System;
using System.Text;
using ChuckConway.Cloud.Queue;
using ChuckConway.Cloud.Storage;
using Momntz.Data.CommandHandlers.Logging.Parameters;
using Momntz.Infrastructure.Configuration;
using Momntz.Infrastructure.Instrumentation.Logging.Models;
using Momntz.Messaging;

namespace Momntz.Data.CommandHandlers.Logging
{
    public class LoggingRepository : ILoggingRepository
    {
        private readonly IStorage _storage;
        private readonly IQueue _queue;
        private readonly ApplicationSettings _settings;


        /// <summary>
        /// Initializes a new instance of the <see cref="LoggingRepository"/> class.
        /// </summary>
        /// <param name="storage">The storage.</param>
        /// <param name="queue">The queue.</param>
        /// <param name="settings">The settings.</param>
        public LoggingRepository(IStorage storage, IQueue queue, ApplicationSettings settings)
        {
            _storage = storage;
            _queue = queue;
            _settings = settings;
        }

        /// <summary>
        /// Executes the specified parameters.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        public void Log(SaveLoggingParameters parameters)
        {
            try
            {
                Guid id = Guid.NewGuid();

                //save message to storage
                _storage.AddFile(QueueConstants.LoggingQueue, id.ToString(), "application/octet-stream", Encoding.Default.GetBytes(parameters.Message));

                //queue message for the logging service to process
                _queue.Send(QueueConstants.LoggingQueue, new QueueLogMessage { Id = id, Endpoint = _settings.RestLoggingEndpoint });

            }
            catch (Exception)
            {
                //we can do nothing.
            }
        }
    }
}