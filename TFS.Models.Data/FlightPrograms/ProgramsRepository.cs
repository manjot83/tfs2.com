using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using TFS.Extensions;
using TFS.Models.FlightPrograms;

namespace TFS.Models.Data.FlightPrograms
{
    public class ProgramsRepository : BaseDataAccessObject, IProgramsRepository
    {
        public ProgramsRepository(ISession session)
            : base(session)
        {
        }

        public IList<Position> GetAllPositions()
        {
            return Session.Linq<Position>().ToList();
        }

        public Position GetPositionById(int id)
        {
            return Session.Get<Position>(id);
        }

        public Position AddPosition(Position position)
        {
            if (GetAllPositions().Any(x => x.Title.Matches(position.Title)))
                throw new InvalidOperationException(string.Format("A position with the title {0} already exists", position.Title));
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

        public FlightProgram GetProgramById(int id)
        {
            return Session.Get<FlightProgram>(id);
        }

        public FlightProgram AddProgram(FlightProgram program)
        {
            return Session.SaveOrUpdateCopy<FlightProgram>(program);
        }
    }
}
