using System.Collections.Generic;
using System.Linq;
using Centro.DomainModel;

namespace TFS.Models.FlightLogs
{
    public interface IFlightLogRepository : IRepository
    {
        MissionLog GetMissionLog(int id);
        IEnumerable<MissionLog> GetAllMissionLogs();

        IQueryable<MissionLog> QueryMissionLogs();
        IQueryable<Mission> QueryMissions();
        IQueryable<SquadronLog> QuerySquadronLogs();

        MissionLog SaveOrUpdate(MissionLog missionLog);
        SquadronLog SaveOrUpdate(SquadronLog squadronLog);
        Mission SaveOrUpdate(Mission mission);

        MissionLog CreateNewMissionLog(string aircraftModel, string aircraftSerialNumber, string location);


        
    }
}
