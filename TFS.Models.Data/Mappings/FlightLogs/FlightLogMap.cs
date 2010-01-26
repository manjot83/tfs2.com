using FluentNHibernate.Mapping;
using TFS.Models.Data.UserTypes;
using TFS.Models.FlightLogs;

namespace TFS.Models.Data.Mappings.FlightLogs
{
    public class FlightLogMap : ClassMap<FlightLog>
    {
        public FlightLogMap()
        {
            Table("FlightLogs");

            Id(x => x.Id)
                .GeneratedBy.GuidComb()
                .Not.Nullable();

            Map(x => x.LogDate)
                .CustomType<UtcDateTimeUserType>()
                .Not.Nullable();
            Map(x => x.LastModifiedDate)
                .CustomType<UtcDateTimeUserType>()
                .Not.Nullable();
            Map(x => x.AircraftMDS)
                .Length(50)
                .Not.Nullable();
            Map(x => x.AircraftSerialNumber)
                .Length(50)
                .Not.Nullable();

            References(x => x.Location)
                .ForeignKey("FK_FlightLogs_ProgramLocations")
                .Column("ProgramLocationId")
                .Cascade.None()
                .Not.Nullable();

            HasMany(x => x.Missions)
                .KeyColumn("FlightLogId")
                .Inverse()
                .Cascade.All();
            HasMany(x => x.SquadronLogs)
                .KeyColumn("FlightLogId")
                .Inverse()
                .Cascade.All();
        }
    }
}
