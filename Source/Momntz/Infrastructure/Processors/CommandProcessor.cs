using Momntz.Data.CommandHandlers;

namespace Momntz.Infrastructure.Processors
{
    public class CommandProcessor : ICommandProcessor
    {
        private readonly IInjection _injection;

        /// <summary> Constructor. </summary>
        /// <param name="injection"> The injection. </param>
        public CommandProcessor(IInjection injection)
        {
            _injection = injection;
        }

        /// <summary>
        /// Processes the specified command.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command">The command.</param>
        public void Process<T>(T command) where T : class
        {
            var commandHandler = _injection.Get<ICommandHandler<T>>();
            commandHandler.Execute(command);
        }
    }
}
