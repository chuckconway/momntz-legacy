using System;
using System.IO;
using Momntz.Infrastructure.Instrumentation.Logging.Exceptions;

namespace Momntz.Infrastructure.Instrumentation.Logging
{
    public class LogToFile : LogBase
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
        /// Persists the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <exception cref="LoggingPathNotSetException"></exception>
        protected override void Persist(string message)
        {
            if (!string.IsNullOrEmpty(_fullFilePath))
            {
                string path = GetFilePath(_fullFilePath);
                File.AppendAllText(path, message);
            }
            else
            {
                throw new LoggingPathNotSetException();
            }
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
    }
}
