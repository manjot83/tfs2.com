using System;
using System.ComponentModel.DataAnnotations;
using Centro.DomainModel;

namespace TFS.Models.FlightLogs
{
    public class Mission : BaseEntity
    {
        public virtual int? Id { get; set; }

        public virtual MissionLog MissionLog { get; set; }

        [DomainSignature, Required, StringLength(50)]
        public virtual string Name { get; set; }
        [DomainSignature, Required, StringLength(100)]
        public virtual string AdditionalInfo { get; set; }

        [DomainSignature, Required, StringLength(4)]
        public virtual string FromICAO { get; set; }
        [DomainSignature, Required, StringLength(4)]
        public virtual string ToICAO { get; set; }

        [DomainSignature, Required, StringLength(4), RegularExpression(@"\d\d\d\d", ErrorMessage = "Must contain 4 numbers.")]
        public virtual string TakeOffTime { get; set; }
        [DomainSignature, Required, StringLength(4), RegularExpression(@"\d\d\d\d", ErrorMessage = "Must contain 4 numbers.")]
        public virtual string LandingTime { get; set; }

        public virtual TimeSpan ComputeFlightTime()
        {
            var logDate = MissionLog.LogDate;
            var takeOffTime = new DateTime(logDate.Year, logDate.Month, logDate.Day, int.Parse(TakeOffTime.Substring(0, 2)), int.Parse(TakeOffTime.Substring(2, 2)), 0);
            var landingTime = new DateTime(logDate.Year, logDate.Month, logDate.Day, int.Parse(LandingTime.Substring(0, 2)), int.Parse(LandingTime.Substring(2, 2)), 0);
            if (landingTime <= takeOffTime)
                landingTime.AddDays(1);
            return landingTime.Subtract(takeOffTime);
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
    }
}
