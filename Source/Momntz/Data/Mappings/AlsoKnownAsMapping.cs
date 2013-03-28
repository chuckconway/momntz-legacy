using FluentNHibernate.Mapping;
using Momntz.Model;

namespace Momntz.Data.Mappings
{
    public class AlsoKnownAsMapping : ClassMap<AlsoKnownAs>
    {
        public AlsoKnownAsMapping()
        {
            Id(x => x.Id);
            Map(a => a.FirstName)
                .Nullable()
                .Length(50);

            Map(x=>x.FullName)
                .Not.Nullable()
               .Length(100);

            Map(x => x.IsDefault)
                .Not.Nullable();

            Map(x => x.LastName)
                .Nullable()
                .Length(50);

            Map(x => x.Username)
            .Not.Nullable()
            .Length(100);

            Map(x => x.Suffix)
            .Nullable()
            .Length(10);

        }
    }
}
