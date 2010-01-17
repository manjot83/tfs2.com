using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using TFS.Models.FlightLogs;
using TFS.Models.PersonnelRecords;
using TFS.Extensions;
using TFS.Models.Users;

namespace TFS.Models.Data.Implementations
{
    public class FlightLogRepository : NHibernateRepository, IFlightLogRepository
    {
        public FlightLogRepository(ISession session)
            : base(session)
        {
        }

        public IEnumerable<FlightLog> GetAllFlightLogs()
        {
            return Session.Linq<FlightLog>().ToList();
        }

        public FlightLog AddFlightLog(FlightLog flightLog)
        {
            flightLog.MarkedUpdated();
            flightLog.Validate();
            return Session.SaveOrUpdateCopy<FlightLog>(flightLog);
        }
    }
}
