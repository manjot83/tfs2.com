using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.Models.Programs;
using FluentNHibernate.Mapping;

namespace TFS.Models.Data.Programs
{
    public class PositionMap : ClassMap<Position>
    {
        public PositionMap()
        {
            Table("Positions");

            Id(x => x.Id)
                .GeneratedBy.Identity()
                .Not.Nullable();

            Map(x => x.Title)
                .Length(50)
                .Not.Nullable();
        }
    }
}
