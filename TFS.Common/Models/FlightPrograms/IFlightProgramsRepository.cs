using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TFS.Models.FlightPrograms
{
    public interface IFlightProgramsRepository : IRepository
    {
        IList<Position> GetAllPositions();
        Position AddNewPosition(string title);

        IEnumerable<FlightProgram> GetAllActivePrograms();
        IEnumerable<FlightProgram> GetAllPrograms();
        FlightProgram AddNewFlightProgram(FlightProgram flightProgram);

        IEnumerable<ProgramLocation> GetAllActiveProgramLocations();

        AircraftMDS AddNewAircraftMds(string name);
        IList<AircraftMDS> GetAllAircrafts();
        IEnumerable<AircraftMDS> GetAllActiveAircraftMds();
    }
}
