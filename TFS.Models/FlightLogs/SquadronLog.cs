using System.ComponentModel.DataAnnotations;
using TFS.Models;
using TFS.Models.PersonnelRecords;

namespace TFS.Models.FlightLogs
{
    public class SquadronLog : BaseDomainEntity
    {
        public SquadronLog()
        {
            // Some domain specific defaults
            FlyingUnit = "TFS";
        }

        public virtual int? Id { get; set; }

        public virtual MissionLog MissionLog { get; set; }

        public virtual string FlyingUnit { get; set; }

        public virtual Person Person { get; set; }
        [DomainEquality, Required]
        public virtual DutyCode DutyCode { get; set; }

        [DomainEquality, Required]
        public virtual double PrimaryHours { get; set; }
        [DomainEquality, Required]
        public virtual double SecondaryHours { get; set; }
        [DomainEquality, Required]
        public virtual double InstructorHours { get; set; }
        [DomainEquality, Required]
        public virtual double EvaluatorHours { get; set; }
        [DomainEquality, Required]
        public virtual double OtherHours { get; set; }
        [DomainEquality, Required]
        public virtual int Sorties { get; set; }
        [DomainEquality, Required]
        public virtual double PrimaryNightHours { get; set; }
        [DomainEquality, Required]
        public virtual double PrimaryInstrumentHours { get; set; }
        [DomainEquality, Required]
        public virtual double SimulatedInstrumentHours { get; set; }

        public virtual double CalculateTotalHours()
        {
            return PrimaryHours +
                   SecondaryHours +
                   InstructorHours +
                   EvaluatorHours +
                   OtherHours;
        }

        public virtual void MarkedUpdated()
        {
            MissionLog.MarkedUpdated();
        }
    }
}
