using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Centro.DomainModel;
using System.ComponentModel.DataAnnotations;
using TFS.Models.FlightLogs;

namespace TFS.Web.ViewModels
{
    public class FlightLogViewModel : BaseEntity
    {
        public int FlightLogId { get; set; }
        [Required]
        public DateTime FlightLogDate { get; set; }
        [Required]
        public string AircraftModel { get; set; } // "MDS"
        [Required]
        public string AircraftSerialNumber { get; set; } // "Serial No." or Tail Number
        [Required]
        public string Location { get; set; } // Todo Change to "Program Location"

        public bool SavedMissionLog { get; set; }

        public IList<Mission> Missions { get; set; }
        public IList<SquadronLog> SquadronLogs { get; set; }

        public static FlightLogViewModel CreateFromMissionLog(MissionLog missionLog)
        {
            return new FlightLogViewModel
            {
                FlightLogId = missionLog.Id.Value,
                FlightLogDate = missionLog.LogDate,
                AircraftModel = missionLog.AircraftModel,
                AircraftSerialNumber = missionLog.AircraftSerialNumber,
                Location = missionLog.Location,
                Missions = missionLog.Missions,
                SquadronLogs = missionLog.SquadronLogs,
            };
        }
    }
}
