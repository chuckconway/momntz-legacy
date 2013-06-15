namespace Momntz.Data.Commands.Queue
{
    public class CreateQueueCommand : ICommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateQueueCommand"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public CreateQueueCommand(string message)
        {
            Message = message;
        }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; set; }
    }

}
