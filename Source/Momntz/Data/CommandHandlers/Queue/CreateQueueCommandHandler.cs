using ChuckConway.Cloud.Queue;
using Momntz.Data.Commands.Queue;
using Momntz.Infrastructure.Instrumentation.Logging;
using Momntz.Messaging;

namespace Momntz.Data.CommandHandlers.Queue
{
    public class CreateQueueCommandHandler : ICommandHandler<CreateQueueCommand>
    {
        private readonly IQueue _queue;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateQueueCommandHandler"/> class.
        /// </summary>
        /// <param name="queue">The queue.</param>
        public CreateQueueCommandHandler(IQueue queue)
        {
            _queue = queue;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        [Log]
        public void Execute(CreateQueueCommand command)
        {
            _queue.Send(QueueConstants.MediaQueue, command.Message);
        }
    }
}
