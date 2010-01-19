using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.Models.FlightPrograms;
using FluentNHibernate.Mapping;

namespace TFS.Models.Data.Mappings.FlightPrograms
{
    public class PositionMap : ClassMap<Position>
    {
        public PositionMap()
        {
            Table("Positions");

            Id(x => x.Id)
                .GeneratedBy.GuidComb()
                .Not.Nullable();

            Map(x => x.Title)
                .Length(50)
                .Unique()
                .Not.Nullable();
        }
    }
}
