using System;
using System.Text;
using ChuckConway.Cloud.Queue;
using ChuckConway.Cloud.Storage;
using Momntz.Data.CommandHandlers.Queue;
using Momntz.Data.Commands.Logging;
using Momntz.Messaging;

namespace Momntz.Data.CommandHandlers.Logging
{
    public class SaveLoggingCommandHandler : ICommandHandler<SaveLoggingCommand>
    {
        private readonly IStorage _storage;
        private readonly IQueue _queue;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMediaCommandHandler"/> class.
        /// </summary>
        /// <param name="storage">The storage.</param>
        /// <param name="queue"></param>
        public SaveLoggingCommandHandler(IStorage storage, IQueue queue)
        {
            _storage = storage;
            _queue = queue;
        }

        /// <summary>
        /// Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Execute(SaveLoggingCommand command)
        {
            try
            {
                Guid id = Guid.NewGuid();

                //save message to storage
                _storage.AddFile(QueueConstants.LoggingQueue, id.ToString(), "application/octet-stream", Encoding.Default.GetBytes(command.Message));

                //queue message for the logging service to process
                _queue.Send(QueueConstants.LoggingQueue, new {Id=id});            
            
            }
            catch (Exception)
            {
                //we can do nothing.
            }
        }
    }

}
