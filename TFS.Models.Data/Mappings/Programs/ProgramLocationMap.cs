using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.Models.Programs;
using FluentNHibernate.Mapping;

namespace TFS.Models.Data.Mappings.Programs
{
    public class ProgramLocationMap : ClassMap<ProgramLocation>
    {
        public ProgramLocationMap()
        {
            Table("ProgramLocations");

            Id(x => x.Id)
                .GeneratedBy.Identity()
                .Not.Nullable();

            Map(x => x.Name)
                .Length(100)
                .Not.Nullable();

            References(x => x.Program)
                .ForeignKey("FK_ProgramLocations_FlightPrograms")
                .Column("FlightProgramId")
                .Not.Nullable();
        }
    }
}
