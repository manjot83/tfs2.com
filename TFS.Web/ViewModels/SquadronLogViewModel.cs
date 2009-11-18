using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TFS.Models;
using TFS.Models.FlightLogs;
using TFS.Models.PersonnelRecords;

namespace TFS.Web.ViewModels
{
    public class SquadronLogViewModel : BaseValidatableEntity
    {
        public SquadronLogViewModel()
        {
            SquadronLog = new SquadronLog();
        }

        public int MissionLogId { get; set; }

        public IList<Person> AvailablePersons { get; set; }
        public string PersonUsername { get; set; }

        public SquadronLog SquadronLog { get; set; }
    }
}
