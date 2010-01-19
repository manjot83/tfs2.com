using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using TFS.Models.Validation;
using TFS.Models;
using System.Web.Mvc;
using TFS.Models.FlightPrograms;

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

        public IEnumerable<MissionViewModel> Missions { get; set; }
        public IEnumerable<SquadronLogViewModel> SquadronLogs { get; set; }

        public bool PreviouslySaved { get; set; }

        public IEnumerable<SelectListItem> ActiveLocations { get; set; }

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
