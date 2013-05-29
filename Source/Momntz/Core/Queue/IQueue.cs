using System;
using ChuckConway.Cloud.Queue;
using Microsoft.ServiceBus.Messaging;
using Newtonsoft.Json;

namespace Momntz.Core.Queue
{
    public interface IMomntzQueue
    {
        /// <summary>
        /// Sends the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Send(string queue, object message);

        /// <summary>
        /// Receives this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>``0.</returns>
        T Receive<T>(string queue) where T : class, new();
    }

    public class MomntzQueue : IMomntzQueue
    {
        private readonly IQueue _queue;

        /// <summary>
        /// Initializes a new instance of the <see cref="MomntzQueue"/> class.
        /// </summary>
        /// <param name="queue">The queue.</param>
        public MomntzQueue(IQueue queue)
        {
            _queue = queue;
        }

        /// <summary>
        /// Sends the specified message.
        /// </summary>
        /// <param name="queue">The queue.</param>
        /// <param name="message">The message.</param>
        public void Send(string queue, object message)
        {
            _queue.Send(queue, message);
        }

        /// <summary>
        /// Receives this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queue">The queue.</param>
        /// <returns>``0.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public T Receive<T>(string queue) where T : class, new()
        {
            return _queue.Receive(queue, (m) =>
                {
                    var message = ((BrokeredMessage) m).GetBody<string>();
                    return JsonConvert.DeserializeObject<T>(message);
                });
        }
    }
}
