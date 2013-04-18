using FluentNHibernate.Mapping;
using Momntz.Model.QueueData;

namespace Momntz.Data.Mappings
{
    public class QueueMap : ClassMap<Queue>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QueueMap"/> class.
        /// </summary>
        public QueueMap()
        {
            Id(i=>i.Id);

            Map(x => x.Implementation);

            Map(x => x.MessageStatus);

            Map(x => x.Error);

            Map(x => x.Payload);
        }
    }
}
