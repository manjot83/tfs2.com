using System.Collections.Generic;
using TFS.Models.FlightLogs;
using TFS.Models.PersonnelRecords;
using TFS.Web.ViewModels.FlightLogs;

namespace TFS.Web.ViewModels.FlightLogs
{
    public class SquadronLogListViewModel : SortedListViewModel<SquadronLogViewModel>
    {
        public FlightLogListItemViewModel FlightLog { get; set; }
        public SquadronLogViewModel CurrentSquadronLog { get; set; }

        public bool IsFlightLogManager { get; set; }
    }
}
