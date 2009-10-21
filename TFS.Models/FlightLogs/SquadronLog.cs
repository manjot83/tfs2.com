using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Centro.DomainModel;
using TFS.Models.PersonnelRecords;
using System.ComponentModel.DataAnnotations;

namespace TFS.Models.FlightLogs
{
    public class SquadronLog : BaseEntity
    {
        public virtual int? Id { get; set; }

        public virtual MissionLog MissionLog { get; set; }

        [DomainSignature, Required]
        public virtual Person Person { get; set; }
        [DomainSignature, Required]
        public virtual DutyCode DutyCode { get; set; }

        [DomainSignature, Required]
        public virtual double PrimaryHours { get; set; }
        [DomainSignature, Required]
        public virtual double SecondaryHours { get; set; }
        [DomainSignature, Required]
        public virtual double InstructorHours { get; set; }
        [DomainSignature, Required]
        public virtual double EvaluatorHours { get; set; }
        [DomainSignature, Required]
        public virtual double OtherHours { get; set; }
        [DomainSignature, Required]
        public virtual int Sorties { get; set; }
        [DomainSignature, Required]
        public virtual double PrimaryNightHours { get; set; }
        [DomainSignature, Required]
        public virtual double PrimaryInstrumentHours { get; set; }
        [DomainSignature, Required]
        public virtual double SimulatedInstrumentHours { get; set; }        
    }
}
