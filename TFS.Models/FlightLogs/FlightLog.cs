using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TFS.Models;
using Iesi.Collections.Generic;
using TFS.Models.FlightPrograms;
using TFS.Models.Validation;

namespace TFS.Models.FlightLogs
{
    public class FlightLog : BaseDomainObject
    {
        public FlightLog()
        {
            this.Missions = new HashedSet<Mission>();
            this.SquadronLogs = new HashedSet<SquadronLog>();

            // Some domain specific defaults
            OperatingUnit = "Tactical Flight Services";
        }

        public virtual Guid? Id { get; set; }

        [DomainEquality, Required, DateTimeKind(DateTimeKind.Utc)]
        public virtual DateTime LogDate { get; set; }
        [DomainEquality, Required, DateTimeKind(DateTimeKind.Utc)]
        public virtual DateTime LastModifiedDate { get; set; }

        [DomainEquality, Required]
        public virtual string AircraftMDS { get; set; } // "Mission Design Series"
        [DomainEquality, Required]
        public virtual string AircraftSerialNumber { get; set; } // "Serial No." or Tail Number

        [DomainEquality, Required]
        public virtual ProgramLocation Location { get; set; }

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
            mission.Validate();
            return mission;
        }
        public virtual SquadronLog AddSquadronLog(SquadronLog squadronLog)
        {
            squadronLog.FlightLog = this;
            squadronLog.MarkedUpdated();
            SquadronLogs.Add(squadronLog);
            squadronLog.Validate();
            return squadronLog;
        }
    }
}
