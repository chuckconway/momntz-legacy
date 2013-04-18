using FluentNHibernate.Mapping;
using Momntz.Model;


namespace Momntz.Data.Mappings
{
   public class AlbumMap : ClassMap<Album>
    {
       public AlbumMap()
       {
           Id(a => a.Id);
           Map(x => x.Username)
               .Not.Nullable();

           Map(x => x.CreateDate)
            .Nullable();

           Map(x => x.Name)
               .Not.Nullable()
               .Length(100);

           Map(x => x.Story)
               .Nullable()
               .Length(4000);

          HasManyToMany(m => m.Momentos)
                .Table("AlbumMomento")
                .ParentKeyColumn("AlbumId")
                .ChildKeyColumn("MomentoId");

           Table("Album");
       }
    }
}
