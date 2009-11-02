using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Centro.DomainModel;

namespace TFS.Models.FlightLogs
{
    public class MissionLog : BaseEntity
    {
        public MissionLog()
        {
            this.Missions = new List<Mission>();
            this.SquadronLogs = new List<SquadronLog>();

            // Some domain specific defaults
            OperatingUnit = "Tactical Flight Services";
        }

        public virtual int? Id { get; set; }

        [DomainSignature, Required]
        public virtual DateTime LogDate { get; set; }
        [DomainSignature, Required]
        public virtual DateTime LastModifiedDate { get; set; }

        [DomainSignature, Required]
        public virtual string AircraftMDS { get; set; } // "Mission Design Series"
        [DomainSignature, Required]
        public virtual string AircraftSerialNumber { get; set; } // "Serial No." or Tail Number

        [DomainSignature, Required]
        public virtual string Location { get; set; } // Todo Change to "Program Location"

        public virtual IList<Mission> Missions { get; set; }
        public virtual IList<SquadronLog> SquadronLogs { get; set; }

        public virtual string OperatingUnit { get; set; }

        public virtual double CalculateTotalFlightTime()
        {
            return Missions.Sum(x => x.ComputeFlightTime().TotalHours);
        }

        public virtual double CalculateTotalTouchAndGos()
        {
            return Missions.Sum(x => x.TouchAndGos);
        }

        public virtual double CalculateTotalFullStops()
        {
            return Missions.Sum(x => x.FullStops);
        }

        public virtual double CalculateTotals()
        {
            return Missions.Sum(x => x.Totals);
        }

        public virtual double CalculateTotalSorties()
        {
            return Missions.Sum(x => x.Sorties);
        }

        public virtual void MarkedUpdated()
        {
            LastModifiedDate = DateTime.Now.ToUniversalTime();
        }
    }
}
