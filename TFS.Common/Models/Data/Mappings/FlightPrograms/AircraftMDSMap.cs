using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.Models.FlightPrograms;
using FluentNHibernate.Mapping;

namespace TFS.Models.Data.Mappings.FlightPrograms
{
    public class AircraftMDSMap : ClassMap<AircraftMDS>
    {
        public AircraftMDSMap()
        {
            Table("AircraftMDS");

            Id(x => x.Id)
                .GeneratedBy.GuidComb()
                .Not.Nullable();

            Map(x => x.Name)
                .Length(50)
                .Not.Nullable();

            Map(x => x.Active)
               .Not.Nullable();
        }
    }
}
