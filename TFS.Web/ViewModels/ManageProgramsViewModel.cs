using System.Collections.Generic;
using TFS.Models.Programs;

namespace TFS.Web.ViewModels
{
    public class ManageProgramsViewModel
    {
        public ManageProgramsViewModel()
        {
            ActivePositions = new List<Position>();
        }

        public IList<Position> ActivePositions { get; set; }
    }
}
