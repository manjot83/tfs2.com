using FluentNHibernate.Mapping;
using TFS.Models.FlightLogs;

namespace TFS.Models.Data.Mappings.FlightLogs
{
    public class SquadronLogMap : ClassMap<SquadronLog>
    {
        public SquadronLogMap()
        {
            Table("SquadronLogs");

            Id(x => x.Id)
                .GeneratedBy.GuidComb()
                .Not.Nullable();

            References(x => x.FlightLog)
                .ForeignKey("FK_SquadronLogs_FlightLogs")
                .Column("FlightLogId")
                .Cascade.SaveUpdate()
                .Not.Nullable();
            References(x => x.Person)
                .ForeignKey("FK_SquadronLogs_Persons")
                .Column("PersonId")
                .Not.Nullable();

            Map(x => x.DutyCode)
                .CustomType<DutyCode>()
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
