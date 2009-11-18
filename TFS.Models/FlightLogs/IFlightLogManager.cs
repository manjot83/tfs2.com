using System.Collections.Generic;
using System.Linq;
using TFS.Models;
using System;
using TFS.Models.PersonnelRecords;

namespace TFS.Models.FlightLogs
{
    public interface IFlightLogManager
    {
        MissionLog GetMissionLog(int id);
        Mission GetMission(int id);
        SquadronLog GetSquadronLog(int id);
        IEnumerable<MissionLog> GetAllMissionLogs();
        IList<Person> GetAvailableSquadronPersons();
        Person GetSquadronPersonForUsername(string username);

        MissionLog CreateNewMissionLog(DateTime logDate, string aircraftMDS, string aircraftSerialNumber, string location);
    }
}
