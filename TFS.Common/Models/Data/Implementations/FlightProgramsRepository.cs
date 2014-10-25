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
    }
}
