using System;
using System.ComponentModel.DataAnnotations;
using Centro.DomainModel;
using Centro.Validation;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace TFS.Models.FlightLogs
{
    [Serializable]
    [DataContract(Name = "Mission", Namespace="")]
    public class Mission : BaseEntity
    {
        [IgnoreDataMember]
        public virtual int? Id { get; set; }

        [IgnoreDataMember]
        public virtual MissionLog MissionLog { get; set; }

        [DomainSignature, Required, StringLength(50)]
        [DataMember(Name="Name")]
        public virtual string Name { get; set; }
        [DomainSignature, StringLength(100)]
        [DataMember(Name = "SpecialUse")]
        public virtual string AdditionalInfo { get; set; }

        [DomainSignature, Required, StringLength(4)]
        [DataMember(Name = "From")]
        public virtual string FromICAO { get; set; }
        [DomainSignature, Required, StringLength(4)]
        [DataMember(Name = "To")]
        public virtual string ToICAO { get; set; }

        [DomainSignature, Required, StringLength(4), RegularExpression(@"[0-2][0-9][0-5][0-9]", ErrorMessage = "Must be in the format HHMM")]
        [DataMember(Name = "TakeOff")]
        public virtual string TakeOffTime { get; set; }
        [DomainSignature, Required, StringLength(4), RegularExpression(@"[0-2][0-9][0-5][0-9]", ErrorMessage = "Must be in the format HHMM")]
        [DataMember(Name = "Landing")]
        public virtual string LandingTime { get; set; }

        public static TimeSpan ComputeFlightTime(DateTime logDate, string takeOffTime, string landingTime)
        {
            var takeOffDateTime = new DateTime(logDate.Year, logDate.Month, logDate.Day, int.Parse(takeOffTime.Substring(0, 2)), int.Parse(takeOffTime.Substring(2, 2)), 0);
            var landingDateTime = new DateTime(logDate.Year, logDate.Month, logDate.Day, int.Parse(landingTime.Substring(0, 2)), int.Parse(landingTime.Substring(2, 2)), 0);
            if (landingDateTime <= takeOffDateTime)
                landingDateTime = landingDateTime.AddDays(1);
            return landingDateTime.Subtract(takeOffDateTime);
        }

        public virtual TimeSpan ComputeFlightTime()
        {
            return ComputeFlightTime(MissionLog.LogDate, TakeOffTime, LandingTime);
        }

        [DataMember(Name = "FlightTime")]
        private double FlightTime
        {
            get { return ComputeFlightTime().Hours; }
            set { /* noop required for serialization */ }
        }

        [DomainSignature, Required]
        [DataMember(Name = "TouchAndGos")]
        public virtual int TouchAndGos { get; set; }
        [DomainSignature, Required]
        [DataMember(Name = "FullStops")]
        public virtual int FullStops { get; set; }
        [DomainSignature, Required]
        [DataMember(Name = "Sorties")]
        public virtual int Sorties { get; set; }
        [DomainSignature, Required]
        [DataMember(Name = "Totals")]
        public virtual int Totals { get; set; }

        public virtual void MarkedUpdated()
        {
            MissionLog.MarkedUpdated();
        }

        public override IEnumerable<ValidationError> GetCustomValidationErrors()
        {
            var errors = new List<ValidationError>();
            var takeOffTime = 0;
            if (!int.TryParse(TakeOffTime, out takeOffTime) || takeOffTime > 2359 || takeOffTime < 0)
                errors.Add(new ValidationError("TakeOffTime", "Must represent 24hr time in the format HHMM", TakeOffTime));
            var landingTime = 0;
            if (!int.TryParse(LandingTime, out landingTime) || landingTime > 2359 || landingTime < 0)
                errors.Add(new ValidationError("LandingTime", "Must represent 24hr time in the format HHMM", TakeOffTime));
            return errors;
        }
    }
}
