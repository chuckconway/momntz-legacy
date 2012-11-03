using FluentNHibernate.Mapping;
using Momntz.Data.Projections.Api;

namespace Momntz.Data.Mappings
{
    public class MomentoDetailMap : ClassMap<MomentoDetail>
    {
        public MomentoDetailMap()
        {
            Id(x => x.Id);
            Map(x => x.Added);
            Map(x => x.AddedUsername);
            Map(x => x.Day);
            Map(x => x.DisplayName);
            Map(x => x.Location);
            Map(x => x.Month);
            Map(x => x.Year);
            Map(x => x.Title);
            Map(x => x.Story);
            Map(x => x.Username);
            HasMany(p => p.People)
                .Fetch.Subselect()
                .Table("TagPersonView")
                .KeyColumn("MomentoId")
                .Not.LazyLoad();

            HasMany(a => a.Albums)
                .Fetch.Subselect()
                .Table("TagAlbumView")
                .KeyColumn("MomentoId")
                .Not.LazyLoad();

        }
    }
}
