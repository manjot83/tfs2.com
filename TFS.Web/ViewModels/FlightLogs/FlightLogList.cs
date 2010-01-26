using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TFS.Web.ViewModels.FlightLogs
{
    public class FlightLogList : SortedListViewModel<FlightLogListItemViewModel>
    {
        public bool IsFlightLogManager { get; set; }
    }
}
