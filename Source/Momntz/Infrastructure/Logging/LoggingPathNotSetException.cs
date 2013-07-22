using System;

namespace Momntz.Infrastructure.Logging
{
    public class LoggingPathNotSetException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoggingPathNotSetException"/> class.
        /// </summary>
        public LoggingPathNotSetException():base("Logging path not set"){} 
    }
}
