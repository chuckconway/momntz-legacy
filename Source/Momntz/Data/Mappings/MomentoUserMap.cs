using FluentNHibernate.Mapping;
using Momntz.Data.Schema;

namespace Momntz.Data.Mappings
{
    public class MomentoUserMap : ClassMap<MomentoUser>
    {
        public MomentoUserMap()
        {
            Id(x => x.Id);
            References(m => m.Momento, "MomentoId");
            Map(x => x.Username);

        }
    }
}
