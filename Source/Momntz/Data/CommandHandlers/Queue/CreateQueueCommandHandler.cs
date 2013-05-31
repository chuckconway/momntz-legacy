using System.Data;
using ChuckConway.Cloud.Queue;
using Hypersonic;
using Momntz.Data.Commands.Queue;

namespace Momntz.Data.CommandHandlers.Queue
{
    public class CreateQueueCommandHandler : ICommandHandler<CreateQueueCommand>
    {
        private readonly IQueue _queue;

        public CreateQueueCommandHandler(IQueue queue)
        {
            _queue = queue;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        public void Execute(CreateQueueCommand command)
        {
            //_queue.Send();
        }
    }
}
