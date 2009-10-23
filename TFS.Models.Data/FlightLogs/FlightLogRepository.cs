using System;
using System.Collections.Generic;
using System.Linq;
using Centro.Data.DomainModel;
using NHibernate;
using NHibernate.Linq;
using TFS.Models.FlightLogs;

namespace TFS.Models.Data.FlightLogs
{
    public class FlightLogRepository : BaseRepository, IFlightLogRepository
    {
        public FlightLogRepository(ISession session)
            : base(session)
        {
        }

        public MissionLog GetMissionLog(int id)
        {
            return QueryMissionLogs().Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<MissionLog> GetAllMissionLogs()
        {
            return QueryMissionLogs().ToList();
        }

        public IQueryable<MissionLog> QueryMissionLogs()
        {
            return Session.Linq<MissionLog>();
        }

        public IQueryable<Mission> QueryMissions()
        {
            return Session.Linq<Mission>();
        }

        public IQueryable<SquadronLog> QuerySquadronLogs()
        {
            return Session.Linq<SquadronLog>();
        }

        public MissionLog SaveOrUpdate(MissionLog missionLog)
        {
            missionLog.LastModifiedDate = DateTime.Now.ToUniversalTime();
            return (MissionLog)Session.SaveOrUpdateCopy(missionLog);
        }

        public SquadronLog SaveOrUpdate(SquadronLog squadronLog)
        {
            squadronLog.MissionLog.LastModifiedDate = DateTime.Now.ToUniversalTime();
            return (SquadronLog)Session.SaveOrUpdateCopy(squadronLog);
        }

        public Mission SaveOrUpdate(Mission mission)
        {
            mission.MissionLog.LastModifiedDate = DateTime.Now.ToUniversalTime();
            return (Mission)Session.SaveOrUpdateCopy(mission);
        }

        public MissionLog CreateNewMissionLog(string aircraftModel, string aircraftSerialNumber, string location)
        {
            var newMissionLog = new MissionLog
            {
                AircraftModel = aircraftModel,
                AircraftSerialNumber = aircraftSerialNumber,
                Location = location,
                CreatedDate = DateTime.Now.ToUniversalTime(),
                LastModifiedDate = DateTime.Now.ToUniversalTime(),
            };
            return SaveOrUpdate(newMissionLog);
        }
    }
}
