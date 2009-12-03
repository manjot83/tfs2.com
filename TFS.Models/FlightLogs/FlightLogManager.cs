using System.Collections.Generic;
using System.Linq;
using TFS.Models;
using System;
using TFS.Models.PersonnelRecords;
using TFS.Models.FlightPrograms;

namespace TFS.Models.FlightLogs
{
    public class FlightLogManager
    {
        public FlightLogManager(IFlightLogRepository flightLogRepository, IFlightProgramsRepository flightProgramsRepository)
        {
            FlightLogRepository = flightLogRepository;
            FlightProgramsRepository = flightProgramsRepository;
        }

        public IFlightLogRepository FlightLogRepository { get; private set; }
        public IFlightProgramsRepository FlightProgramsRepository { get; private set; }

        public FlightLog AddFlightLog(FlightLog flightLog)
        {
            flightLog.MarkedUpdated();
            return FlightLogRepository.AddFlightLog(flightLog);
        }
    }
}
