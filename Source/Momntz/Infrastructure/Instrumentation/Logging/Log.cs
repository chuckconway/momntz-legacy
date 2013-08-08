using System;
using Momntz.Core.Contants;
using Momntz.Infrastructure.Configuration;
using Momntz.Infrastructure.Processors;

namespace Momntz.Infrastructure.Instrumentation.Logging
{
    public class Log: ILog
    {
        private readonly ICommandProcessor _processor;
        private readonly ApplicationSettings _settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="Log"/> class.
        /// </summary>
        /// <param name="processor">The processor.</param>
        /// <param name="settings">The settings.</param>
        public Log(ICommandProcessor processor, ApplicationSettings settings)
        {
            _processor = processor;
            _settings = settings;
        }

        /// <summary>
        /// Gets the logger.
        /// </summary>
        /// <param name="logKey">The log key.</param>
        /// <returns>ILog.</returns>
        private ILog GetLogger(string logKey)
        {
            if (logKey == LoggingConstants.Cloud)
            {
                return new LogToCloud(_processor);
            }

            if (logKey == LoggingConstants.File)
            {
                string path = _settings.LoggingFilePath;
                return new LogToFile(path);
            }

            return null;
        }

        /// <summary>
        /// Exceptions the specified ex.
        /// </summary>
        /// <param name="ex">The ex.</param>
        /// <param name="message">The message.</param>
        public void Exception(Exception ex, string message = null)
        {
            ILog log = GetLogger(_settings.LoggerType);
            log.Exception(ex, message);
        }

        /// <summary>
        /// Debugs the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Debug(string message)
        {
            ILog log = GetLogger(_settings.LoggerType);
            log.Debug(message);
        }
    }
}
