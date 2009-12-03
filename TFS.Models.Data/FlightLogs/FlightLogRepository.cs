﻿using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using TFS.Models.FlightLogs;
using TFS.Models.PersonnelRecords;
using TFS.Extensions;
using TFS.Models.Users;

namespace TFS.Models.Data.FlightLogs
{
    public class FlightLogRepository : BaseDataAccessObject, IFlightLogRepository
    {
        public FlightLogRepository(ISession session)
            : base(session)
        {
        }

        public IEnumerable<FlightLog> GetAllFlightLogs()
        {
            return QueryFlightLogs().ToList();
        }

        public FlightLog GetFlightLogById(int id)
        {
            return QueryFlightLogs().Where(x => x.Id == id).FirstOrDefault();
        }

        public Mission GetMissionById(int id)
        {
            return QueryMissions().Where(x => x.Id == id).FirstOrDefault();
        }

        public SquadronLog GetSquadronLogById(int id)
        {
            return QuerySquadronLogs().Where(x => x.Id == id).FirstOrDefault();
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

        public FlightLog AddFlightLog(FlightLog flightLog)
        {
            flightLog.Validate();
            return Session.SaveOrUpdateCopy<FlightLog>(flightLog);
        }
    }
}
