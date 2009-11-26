using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using TFS.Models.Validation;
using TFS.Models;

namespace TFS.Web.ViewModels.FlightLogs
{
    public class MissionViewModel : BaseValidatableEntity
    {
        public int? Id { get; set; }
        public int? FlightLogId { get; set; }
                
        [Required, StringLength(50)]
        public string Name { get; set; }
        [StringLength(100)]
        public string AdditionalInfo { get; set; }

        [Required, StringLength(4)]
        public string FromICAO { get; set; }
        [Required, StringLength(4)]
        public string ToICAO { get; set; }

        [Required, StringLength(4), RegularExpression(@"[0-2][0-9][0-5][0-9]", ErrorMessage = "Must be in the format HHMM")]
        public string TakeOffTime { get; set; }
        [Required, StringLength(4), RegularExpression(@"[0-2][0-9][0-5][0-9]", ErrorMessage = "Must be in the format HHMM")]
        public string LandingTime { get; set; }

        public double TotalFlightTime { get; set; }

        [Required]
        public int TouchAndGos { get; set; }
        [Required]
        public int FullStops { get; set; }
        [Required]
        public int Sorties { get; set; }
        [Required]
        public int Totals { get; set; }

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
