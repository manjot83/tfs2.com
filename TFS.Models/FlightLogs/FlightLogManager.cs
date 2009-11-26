using System.Collections.Generic;
using System.Linq;
using TFS.Models;
using System;
using TFS.Models.PersonnelRecords;

namespace TFS.Models.FlightLogs
{
    public class FlightLogManager
    {
        public FlightLogManager(IFlightLogRepository flightLogRepository)
        {
            FlightLogRepository = flightLogRepository;
        }

        public IFlightLogRepository FlightLogRepository { get; private set; }

        public FlightLog AddFlightLog(FlightLog flightLog)
        {
            flightLog.MarkedUpdated();
            return FlightLogRepository.AddFlightLog(flightLog);
        }
    }
}
