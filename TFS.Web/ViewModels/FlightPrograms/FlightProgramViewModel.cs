using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TFS.Models;
using System.ComponentModel.DataAnnotations;

namespace TFS.Web.ViewModels.FlightPrograms
{
    public class FlightProgramViewModel : FlightProgramListItemViewModel
    {
        public IEnumerable<ProgramLocationViewModel> Locations { get; set; }

        public void SetProgramLocations(IEnumerable<ProgramLocationViewModel> locations)
        {
            Locations = locations.OrderBy(x => x.Name);
        }
    }
}
