using System;
using System.Collections.Generic;
using System.Linq;
using Centro.Extensions;
using NHibernate;
using NHibernate.Linq;
using TFS.Models.Programs;

namespace TFS.Models.Data.Programs
{
    public class ProgramsManager : BaseService, IProgramsManager
    {
        public ProgramsManager(ISession session)
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

        public Position CreateNewPosition(string title)
        {
            if (GetAllPositions().Any(x => x.Title.Matches(title)))
                throw new InvalidOperationException(string.Format("A position with the title {0} already exists", title));
            var newPosition = new Position
            {
                Title = title,
            };
            return (Position)Session.SaveOrUpdateCopy(newPosition);
        }
    }
}
