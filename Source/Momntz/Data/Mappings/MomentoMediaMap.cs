using FluentNHibernate.Mapping;
using Momntz.Data.Schema;

namespace Momntz.Data.Mappings
{
    public class MomentoMediaMap : ClassMap<MomentoMedia>
    {
        public MomentoMediaMap()
        {
            Id(x => x.Id);

            References(m => m.Momento, "MomentoId").Not.LazyLoad();

            Map(x => x.Filename)
                .Not.Nullable()
                .Length(50);

            Map(x => x.Extension)
                .Not.Nullable()
                .Length(20);

            Map(x => x.Url)
                .Not.Nullable()
                .Length(500);

            Map(f => f.CreateDate)
                .Not.Nullable();

            Map(x => x.Size)
                .Not.Nullable();

            Map(x => x.Username)
                .Not.Nullable()
                .Length(100);

            Map(x => x.MediaType)
                .Not.Nullable()
                .Length(50);

            Table("MomentoMedia");
        }
    }
}
