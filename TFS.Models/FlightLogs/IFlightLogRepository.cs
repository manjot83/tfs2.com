using System.Collections.Generic;
using System.Linq;
using Centro.DomainModel;
using System;

namespace TFS.Models.FlightLogs
{
    public interface IFlightLogRepository : IRepository
    {
        MissionLog GetMissionLog(int id);
        IEnumerable<MissionLog> GetAllMissionLogs();

        IQueryable<MissionLog> QueryMissionLogs();
        IQueryable<Mission> QueryMissions();
        IQueryable<SquadronLog> QuerySquadronLogs();

        MissionLog CreateNewMissionLog(DateTime logDate, string aircraftMDS, string aircraftSerialNumber, string location);
    }
}
