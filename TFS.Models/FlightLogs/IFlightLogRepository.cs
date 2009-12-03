using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.Models.PersonnelRecords;

namespace TFS.Models.FlightLogs
{
    public interface IFlightLogRepository
    {
        IEnumerable<FlightLog> GetAllFlightLogs();

        FlightLog GetFlightLogById(int id);
        Mission GetMissionById(int id);
        SquadronLog GetSquadronLogById(int id);

        FlightLog AddFlightLog(FlightLog flightLog);
    }
}
