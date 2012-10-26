using FluentNHibernate.Mapping;
using Momntz.Data.Projections.Api;

namespace Momntz.Data.Mappings
{
    public class PersonMap: ClassMap<Person>
    {
        public PersonMap()
        {
            Id(p => p.Id);
            Map(x => x.Name);
            Map(x => x.Username);
            References(x => x.Momento);

            Table("TagPersonView");
        }
    }
}
