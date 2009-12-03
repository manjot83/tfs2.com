﻿using System.Collections.Generic;
using TFS.Models;

namespace TFS.Models.FlightPrograms
{
    public class FlightProgramsManager
    {
        public FlightProgramsManager(IFlightProgramsRepository programsRepository)
        {
            ProgramsRepository = programsRepository;
        }

        public IFlightProgramsRepository ProgramsRepository { get; private set; }

        public Position CreateNewPosition(string title)
        {
            var position = new Position { Title = title };
            return ProgramsRepository.AddPosition(position);
        }

        public FlightProgram CreateNewFlightProgram(FlightProgram flightProgram)
        {
            flightProgram.Active = true;
            return ProgramsRepository.AddProgram(flightProgram);
        }
    }
}
