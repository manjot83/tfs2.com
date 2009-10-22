using Centro.Data.UserTypes;
using FluentNHibernate.Mapping;
using TFS.Models.FlightLogs;

namespace TFS.Models.Data.FlightLogs
{
    public class SquadronLogMap : ClassMap<SquadronLog>
    {
        public SquadronLogMap()
        {
            Table("SquadronLogs");

            Id(x => x.Id)
                .GeneratedBy.Identity()
                .Not.Nullable();

            References(x => x.MissionLog)
                .ForeignKey("FK_SquadronLogs_MissionLogs")
                .Column("MissionLogId")
                .Cascade.SaveUpdate()
                .Not.Nullable();
            References(x => x.Person)
                .ForeignKey("FK_SquadronLogs_Persons")
                .Column("PersonId")
                .Not.Nullable();

            Map(x => x.DutyCode)
                .CustomType<EnumerationUserType<DutyCode>>()
                .Not.Nullable();
            Map(x => x.PrimaryHours)
                .Not.Nullable();
            Map(x => x.SecondaryHours)
                .Not.Nullable();
            Map(x => x.InstructorHours)
                .Not.Nullable();
            Map(x => x.EvaluatorHours)
                .Not.Nullable();
            Map(x => x.OtherHours)
                .Not.Nullable();
            Map(x => x.Sorties)
                .Not.Nullable();
            Map(x => x.PrimaryNightHours)
                .Not.Nullable();
            Map(x => x.PrimaryInstrumentHours)
                 .Not.Nullable();
            Map(x => x.SimulatedInstrumentHours)
                 .Not.Nullable();
        }
    }
}
