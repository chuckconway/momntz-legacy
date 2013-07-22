using System;
using System.Globalization;
using System.IO;

namespace Momntz.Infrastructure.Logging
{
    public class LogToFile : ILog
    {
        private readonly string _fullFilePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogToFile"/> class.
        /// </summary>
        /// <param name="fullFilePath">The full file path.</param>
        public LogToFile(string fullFilePath)
        {
            _fullFilePath = fullFilePath;
        }

        /// <summary>
        /// Writes the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        private void Write(string message)
        {
            var log = AddMetadata();
            log += message;
            
            if (!string.IsNullOrEmpty(_fullFilePath))
            {
                string path = GetFilePath(_fullFilePath);
                File.AppendAllText(path, log);
            }
            else
            {
                throw new LoggingPathNotSetException();
            }
        }

        /// <summary>
        /// Adds the metadata.
        /// </summary>
        /// <returns>System.String.</returns>
        private static string AddMetadata()
        {
            string log = DateTime.UtcNow.ToString(CultureInfo.InvariantCulture) + Environment.NewLine;

            log += "[Machine Name]:" + Environment.MachineName + Environment.NewLine;
            log += "[OS Version]:" + Environment.OSVersion + Environment.NewLine;
            log += "[User]:" + Environment.UserDomainName + @"\" + Environment.UserName + Environment.NewLine;
            log += "[System Directory]:" + Environment.SystemDirectory + Environment.NewLine;
            log += "[Version]:" + Environment.Version + Environment.NewLine;
            log += "[Current Directory]:" + Environment.CurrentDirectory + Environment.NewLine;

            return log;
        }

        /// <summary>
        /// Gets the file path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>System.String.</returns>
        private string GetFilePath(string path)
        {
            string directory = Path.GetDirectoryName(path);
            string file = Path.GetFileName(path);
            string datePath = DateTime.UtcNow.Year + @"\" + DateTime.UtcNow.Month + @"\" + DateTime.UtcNow.Day;

            string fullDirectoryPath = directory + @"\" + datePath + @"\";

            if (!Directory.Exists(fullDirectoryPath))
            {
                Directory.CreateDirectory(fullDirectoryPath);
            }

            return fullDirectoryPath + file;
        }

        /// <summary>
        /// Logs the Exception details
        /// </summary>
        /// <param name="ex">The ex.</param>
        /// <param name="message">The message.</param>
        public void Exception(Exception ex, string message = null)
        {
            string log = message + Environment.NewLine + ex;
            Write(log);
        }

        /// <summary>
        /// Debugs the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Debug(string message)
        {
            Write(message);
        }
    }
}