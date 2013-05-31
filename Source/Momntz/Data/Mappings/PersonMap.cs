using FluentNHibernate.Mapping;
using Momntz.Data.Schema;


namespace Momntz.Data.Mappings
{
    public class PersonMap: ClassMap<Person>
    {
        public PersonMap()
        {
            Id(p => p.Id);
            Map(x => x.Name);
            Map(x => x.Username);
            Map(x => x.Width);
            Map(x => x.XAxis);
            Map(x => x.YAxis);
            Map(x => x.CreatedBy);
            Map(x => x.Height);
            References(x => x.Momento, "MomentoId");

            Table("Person");
        }
    }
}
