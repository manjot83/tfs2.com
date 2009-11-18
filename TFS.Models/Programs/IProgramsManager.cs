using System.Collections.Generic;
using TFS.Models;

namespace TFS.Models.Programs
{
    public interface IProgramsManager
    {
        IList<Position> GetAllPositions();
        Position GetPositionById(int id);


        Position CreateNewPosition(string title);
    }
}
