using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.Models.Programs;
using FluentNHibernate.Mapping;

namespace TFS.Models.Data.Mappings.Programs
{
    public class FlightProgramMap : ClassMap<FlightProgram>
    {
        public FlightProgramMap()
        {
            Table("FlightPrograms");

            Id(x => x.Id)
                .GeneratedBy.Identity()
                .Not.Nullable();

            Map(x => x.Name)
                .Length(50)
                .Not.Nullable();
            Map(x => x.AccountName)
                .Length(50)
                .Not.Nullable();
            Map(x => x.Active)
                .Not.Nullable();

            HasMany(x => x.Locations)
                .KeyColumn("FlightProgramId")
                .Inverse()
                .Cascade.SaveUpdate();
        }
    }
}
