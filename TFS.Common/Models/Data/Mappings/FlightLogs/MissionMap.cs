using FluentNHibernate.Mapping;
using TFS.Models.Data.UserTypes;
using TFS.Models.FlightLogs;

namespace TFS.Models.Data.Mappings.FlightLogs
{
    public class MissionMap : ClassMap<Mission>
    {
        public MissionMap()
        {
            Table("Missions");

            Id(x => x.Id)
                .GeneratedBy.GuidComb()
                .Not.Nullable();

            References(x => x.FlightLog)
                .ForeignKey("FK_Missions_FlightLogs")
                .Column("FlightLogId")
                .Cascade.SaveUpdate()
                .Not.Nullable();

            Map(x => x.Name)
                .Length(50)
                .Not.Nullable();
            Map(x => x.AdditionalInfo)
                .Length(100)
                .Nullable();
            Map(x => x.FromICAO)
                .Length(4)
                .Not.Nullable();
            Map(x => x.ToICAO)
                .Length(4)
                .Not.Nullable();
            Map(x => x.TakeOffTime)
                .Length(4)
                .Not.Nullable();
            Map(x => x.LandingTime)
                .Length(4)
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
