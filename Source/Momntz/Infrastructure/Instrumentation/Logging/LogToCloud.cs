using Momntz.Data.Commands.Logging;
using Momntz.Infrastructure.Processors;

namespace Momntz.Infrastructure.Instrumentation.Logging
{
    public class LogToCloud : LogBase
    {
        private readonly ICommandProcessor _processor;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogToCloud"/> class.
        /// </summary>
        /// <param name="processor">The processor.</param>
        public LogToCloud(ICommandProcessor processor)
        {
            _processor = processor;
        }

        /// <summary>
        /// Persists the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        protected override void Persist(string message)
        {
            var command = new SaveLoggingCommand {Message = message};
            _processor.Process(command);
        }
    }
}
