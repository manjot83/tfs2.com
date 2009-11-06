using System.Collections.Generic;
using Centro.DomainModel;

namespace TFS.Models.Programs
{
    public interface IProgramsRepository
    {
        IList<Position> GetAllPositions();
        Position GetPositionById(int id);


        Position CreateNewPosition(string title);
    }
}
