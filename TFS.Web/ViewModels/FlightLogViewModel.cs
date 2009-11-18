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
        public int MissionLogId { get; set; }
        [Required]
        public DateTime MissionLogDate { get; set; }
        [Required]
        public string AircraftMDS { get; set; } // "Mission-Design Series"
        [Required]
        public string AircraftSerialNumber { get; set; } // "Serial No." or Tail Number
        [Required]
        public string Location { get; set; } // Todo Change to "Program Location"

        public bool SavedMissionLog { get; set; }

        public IList<Mission> Missions { get; set; }
        public IList<SquadronLog> SquadronLogs { get; set; }

        public override IEnumerable<ValidationError> GetCustomValidationErrors()
        {
            var errors = new List<ValidationError>();
            if (MissionLogDate == DateTime.MinValue)
                errors.Add(new ValidationError("MissionLogDate", "Must supply a date", MissionLogDate));
            return errors;
        }

        public static FlightLogViewModel CreateFromMissionLog(MissionLog missionLog)
        {
            return new FlightLogViewModel
            {
                MissionLogId = missionLog.Id.Value,
                MissionLogDate = missionLog.LogDate,
                AircraftMDS = missionLog.AircraftMDS,
                AircraftSerialNumber = missionLog.AircraftSerialNumber,
                Location = missionLog.Location,
                Missions = missionLog.Missions,
                SquadronLogs = missionLog.SquadronLogs,
            };
        }
    }
}
