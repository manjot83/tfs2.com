using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TFS.Models;
using Iesi.Collections.Generic;

namespace TFS.Models.FlightLogs
{
    public class FlightLog : BaseDomainEntity
    {
        public FlightLog()
        {
            this.Missions = new HashedSet<Mission>();
            this.SquadronLogs = new HashedSet<SquadronLog>();

            // Some domain specific defaults
            OperatingUnit = "Tactical Flight Services";
        }

        public virtual int? Id { get; set; }

        [DomainEquality, Required]
        public virtual DateTime LogDate { get; set; }
        [DomainEquality, Required]
        public virtual DateTime LastModifiedDate { get; set; }

        [DomainEquality, Required]
        public virtual string AircraftMDS { get; set; } // "Mission Design Series"
        [DomainEquality, Required]
        public virtual string AircraftSerialNumber { get; set; } // "Serial No." or Tail Number

        [DomainEquality, Required]
        public virtual string Location { get; set; } // Todo Change to "Program Location"

        public virtual ISet<Mission> Missions { get; set; }
        public virtual ISet<SquadronLog> SquadronLogs { get; set; }

        public virtual string OperatingUnit { get; set; }

        public virtual double CalculateTotalFlightTime()
        {
            return Missions.Sum(x => x.ComputeFlightTime().TotalHours);
        }

        public virtual int CalculateTotalTouchAndGos()
        {
            return Missions.Sum(x => x.TouchAndGos);
        }

        public virtual int CalculateTotalFullStops()
        {
            return Missions.Sum(x => x.FullStops);
        }

        public virtual int CalculateTotals()
        {
            return Missions.Sum(x => x.Totals);
        }

        public virtual int CalculateTotalSorties()
        {
            return Missions.Sum(x => x.Sorties);
        }

        public virtual void MarkedUpdated()
        {
            LastModifiedDate = DateTime.Now.ToUniversalTime();
        }

        public virtual Mission AddMission(Mission mission)
        {
            mission.FlightLog = this;
            mission.MarkedUpdated();
            Missions.Add(mission);
            return mission;
        }
        public virtual SquadronLog AddSquadronLog(SquadronLog squadronLog)
        {
            squadronLog.FlightLog = this;
            squadronLog.MarkedUpdated();
            SquadronLogs.Add(squadronLog);
            return squadronLog;
        }
    }
}
