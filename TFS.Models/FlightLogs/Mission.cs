using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Centro.DomainModel;
using Centro.Validation;

namespace TFS.Models.FlightLogs
{
    public class Mission : BaseEntity
    {
        public virtual int? Id { get; set; }

        public virtual MissionLog MissionLog { get; set; }

        [DomainSignature, Required, StringLength(50)]
        public virtual string Name { get; set; }
        [DomainSignature, StringLength(100)]
        public virtual string AdditionalInfo { get; set; }

        [DomainSignature, Required, StringLength(4)]
        public virtual string FromICAO { get; set; }
        [DomainSignature, Required, StringLength(4)]
        public virtual string ToICAO { get; set; }

        [DomainSignature, Required, StringLength(4), RegularExpression(@"[0-2][0-9][0-5][0-9]", ErrorMessage = "Must be in the format HHMM")]
        public virtual string TakeOffTime { get; set; }
        [DomainSignature, Required, StringLength(4), RegularExpression(@"[0-2][0-9][0-5][0-9]", ErrorMessage = "Must be in the format HHMM")]
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

        [DomainSignature, Required]
        public virtual int TouchAndGos { get; set; }
        [DomainSignature, Required]
        public virtual int FullStops { get; set; }
        [DomainSignature, Required]
        public virtual int Sorties { get; set; }
        [DomainSignature, Required]
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
