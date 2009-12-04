using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using TFS.Extensions;
using TFS.Models.FlightPrograms;

namespace TFS.Models.Data.Implementations
{
    public class FlightProgramsRepository : BaseDataAccessObject, IFlightProgramsRepository
    {
        public FlightProgramsRepository(ISession session)
            : base(session)
        {
        }

        public IList<Position> GetAllPositions()
        {
            return Session.Linq<Position>().ToList();
        }

        public Position AddNewPosition(string title)
        {
            if (GetAllPositions().Any(x => x.Title.Matches(title)))
                throw new InvalidOperationException(string.Format("A position with the title {0} already exists", title));
            var position = new Position { Title = title };
            position.Validate();
            return Session.SaveOrUpdateCopy<Position>(position);
        }

        public IEnumerable<FlightProgram> GetAllActivePrograms()
        {
            return Session.Linq<FlightProgram>().Where(x => x.Active).ToList();
        }

        public IEnumerable<FlightProgram> GetAllPrograms()
        {
            return Session.Linq<FlightProgram>().ToList();
        }

        public FlightProgram AddNewFlightProgram(FlightProgram flightProgram)
        {
            flightProgram.Active = true;
            flightProgram.Validate();
            return Session.SaveOrUpdateCopy<FlightProgram>(flightProgram);
        }

        public IEnumerable<ProgramLocation> GetAllActiveProgramLocations()
        {
            return Session.Linq<ProgramLocation>().Where(x => x.Program.Active).ToList();
        }
    }
}
