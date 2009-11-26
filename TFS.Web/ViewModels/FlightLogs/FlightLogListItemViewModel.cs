using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TFS.Web.ViewModels.FlightLogs
{
    public class FlightLogListItemViewModel
    {
        public int Id { get; set; }
        public DateTime LogDate { get; set; }
        public string AircraftMDS { get; set; }
        public string AircraftSerialNumber { get; set; }
        public string Location { get; set; }
    }
}
