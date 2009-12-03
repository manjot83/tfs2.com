﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TFS.Models.FlightPrograms
{
    public interface IFlightProgramsRepository
    {
        IList<Position> GetAllPositions();
        Position GetPositionById(int id);
        Position AddPosition(Position position);

        IEnumerable<FlightProgram> GetAllActivePrograms();
        IEnumerable<FlightProgram> GetAllPrograms();
        FlightProgram GetProgramById(int id);
        FlightProgram AddProgram(FlightProgram program);

        IEnumerable<ProgramLocation> GetAllActiveProgramLocations();
        ProgramLocation GetProgramLocationById(int id);
    }
}