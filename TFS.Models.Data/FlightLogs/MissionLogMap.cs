using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.Models.FlightLogs;
using FluentNHibernate.Mapping;

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

            Map(x => x.CreatedDate)
                .Not.Nullable();
            Map(x => x.LastModifiedDate)
                .Not.Nullable();
            Map(x => x.Location)
                .Length(100)
                .Not.Nullable();
            Map(x => x.AircraftModel)
                .Length(50)
                .Not.Nullable();
            Map(x => x.AircraftSerialNumber)
                .Length(50)
                .Not.Nullable();
        }
    }
}
