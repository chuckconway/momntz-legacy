﻿using System;
using System.Globalization;
using System.Threading.Tasks;

namespace Momntz.Infrastructure.Instrumentation.Logging
{
    public abstract class LogBase: ILog
    {
        /// <summary>
        /// Writes the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        private void Write(LogMessage message)
        {
            AddMetadata(message);
            Task.Run(() => Persist(message.ToString()));
        }

        /// <summary>
        /// Persists the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public abstract void Persist(string message);

        /// <summary>
        /// Adds the metadata.
        /// </summary>
        /// <returns>System.String.</returns>
        private static void AddMetadata(LogMessage message)
        {
            message.Timestamp = DateTime.UtcNow.ToString(CultureInfo.InvariantCulture);

            message.MachineName = Environment.MachineName;
            message.OSVersion = Environment.OSVersion.ToString();
            message.User =  Environment.UserDomainName + @"\" + Environment.UserName;
            message.SystemDirectory = Environment.SystemDirectory;
            message.Version = Environment.Version.ToString();
            message.CurrentDirectory = Environment.CurrentDirectory;
        }

        /// <summary>
        /// Logs the Exception details
        /// </summary>
        /// <param name="ex">The ex.</param>
        /// <param name="message">The message.</param>
        public void Exception(Exception ex, string message = null)
        {
            var logMessage = new LogMessage {Message = message, Exception = ex.ToString(), LogType = LogType.Exception};
            Write(logMessage);
        }

        /// <summary>
        /// Debugs the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Debug(string message)
        {
            var logMessage = new LogMessage { Message = message, LogType = LogType.Debug };
            Write(logMessage);
        }
    }
}