﻿using System;
using Momntz.Core.Contants;
using Momntz.Data.CommandHandlers;
using Momntz.Data.Commands.Logging;
using Momntz.Infrastructure.Configuration;

namespace Momntz.Infrastructure.Instrumentation.Logging
{
    public class Log: ILog
    {
        private readonly ICommandHandler<SaveLoggingCommand> _handler;
        private readonly ApplicationSettings _settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="Log"/> class.
        /// </summary>
        /// <param name="processor">The processor.</param>
        /// <param name="settings">The settings.</param>
        public Log(ICommandHandler<SaveLoggingCommand> handler, ApplicationSettings settings)
        {
            _handler = handler;
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
                return new LogToCloud(_handler);
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
        public void Exception(Exception ex, string statusCode = null, string message = null)
        {
            ILog log = GetLogger(_settings.LoggerType);
            log.Exception(ex, statusCode, message);
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
