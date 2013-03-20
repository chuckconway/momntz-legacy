using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Momntz.Model;

namespace Momntz.Data.Mappings
{
    public class ExifMap : ClassMap<Exif>
    {
        public ExifMap()
        {
            Id(e => e.Id);

            Map(e => e.Key,"[Key]");

            Map(e => e.Type);

            Map(e => e.Value);

            References(m => m.Momento, "MomentoId");
        }
    }
}
