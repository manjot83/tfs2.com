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
