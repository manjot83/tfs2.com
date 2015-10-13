using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using TFS.Models.FlightPrograms;
using TFS.Models.Validation;

namespace TFS.Web.ViewModels.FlightLogs
{
    public class FlightLogViewModel
    {
        public Guid? Id { get; set; }
        [Required, DateRange(Exclusive = true)]
        public DateTime LogDate { get; set; }
        [Required]
        public string AircraftMDS { get; set; } // "Mission-Design Series"
        [Required]
        public string AircraftSerialNumber { get; set; } // "Serial No." or Tail Number
        [Required]
        public Guid LocationId { get; set; }

        public bool IsFlightLogManager { get; set; }

        public IEnumerable<MissionViewModel> Missions { get; set; }
        public IEnumerable<SquadronLogViewModel> SquadronLogs { get; set; }

        public bool PreviouslySaved { get; set; }

        public IEnumerable<SelectListItem> ActiveLocations { get; set; }

        public IEnumerable<SelectListItem> ActiveAircraft { get; set; }

        public void SetActiveAircraft(IEnumerable<AircraftMDS> aircraftMds) {

            ActiveAircraft = aircraftMds.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Name,
                Selected = AircraftMDS == x.Name,
            });
        }

        public void SetActiveLocations(IEnumerable<ProgramLocation> programLocations)
        {
            ActiveLocations = programLocations.Select(x => new SelectListItem
            {
                Text = x.ToDisplayString(),
                Value = x.Id.Value.ToString(),
                Selected = LocationId == x.Id.Value,
            });
        }
    }
}
