using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TFS.Models;
using TFS.Models.Validation;

namespace TFS.Models.FlightLogs
{
    public class Mission : BaseDomainObject
    {
        public virtual int? Id { get; set; }

        public virtual FlightLog FlightLog { get; set; }

        [DomainEquality, Required, StringLength(50)]
        public virtual string Name { get; set; }
        [DomainEquality, StringLength(100)]
        public virtual string AdditionalInfo { get; set; }

        [DomainEquality, Required, StringLength(4)]
        public virtual string FromICAO { get; set; }
        [DomainEquality, Required, StringLength(4)]
        public virtual string ToICAO { get; set; }

        [DomainEquality, Required, StringLength(4), MilitaryTimeFormat, RegularExpression(@"[0-2][0-9][0-5][0-9]", ErrorMessage = "Must be in the format HHMM")]
        public virtual string TakeOffTime { get; set; }
        [DomainEquality, Required, StringLength(4), MilitaryTimeFormat, RegularExpression(@"[0-2][0-9][0-5][0-9]", ErrorMessage = "Must be in the format HHMM")]
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
            return ComputeFlightTime(FlightLog.LogDate, TakeOffTime, LandingTime);
        }

        [DomainEquality, Required]
        public virtual int TouchAndGos { get; set; }
        [DomainEquality, Required]
        public virtual int FullStops { get; set; }
        [DomainEquality, Required]
        public virtual int Sorties { get; set; }
        [DomainEquality, Required]
        public virtual int Totals { get; set; }

        public virtual void MarkedUpdated()
        {
            FlightLog.MarkedUpdated();
        }
    }
}
