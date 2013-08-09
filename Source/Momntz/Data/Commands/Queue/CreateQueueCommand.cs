using Momntz.Messaging.Models;

namespace Momntz.Data.Commands.Queue
{
    public class CreateQueueCommand : ICommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateQueueCommand"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public CreateQueueCommand(Media message)
        {
            Message = message;
        }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public Media Message { get; set; }
    }

}
