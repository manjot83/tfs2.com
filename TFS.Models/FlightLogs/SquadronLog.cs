using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Centro.DomainModel;
using TFS.Models.PersonnelRecords;

namespace TFS.Models.FlightLogs
{
    public class SquadronLog : BaseEntity
    {
        public virtual int? Id { get; set; }

        public virtual MissionSummary MissionSummary { get; set; }

        public virtual Person Person { get; set; }
        public virtual DutyCode DutyCode { get; set; }

        public virtual double PrimaryHours { get; set; }
        public virtual double SecondaryHours { get; set; }
        public virtual double InstructorHours { get; set; }
        public virtual double EvaluatorHours { get; set; }
        public virtual double OtherHours { get; set; }
        public virtual int Sorties { get; set; }
        public virtual double PrimaryNightHours { get; set; }
        public virtual double PrimaryInstrumentHours { get; set; }
        public virtual double SimulatedInstrumentHours { get; set; }        
    }
}
