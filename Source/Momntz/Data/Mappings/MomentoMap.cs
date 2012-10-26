using FluentNHibernate.Mapping;
using Momntz.Model;

namespace Momntz.Data.Mappings
{
    public class MomentoMap : ClassMap<Momento>
    {
        public MomentoMap()
        {
            Id(x => x.Id);
            Map(x => x.InternalId)
                .Not.Nullable();

            Map(x => x.Username)
                .Not.Nullable()
                .Length(100);

            Map(x => x.UploadedBy)
                .Not.Nullable()
                .Length(100);

            Map(x => x.Visibility)
                .Nullable()
                .Length(20);

            Map(x => x.Story)
                .Nullable();

            Map(x => x.Title)
                .Nullable()
                .Length(250);

            Map(x => x.Day)
                .Nullable();
            
            Map(x => x.Month)
                .Nullable();

            Map(x => x.Year)
                .Nullable();

            Map(x => x.Location)
                .Nullable()
                .Length(250);

            Map(x => x.Latitude)
                .Nullable();

            Map(x => x.Longitude)
                .Nullable();

            HasMany(x => x.Media);

            Table("Momento");
        }
    }
}
