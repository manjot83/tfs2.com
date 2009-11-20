using System.Collections.Generic;
using System.Linq;
using TFS.Models;
using System;
using TFS.Models.PersonnelRecords;

namespace TFS.Models.FlightLogs
{
    public interface IFlightLogManager
    {
        FlightLog GetFlgithLog(int id);
        Mission GetMission(int id);
        SquadronLog GetSquadronLog(int id);
        IEnumerable<FlightLog> GetAllFlightLogs();
        IList<Person> GetAvailableSquadronPersons();
        Person GetSquadronPersonForUsername(string username);

        FlightLog CreateNewFlightLog(DateTime logDate, string aircraftMDS, string aircraftSerialNumber, string location);
    }
}
