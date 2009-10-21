using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Centro.DomainModel;

namespace TFS.Models.FlightLogs
{
    public class MissionSummary : BaseEntity
    {
        public MissionSummary()
        {
            this.Missions = new List<Mission>();
            this.SquadronLogs = new List<SquadronLog>();
        }

        public virtual int? Id { get; set; }

        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime LastModifiedDate { get; set; }

        public virtual string AircraftModel { get; set; } // "MDS"
        public virtual string AircraftSerialNumber { get; set; } // "Serial No." or Tail Number

        public virtual string Location { get; set; } // Todo Change to "Program Location"

        public virtual IList<Mission> Missions { get; set; }
        public virtual IList<SquadronLog> SquadronLogs { get; set; }
    }
}
