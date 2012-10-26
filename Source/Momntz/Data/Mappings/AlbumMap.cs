using FluentNHibernate.Mapping;
using Momntz.Data.Projections.Api;

namespace Momntz.Data.Mappings
{
   public class AlbumMap : ClassMap<Album>
    {
       public AlbumMap()
       {
           Id(a => a.Id);
           Map(x => x.MomentoId)
               .Not.Nullable();

           Map(x => x.Name)
               .Not.Nullable()
               .Length(100);

           Map(x => x.Story)
               .Nullable()
               .Length(4000);

           Map(x => x.TagId);

           Table("TagAlbumView");
       }
    }
}
