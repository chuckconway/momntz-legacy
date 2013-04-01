using FluentNHibernate.Mapping;
using Momntz.Model;

namespace Momntz.Data.Mappings
{
    public class TagMomentoMapping : ClassMap<TagMomento>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TagMomentoMapping"/> class.
        /// </summary>
        public TagMomentoMapping()
        {
            Id(t => t.Id,"Id");
            References(t => t.Tag, "TagId").Not.LazyLoad();
            References(t => t.Momento,"MomentoId").Not.LazyLoad();
        }
    }
}
