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

        public FlightLog CreateNewFlightLog(DateTime logDate, string aircraftMDS, string aircraftSerialNumber, string location)
        {
            var flightLog = new FlightLog
            {
                AircraftMDS = aircraftMDS,
                AircraftSerialNumber = aircraftSerialNumber,
                Location = location,
                LogDate = logDate,
                LastModifiedDate = DateTime.UtcNow,
            };
            return FlightLogRepository.AddFlightLog(flightLog);
        }
    }
}
