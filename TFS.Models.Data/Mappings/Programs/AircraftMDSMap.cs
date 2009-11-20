using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.Models.Programs;
using FluentNHibernate.Mapping;

namespace TFS.Models.Data.Mappings.Programs
{
    public class AircraftMDSMap : ClassMap<AircraftMDS>
    {
        public AircraftMDSMap()
        {
            Table("AircraftMDS");

            Id(x => x.Id)
                .GeneratedBy.Identity()
                .Not.Nullable();

            Map(x => x.Name)
                .Length(50)
                .Not.Nullable();
        }
    }
}
