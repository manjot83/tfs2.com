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
            Table("users");
            Id(x => x.Id)
                .GeneratedBy.Guid()
                .Not.Nullable();
        }
    }
}
