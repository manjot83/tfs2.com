using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Centro.DomainModel;
using System.Xml.Serialization;
using System.Linq;
using TFS.Models.Reports;
using System.Runtime.Serialization;

namespace TFS.Models.FlightLogs
{
    [Serializable]
    [DataContract(Name = "FlightTimeSummary", Namespace="")]
    public class MissionLog : BaseEntity, IReportSerializable
    {
        public MissionLog()
        {
            this.Missions = new List<Mission>();
            this.SquadronLogs = new List<SquadronLog>();

            // Some domain specific defaults
            OperatingUnit = "Tactical Flight Services";
        }

        string IReportSerializable.StylesheetResourceName
        {
            get { return "TFS.Models.Reports.FlightTimeSummary.xsl"; }
        }

        [IgnoreDataMember]
        public virtual int? Id { get; set; }

        [DomainSignature, Required]
        [DataMember(Name = "Date")]
        public virtual DateTime LogDate { get; set; }
        [DomainSignature, Required]
        [IgnoreDataMember]
        public virtual DateTime LastModifiedDate { get; set; }

        [DomainSignature, Required]
        [DataMember(Name = "MDS")]
        public virtual string AircraftMDS { get; set; } // "Mission Design Series"
        [DomainSignature, Required]
        [DataMember(Name = "SerialNumber")]
        public virtual string AircraftSerialNumber { get; set; } // "Serial No." or Tail Number

        [DomainSignature, Required]
        [DataMember(Name = "Location")]
        public virtual string Location { get; set; } // Todo Change to "Program Location"

        [DataMember(Name = "Missions")]
        public virtual IList<Mission> Missions { get; set; }
        [DataMember(Name = "Squadron")]
        public virtual IList<SquadronLog> SquadronLogs { get; set; }

        [DataMember(Name = "OperatingUnit")]
        public virtual string OperatingUnit { get; set; }

        [DataMember(Name = "PilotReview")]
        public virtual string PilotReview { get; set; }

        [DataMember(Name = "OpsReview")]
        public virtual string OpsReview { get; set; }

        [DataMember(Name = "GeneratedDate")]
        private DateTime GeneratedDate
        {
            get { return DateTime.UtcNow; }
            set { /* noop required for serialization */ }
        }

        [DataMember(Name = "TotalCalculatedFlightTime")]
        private double TotalCalculatedFlightTime
        {
            get { return Missions.Sum(x => x.ComputeFlightTime().Hours); }
            set { /* noop required for serialization */ }
        }

        [DataMember(Name = "TotalTouchAndGos")]
        private double TotalTouchAndGos
        {
            get { return Missions.Sum(x => x.TouchAndGos); }
            set { /* noop required for serialization */ }
        }

        [DataMember(Name = "TotalFullStops")]
        private double TotalFullStops
        {
            get { return Missions.Sum(x => x.FullStops); }
            set { /* noop required for serialization */ }
        }

        [DataMember(Name = "TotalTotals")]
        private double TotalTotals
        {
            get { return Missions.Sum(x => x.Totals); }
            set { /* noop required for serialization */ }
        }

        [DataMember(Name = "TotalSorties")]
        private double TotalSorties
        {
            get { return Missions.Sum(x => x.Sorties); }
            set { /* noop required for serialization */ }
        }

        public virtual void MarkedUpdated()
        {
            LastModifiedDate = DateTime.Now.ToUniversalTime();
        }
    }
}
