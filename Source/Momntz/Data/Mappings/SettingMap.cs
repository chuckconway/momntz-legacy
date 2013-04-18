using FluentNHibernate.Mapping;
using Momntz.Model.Configuration;

namespace Momntz.Data.Mappings
{
    public class SettingMap : ClassMap<Setting>
    {
        public SettingMap()
        {
            Id(x => x.Id);
            
            Map(x => x.Name)
                .Not.Nullable()
                .Length(50);

            Map(x=>x.Value)
                .Not.Nullable()
                .Length(500);

            Map(x => x.Environment)
                .Nullable()
                .Length(50);

            Table("Configuration");    
        }
    }
}
