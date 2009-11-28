using System.Collections.Generic;
using TFS.Models.FlightPrograms;

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
