using System.Collections.Generic;
using TFS.Models;
using TFS.Models.FlightLogs;
using TFS.Models.PersonnelRecords;
using System.Linq;

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

        internal void SetAvailablePersons(IEnumerable<Person> availablePersons)
        {
            AvailablePersons = availablePersons.OrderBy(x => x.FileByName()).ToList();
        }
    }
}
