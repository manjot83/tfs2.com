using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using TFS.Models.Validation;
using TFS.Models;

namespace TFS.Web.ViewModels.FlightLogs
{
    public class FlightLogViewModel : BaseValidatableEntity
    {
        public int? Id { get; set; }
        [Required]
        public DateTime LogDate { get; set; }
        [Required]
        public string AircraftMDS { get; set; } // "Mission-Design Series"
        [Required]
        public string AircraftSerialNumber { get; set; } // "Serial No." or Tail Number
        [Required]
        public string Location { get; set; } // Todo Change to "Program Location"

        public IEnumerable<MissionViewModel> Missions { get; set; }
        public IEnumerable<SquadronLogViewModel> SquadronLogs { get; set; }

        public bool PreviouslySaved { get; set; }

        public override IEnumerable<ValidationError> GetCustomValidationErrors()
        {
            var errors = new List<ValidationError>();
            if (LogDate == DateTime.MinValue)
                errors.Add(new ValidationError("LogDate", "Flight Log Date Required", LogDate));
            return errors;
        }
    }
}
