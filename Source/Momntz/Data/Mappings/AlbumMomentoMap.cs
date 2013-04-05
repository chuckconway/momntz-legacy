using FluentNHibernate.Mapping;
using Momntz.Model;

namespace Momntz.Data.Mappings
{
    public class AlbumMomentoMap:ClassMap<AlbumMomento>
    {
        public AlbumMomentoMap()
        {
            Id(x => x.Id);
            References(a => a.Momento)
                .ForeignKey("MomentoId")
                .Not.LazyLoad();

            References(a => a.Album)
            .ForeignKey("AlbumId")
            .Not.LazyLoad();

        }
    }
}
