using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Centro.DomainModel;

namespace TFS.Models.FlightLogs
{
    public class MissionLog : BaseEntity
    {
        public MissionLog()
        {
            this.Missions = new List<Mission>();
            this.SquadronLogs = new List<SquadronLog>();
        }

        public virtual int? Id { get; set; }

        [DomainSignature, Required]
        public virtual DateTime LogDate { get; set; }
        [DomainSignature, Required]
        public virtual DateTime LastModifiedDate { get; set; }

        [DomainSignature, Required]
        public virtual string AircraftModel { get; set; } // "MDS"
        [DomainSignature, Required]
        public virtual string AircraftSerialNumber { get; set; } // "Serial No." or Tail Number

        [DomainSignature, Required]
        public virtual string Location { get; set; } // Todo Change to "Program Location"

        public virtual IList<Mission> Missions { get; set; }
        public virtual IList<SquadronLog> SquadronLogs { get; set; }

        public virtual void MarkedUpdated()
        {
            LastModifiedDate = DateTime.Now.ToUniversalTime();
        }
    }
}
