using Momntz.Data.Commands.Queue;

namespace Momntz.Model.QueueData
{
    public class Queue
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        public virtual int Id { get; set; }

        /// <summary>
        /// Gets or sets the implementation.
        /// </summary>
        /// <value>The implementation.</value>
        public virtual string Implementation { get; set; }

        /// <summary>
        /// Gets or sets the payload.
        /// </summary>
        /// <value>The payload.</value>
        public virtual string Payload { get; set; }

        /// <summary>
        /// Gets or sets the error.
        /// </summary>
        /// <value>The error.</value>
        public virtual string Error { get; set; }
        
        /// <summary>
        /// Gets or sets the message status.
        /// </summary>
        /// <value>The message status.</value>
        public virtual MessageStatus MessageStatus { get; set; }
    }
}
