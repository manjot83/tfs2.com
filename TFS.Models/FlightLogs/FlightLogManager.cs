using System.Collections.Generic;
using System.Linq;
using TFS.Models;
using System;
using TFS.Models.PersonnelRecords;
using TFS.Models.FlightPrograms;
using TFS.Models.Users;

namespace TFS.Models.FlightLogs
{
    public class FlightLogManager
    {
        public FlightLogManager(IFlightLogRepository flightLogRepository, 
                                IFlightProgramsRepository flightProgramsRepository, 
                                IUserRepository userRepository)
        {
            FlightLogRepository = flightLogRepository;
            FlightProgramsRepository = flightProgramsRepository;
            UserRepository = userRepository;
        }

        public IFlightLogRepository FlightLogRepository { get; private set; }
        public IFlightProgramsRepository FlightProgramsRepository { get; private set; }
        public IUserRepository UserRepository { get; private set; }

        public FlightLog AddFlightLog(FlightLog flightLog)
        {
            flightLog.MarkedUpdated();
            flightLog.Validate();
            return FlightLogRepository.AddFlightLog(flightLog);
        }
    }
}
