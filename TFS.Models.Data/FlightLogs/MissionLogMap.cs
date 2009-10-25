using FluentNHibernate.Mapping;
using TFS.Models.Data.UserTypes;
using TFS.Models.FlightLogs;

namespace TFS.Models.Data.FlightLogs
{
    public class MissionLogMap : ClassMap<MissionLog>
    {
        public MissionLogMap()
        {
            Table("MissionLogs");

            Id(x => x.Id)
                .GeneratedBy.Identity()
                .Not.Nullable();

            HasMany(x => x.Missions)
                .KeyColumn("MissionLogId")
                .Inverse();
            HasMany(x => x.SquadronLogs)
                .KeyColumn("MissionLogId")
                .Inverse();

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
