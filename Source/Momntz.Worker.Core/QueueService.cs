using System;
using System.Collections.Generic;
using System.Linq;
using Hypersonic;
using Momntz.Infrastructure;
using Momntz.Worker.Core.Implementations;
using StructureMap;

namespace Momntz.Worker.Core
{
    public class QueueService
    {
        private IList<IMessageProcessor> _processors; 

        public void Process()
        {
            IInjection injection = new StructureMapInjection();
            injection.AddManifest(new WorkerRegistry());
            ISession session = injection.Get<ISession>();

            var list = RetreiveQueuedItems(session);
            ProcessQueuedItems(list, injection);
        }

        private IEnumerable<Queue> RetreiveQueuedItems(ISession session)
        {
            session.Database.ConnectionStringName = "queue";
            var list = session.Query<Queue>()
                .Where("MessageStatus = 'Queued'")
                .List();

            return list;
        }

        private void ProcessQueuedItems(IEnumerable<Queue> items, IInjection injection)
        {
            var messages = _processors ?? GetMessageProcessors(injection);

            foreach (var queue in items)
            {
                foreach (var message in messages.Where(message => message.MessageType == queue.Implementation))
                {
                    message.Process(queue.Payload);
                    break;
                }
            }
        }

        private List<IMessageProcessor> GetMessageProcessors(IInjection injection)
        {
            var types = GetType().Assembly.GetTypes();

            var messages = (from type in types 
                            where typeof (IMessageProcessor).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract
                            select (IMessageProcessor)injection.Get(type)).ToList();

            _processors = messages;
            return messages;
        }
    }
}
