using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.Models.PersonnelRecords;

namespace TFS.Models.FlightLogs
{
    public interface IFlightLogRepository : IRepository
    {
        IEnumerable<FlightLog> GetAllFlightLogs();
        FlightLog AddFlightLog(FlightLog flightLog);
    }
}
