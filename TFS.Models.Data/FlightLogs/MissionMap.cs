using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.Models.FlightLogs;
using FluentNHibernate.Mapping;

namespace TFS.Models.Data.FlightLogs
{
    public class MissionMap : ClassMap<Mission>
    {
        public MissionMap()
        {
            Table("Missions");

            Id(x => x.Id)
                .GeneratedBy.Identity()
                .Not.Nullable();

            References(x => x.MissionLog)
                .ForeignKey("FK_Missions_MissionLogs")
                .Column("MissionLogId")
                .Cascade.SaveUpdate()                
                .Not.Nullable();

            Map(x => x.Name)
                .Length(50)
                .Not.Nullable();
            Map(x => x.AdditionalInfo)
                .Length(100)
                .Not.Nullable();
            Map(x => x.FromICAO)
                .Length(4)
                .Not.Nullable();
            Map(x => x.ToICAO)
                .Length(4)
                .Not.Nullable();
            Map(x => x.TakeOffTime)
                .Not.Nullable();
            Map(x => x.LandTime)
                .Not.Nullable();
            Map(x => x.TouchAndGos)
                .Not.Nullable();
            Map(x => x.FullStops)
                .Not.Nullable();
            Map(x => x.Sorties)
                .Not.Nullable();
            Map(x => x.Totals)
                .Not.Nullable();
        }
    }
}
