using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace TFS.Models.Data
{
    public class UserMapping : ClassMap<User>
    {
        public UserMapping()
        {
            Table("Users");

            Id(x => x.Id)
                .GeneratedBy.Identity()
                .Not.Nullable();

            HasOne(x => x.Person)
                .Cascade.All();

            Map(x => x.FirstName)
                .Length(100)
                .Not.Nullable();
            Map(x => x.LastName)
                .Length(100)
                .Not.Nullable();
            Map(x => x.DisplayName)
                .Length(150)
                .Not.Nullable();
            Map(x => x.Email)
                .Length(254)
                .Not.Nullable();
            Map(x => x.Username)
                .Length(100)
                .Not.Nullable();
            Map(x => x.Disabled)
                .Not.Nullable();
        }
    }
}
