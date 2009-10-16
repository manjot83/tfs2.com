using System.Collections.Generic;
using Centro.DomainModel;

namespace TFS.Models.Programs
{
    public interface IProgramsRepository : IRepository
    {
        IList<Position> GetAllPositions();

        Position SaveOrUpdate(Position position);

        Position CreateNewPosition(string title);
    }
}
