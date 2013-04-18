using FluentNHibernate.Mapping;
using Momntz.Model.QueueData;

namespace Momntz.Data.Mappings
{
    public class MediaMap : ClassMap<Media>
    {
        public MediaMap()
        {
            Id(x => x.Id);

            Map(x => x.Bytes)
                .Not.Nullable();

            Map(x => x.CreateDate)
                .Not.Nullable();

            Map(x => x.Extension)
                .Not.Nullable()
                .Length(10);

            Map(x => x.Filename)
                .Not.Nullable()
                .Length(250);

            Map(x => x.MediaType)
                .Not.Nullable()
                .Length(50);

            Map(x => x.Size)
                .Not.Nullable();

            Map(x => x.Username)
                .Not.Nullable()
                .Length(50);

            Table("Media");
        }
    }
}
