using FluentNHibernate.Mapping;
using Momntz.Model;

namespace Momntz.Data.Mappings
{
    public class TagMapping: ClassMap<Tag>
   {
        public TagMapping()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Story);
            Map(x => x.Kind);
            Map(x => x.Username);
        }
    }
}
