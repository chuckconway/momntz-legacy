﻿using FluentNHibernate.Mapping;
using Momntz.Data.Schema;

namespace Momntz.Data.Mappings
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.Username);


            Map(x => x.Email)
                .Nullable()
                .Length(250);

            Map(x => x.FullName)
                .Nullable()
                .Length(250);

            Map(x => x.Password)
                .Nullable()
                .Length(250);

            Map(x => x.UserStatus)
                .Not.Nullable();

            Map(x => x.Username)
                .Not.Nullable()
                .Length(100);

            Table("UserAliasView");

        }
    }
}
