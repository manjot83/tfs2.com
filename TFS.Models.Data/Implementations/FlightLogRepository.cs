using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using TFS.Models.FlightLogs;
using TFS.Models.PersonnelRecords;
using TFS.Extensions;
using TFS.Models.Users;
using StructureMap;

namespace TFS.Models.Data.Implementations
{
    public class FlightLogRepository : NHibernateRepository, IFlightLogRepository
    {
        public FlightLogRepository(INHibernateUnitOfWork nhibernateUnitOfWork, IContainer container)
            : base(nhibernateUnitOfWork, container)
        {
        }

        public IEnumerable<FlightLog> GetAllFlightLogs()
        {
            return Query<FlightLog>().ToList();
        }

        public FlightLog AddFlightLog(FlightLog flightLog)
        {
            flightLog.MarkedUpdated();
            flightLog.Validate();
            return Persist<FlightLog>(flightLog);
        }
    }
}
