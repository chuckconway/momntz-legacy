using Momntz.Data.CommandHandlers;
using Momntz.Data.Commands.Logging;

namespace Momntz.Infrastructure.Instrumentation.Logging
{
    public class LogToCloud : LogBase
    {
        private readonly ICommandHandler<SaveLoggingCommand> _handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogToCloud" /> class.
        /// </summary>
        /// <param name="handler">The handler.</param>
        public LogToCloud(ICommandHandler<SaveLoggingCommand> handler)
        {
            _handler = handler;
        }

        /// <summary>
        /// Persists the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        protected override void Persist(string message)
        {
            var command = new SaveLoggingCommand {Message = message};
            _handler.Execute(command);
        }
    }
}
