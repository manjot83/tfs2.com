using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using TFS.Models.Validation;
using TFS.Models;

namespace TFS.Web.ViewModels.FlightLogs
{
    public class MissionViewModel
    {
        public Guid? Id { get; set; }
        public Guid? FlightLogId { get; set; }
                
        [Required, StringLength(50)]
        public string Name { get; set; }
        [StringLength(100)]
        public string AdditionalInfo { get; set; }

        [Required, StringLength(4)]
        public string FromICAO { get; set; }
        [Required, StringLength(4)]
        public string ToICAO { get; set; }

        [Required, StringLength(4), MilitaryTimeFormat, RegularExpression(@"[0-2][0-9][0-5][0-9]", ErrorMessage = "Must be in the format HHMM")]
        public string TakeOffTime { get; set; }
        [Required, StringLength(4), MilitaryTimeFormat, RegularExpression(@"[0-2][0-9][0-5][0-9]", ErrorMessage = "Must be in the format HHMM")]
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
    }
}
