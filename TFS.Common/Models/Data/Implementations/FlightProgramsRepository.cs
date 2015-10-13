using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using TFS.Extensions;
using TFS.Models.FlightPrograms;
using StructureMap;

namespace TFS.Models.Data.Implementations
{
    public class FlightProgramsRepository : NHibernateRepository, IFlightProgramsRepository
    {
        public FlightProgramsRepository(INHibernateUnitOfWork nhibernateUnitOfWork, IContainer container)
            : base(nhibernateUnitOfWork, container)
        {
        }

        public IList<Position> GetAllPositions()
        {
            return Query<Position>().ToList();
        }

        public Position AddNewPosition(string title)
        {
            if (GetAllPositions().Any(x => x.Title.Matches(title)))
                throw new InvalidOperationException(string.Format("A position with the title {0} already exists", title));
            var position = new Position { Title = title };
            position.Validate();
            return Persist<Position>(position);
        }

        public IEnumerable<FlightProgram> GetAllActivePrograms()
        {
            return Query<FlightProgram>().Where(x => x.Active).ToList();
        }

        public IEnumerable<FlightProgram> GetAllPrograms()
        {
            return Query<FlightProgram>().ToList();
        }

        public FlightProgram AddNewFlightProgram(FlightProgram flightProgram)
        {
            flightProgram.Active = true;
            flightProgram.Validate();
            return Persist<FlightProgram>(flightProgram);
        }

        public IEnumerable<ProgramLocation> GetAllActiveProgramLocations()
        {
            return Query<ProgramLocation>().Where(x => x.Program.Active).ToList();
        }

        public AircraftMDS AddNewAircraftMds(string name)
        {
            if (GetAllAircrafts().Any(x => x.Name.Matches(name)))
                throw new InvalidOperationException(string.Format("An aircraft with the name {0} already exists", name));
            var aircraft = new AircraftMDS()
            {
                Name = name,
                Active = true
            };
            aircraft.Validate();
            return Persist<AircraftMDS>(aircraft);
        }

        public AircraftMDS AddAircraftMds(AircraftMDS aircraftMds)
        {
            aircraftMds.Validate();
            aircraftMds.Active = true;
            return Persist<AircraftMDS>(aircraftMds);
        }

        public IList<AircraftMDS> GetAllAircrafts()
        {
            return Query<AircraftMDS>().ToList();
        }

        public IEnumerable<AircraftMDS> GetAllActiveAircraftMds()
        {
            return Query<AircraftMDS>().Where(x => x.Active).ToList();
        }
    }
}
