using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using TFS.Models.FlightLogs;
using TFS.Models.Validation;
using TFS.Models;

namespace TFS.Web.ViewModels
{
    public class FlightLogViewModel : BaseValidatableEntity
    {
        public int FlightLogId { get; set; }
        [Required]
        public DateTime FlightLogDate { get; set; }
        [Required]
        public string AircraftMDS { get; set; } // "Mission-Design Series"
        [Required]
        public string AircraftSerialNumber { get; set; } // "Serial No." or Tail Number
        [Required]
        public string Location { get; set; } // Todo Change to "Program Location"

        public bool SavedFlightLog { get; set; }

        public IList<Mission> Missions { get; set; }
        public IList<SquadronLog> SquadronLogs { get; set; }

        public override IEnumerable<ValidationError> GetCustomValidationErrors()
        {
            var errors = new List<ValidationError>();
            if (FlightLogDate == DateTime.MinValue)
                errors.Add(new ValidationError("FlightLogDate", "Must supply a date", FlightLogDate));
            return errors;
        }

        public static FlightLogViewModel CreateFromFlightLog(FlightLog flightLog)
        {
            return new FlightLogViewModel
            {
                FlightLogId = flightLog.Id.Value,
                FlightLogDate = flightLog.LogDate,
                AircraftMDS = flightLog.AircraftMDS,
                AircraftSerialNumber = flightLog.AircraftSerialNumber,
                Location = flightLog.Location,
                Missions = flightLog.Missions.ToList(),
                SquadronLogs = flightLog.SquadronLogs.ToList(),
            };
        }
    }
}
