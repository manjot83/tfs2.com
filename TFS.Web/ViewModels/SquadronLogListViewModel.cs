using System.Collections.Generic;
using TFS.Models.FlightLogs;
using TFS.Models.PersonnelRecords;

namespace TFS.Web.ViewModels
{
    public class SquadronLogListViewModel : SortedListViewModel<SquadronLog>
    {
        public FlightLog FlightLog { get; set; }
        public SquadronLogViewModel CurrentSquadronLog { get; set; }
    }
}
