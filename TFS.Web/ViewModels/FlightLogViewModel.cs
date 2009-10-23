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
        public DateTime LastModifiedDate { get; set; }
        [Required]
        public string AircraftModel { get; set; } // "MDS"
        [Required]
        public string AircraftSerialNumber { get; set; } // "Serial No." or Tail Number
        [Required]
        public string Location { get; set; } // Todo Change to "Program Location"

        public static FlightLogViewModel CreateFromMissionLog(MissionLog missionLog)
        {
            return new FlightLogViewModel
            {
                FlightLogId = missionLog.Id.Value,
                LastModifiedDate = missionLog.LastModifiedDate,
                AircraftModel = missionLog.AircraftModel,
                AircraftSerialNumber = missionLog.AircraftSerialNumber,
                Location = missionLog.Location,
            };
        }
    }
}
