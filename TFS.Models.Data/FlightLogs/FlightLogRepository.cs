﻿using System;
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

        public MissionLog CreateNewMissionLog(DateTime logDate, string aircraftModel, string aircraftSerialNumber, string location)
        {
            var newMissionLog = new MissionLog
            {
                AircraftModel = aircraftModel,
                AircraftSerialNumber = aircraftSerialNumber,
                Location = location,
                LogDate = DateTime.Now.ToUniversalTime(),
                LastModifiedDate = DateTime.Now.ToUniversalTime(),
            };
            return (MissionLog)Session.SaveOrUpdateCopy(newMissionLog);
        }
    }
}