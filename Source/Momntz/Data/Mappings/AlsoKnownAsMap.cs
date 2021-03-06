﻿using FluentNHibernate.Mapping;
using Momntz.Data.Schema;

namespace Momntz.Data.Mappings
{
    public class AlsoKnownAsMap : ClassMap<AlsoKnownAs>
    {
        public AlsoKnownAsMap()
        {
            Id(x => x.Id);
            Map(a => a.FirstName)
                .Nullable()
                .Length(50);

            Map(x=>x.FullName)
                .Not.Nullable()
               .Length(100);

            Map(x => x.IsDefault)
                .Not.Nullable();

            Map(x => x.LastName)
                .Nullable()
                .Length(50);

            Map(x => x.Username)
            .Not.Nullable()
            .Length(100);

            Map(x => x.Suffix)
            .Nullable()
            .Length(10);

        }
    }
}
