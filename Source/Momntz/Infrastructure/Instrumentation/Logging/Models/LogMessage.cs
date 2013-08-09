
using Newtonsoft.Json;

namespace Momntz.Infrastructure.Instrumentation.Logging.Models
{
    public class LogMessage
    {
        /// <summary>
        /// Gets or sets the name of the machine.
        /// </summary>
        /// <value>The name of the machine.</value>
        public string MachineName { get; set; }

        /// <summary>
        /// Gets or sets the OS version.
        /// </summary>
        /// <value>The OS version.</value>
        public string OSVersion { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>The user.</value>
        public string User { get; set; }

        /// <summary>
        /// Gets or sets the system directory.
        /// </summary>
        /// <value>The system directory.</value>
        public string SystemDirectory { get; set; }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>The version.</value>
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the current directory.
        /// </summary>
        /// <value>The current directory.</value>
        public string CurrentDirectory { get; set; }

        /// <summary>
        /// Gets or sets the exception.
        /// </summary>
        /// <value>The exception.</value>
        public string Exception { get; set; }

        /// <summary>
        /// Gets or sets the start time.
        /// </summary>
        /// <value>The start time.</value>
        public string StartTime { get; set; }

        /// <summary>
        /// Gets or sets the end time.
        /// </summary>
        /// <value>The end time.</value>
        public string EndTime { get; set; }

        /// <summary>
        /// Gets or sets the elasped time.
        /// </summary>
        /// <value>The elasped time.</value>
        public string ElaspedTime { get; set; }

        /// <summary>
        /// Gets or sets the timestamp.
        /// </summary>
        /// <value>The timestamp.</value>
        public string Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the type of the log.
        /// </summary>
        /// <value>The type of the log.</value>
        public string LogType { get; set; }

        /// <summary>
        /// Gets or sets the HTTP code.
        /// </summary>
        /// <value>The HTTP code.</value>
        public string HttpCode { get; set; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
           return JsonConvert.SerializeObject(this);
        }
    }
}
