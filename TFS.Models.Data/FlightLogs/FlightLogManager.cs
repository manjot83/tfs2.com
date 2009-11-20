using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using TFS.Models.FlightLogs;
using TFS.Models.PersonnelRecords;
using TFS.Extensions;

namespace TFS.Models.Data.FlightLogs
{
    public class FlightLogManager : BaseDataAccessObject, IFlightLogManager
    {
        public FlightLogManager(ISession session)
            : base(session)
        {
        }

        public FlightLog GetFlgithLog(int id)
        {
            return QueryFlightLogs().Where(x => x.Id == id).FirstOrDefault();
        }

        public Mission GetMission(int id)
        {
            return QueryMissions().Where(x => x.Id == id).FirstOrDefault();
        }

        public SquadronLog GetSquadronLog(int id)
        {
            return QuerySquadronLogs().Where(x => x.Id == id).FirstOrDefault();
        }

        public IList<Person> GetAvailableSquadronPersons()
        {
            return Session.Linq<Person>().Where(x => !x.User.Disabled).ToList();
        }

        public Person GetSquadronPersonForUsername(string username)
        {
            return Session.Linq<Person>().Where(x => x.User.Username == username).FirstOrDefault();
        }

        public IEnumerable<FlightLog> GetAllFlightLogs()
        {
            return QueryFlightLogs().ToList();
        }

        public IQueryable<FlightLog> QueryFlightLogs()
        {
            return Session.Linq<FlightLog>();
        }

        public IQueryable<Mission> QueryMissions()
        {
            return Session.Linq<Mission>();
        }

        public IQueryable<SquadronLog> QuerySquadronLogs()
        {
            return Session.Linq<SquadronLog>();
        }

        public FlightLog CreateNewFlightLog(DateTime logDate, string aircraftMDS, string aircraftSerialNumber, string location)
        {
            var newFlightLog = new FlightLog
            {
                AircraftMDS = aircraftMDS,
                AircraftSerialNumber = aircraftSerialNumber,
                Location = location,
                LogDate = logDate,
                LastModifiedDate = DateTime.Now.ToUniversalTime(),
            };
            return (FlightLog)Session.SaveOrUpdateCopy(newFlightLog);
        }
    }
}
