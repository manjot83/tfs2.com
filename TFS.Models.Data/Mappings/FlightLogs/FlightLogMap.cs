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
                .GeneratedBy.Identity()
                .Not.Nullable();

            HasMany(x => x.Missions)
                .KeyColumn("FlightLogId")
                .Inverse()
                .Cascade.SaveUpdate();
            HasMany(x => x.SquadronLogs)
                .KeyColumn("FlightLogId")
                .Inverse()
                .Cascade.SaveUpdate();

            Map(x => x.LogDate)
                .CustomType<UtcDateTimeUserType>()
                .Not.Nullable();
            Map(x => x.LastModifiedDate)
                .CustomType<UtcDateTimeUserType>()
                .Not.Nullable();
            Map(x => x.Location)
                .Length(100)
                .Not.Nullable();
            Map(x => x.AircraftMDS)
                .Length(50)
                .Not.Nullable();
            Map(x => x.AircraftSerialNumber)
                .Length(50)
                .Not.Nullable();
        }
    }
}
