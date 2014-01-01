using System;

namespace Momntz.Infrastructure.Instrumentation.Logging.Exceptions
{
    public class LoggingPathNotSetException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoggingPathNotSetException"/> class.
        /// </summary>
        public LoggingPathNotSetException():base("Logging path not set"){} 
    }
}
