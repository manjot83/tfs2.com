using System.ComponentModel.DataAnnotations;
using Centro.DomainModel;
using TFS.Models.PersonnelRecords;
using System.Runtime.Serialization;

namespace TFS.Models.FlightLogs
{
    [DataContract(Name = "Member", Namespace = "")]
    public class SquadronLog : BaseEntity
    {
        public SquadronLog()
        {
            // Some domain specific defaults
            FlyingUnit = "TFS";
        }

        [IgnoreDataMember]
        public virtual int? Id { get; set; }

        [IgnoreDataMember]
        public virtual MissionLog MissionLog { get; set; }

        [IgnoreDataMember]
        public virtual Person Person { get; set; }
        [DomainSignature, Required]
        [DataMember(Name = "DutyCode")]
        public virtual DutyCode DutyCode { get; set; }

        [DomainSignature, Required]
        [DataMember(Name = "Primary")]
        public virtual double PrimaryHours { get; set; }
        [DomainSignature, Required]
        [DataMember(Name = "Secondary")]
        public virtual double SecondaryHours { get; set; }
        [DomainSignature, Required]
        [DataMember(Name = "Instructor")]
        public virtual double InstructorHours { get; set; }
        [DomainSignature, Required]
        [DataMember(Name = "Evaluator")]
        public virtual double EvaluatorHours { get; set; }
        [DomainSignature, Required]
        [DataMember(Name = "Other")]
        public virtual double OtherHours { get; set; }
        [DomainSignature, Required]
        [DataMember(Name = "Sorties")]
        public virtual int Sorties { get; set; }
        [DomainSignature, Required]
        [DataMember(Name = "PrimaryNight")]
        public virtual double PrimaryNightHours { get; set; }
        [DomainSignature, Required]
        [DataMember(Name = "PrimaryInstrument")]
        public virtual double PrimaryInstrumentHours { get; set; }
        [DomainSignature, Required]
        [DataMember(Name = "SimulatedInstrument")]
        public virtual double SimulatedInstrumentHours { get; set; }

        public virtual double CalculateTotalHours()
        {
            return PrimaryHours +
                   SecondaryHours +
                   InstructorHours +
                   EvaluatorHours +
                   OtherHours;
        }

        [DataMember(Name = "Total")]
        private double TotalHours
        {
            get { return CalculateTotalHours(); }
            set { /* noop required for serialization */ }
        }

        [DataMember(Name = "FlyingUnit")]
        public virtual string FlyingUnit { get; set; }

        [DataMember(Name = "SSN")]
        private string SSN
        {
            get { return Person.SocialSecurityLastFour; }
            set { /* noop required for serialization */ }
        }

        [DataMember(Name = "Name")]
        private string Name
        {
            get { return Person.FileByName(); }
            set { /* noop required for serialization */ }
        }

        public virtual void MarkedUpdated()
        {
            MissionLog.MarkedUpdated();
        }
    }
}
