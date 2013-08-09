using System;

namespace Momntz.Infrastructure.Instrumentation.Logging
{
    public interface ILog
    {
        /// <summary>
        /// Exceptions the specified ex.
        /// </summary>
        /// <param name="ex">The ex.</param>
        /// <param name="statusCode">The status code.</param>
        /// <param name="message">The message.</param>
        void Exception(Exception ex, string statusCode = null, string message = null);

        /// <summary>
        /// Debugs the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Debug(string message);
    }
}
