﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TFS.Models;

namespace TFS.Web.ViewModels.FlightPrograms
{
    public class DashboardViewModel
    {
        public bool ShowAllPrograms { get; set; }

        public IEnumerable<FlightProgramListItemViewModel> FlightPrograms { get; set; }
        public IEnumerable<PositionViewModel> Positions { get; set; }
        public IEnumerable<AircraftViewModel> Aircrafts { get; set; }

        public IEnumerable<FlightProgramListItemViewModel> SortedFlightPrograms
        {
            get
            {
                return FlightPrograms.OrderBy(x => x.Name);
            }
        }

        public IEnumerable<PositionViewModel> SortedPositions
        {
            get
            {
                return Positions.OrderBy(x => x.Title);
            }
        }

        public IEnumerable<AircraftViewModel> SortedAircraft
        {
            get
            {
                return Aircrafts.OrderBy(x => x.Name);
            }
        }
    }
}
