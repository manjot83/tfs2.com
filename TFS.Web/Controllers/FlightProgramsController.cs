using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using TFS.Web.ActionFilters;
using TFS.Models.FlightPrograms;
using TFS.Web.ViewModels.FlightPrograms;
using AutoMapper;

namespace TFS.Web.Controllers
{
    [DomainAuthorize]
    public partial class FlightProgramsController : Controller
    {
        private readonly FlightProgramsManager programsManager;

        public FlightProgramsController(FlightProgramsManager programsManager)
        {
            this.programsManager = programsManager;
        }

        [RequireTransaction]
        public virtual ViewResult Index()
        {
            return Manage(null);
        }

        [RequireTransaction]
        public virtual ViewResult Manage(bool? showAllActivePrograms)
        {
            var viewModel = new DashboardViewModel()
            {
                ShowAllActivePrograms = showAllActivePrograms.HasValue && showAllActivePrograms.Value,
            };
            IEnumerable<FlightProgram> programs = null;
            if (viewModel.ShowAllActivePrograms)
                programs = programsManager.ProgramsRepository.GetAllActivePrograms();
            else
                programs = programsManager.ProgramsRepository.GetAllPrograms();
            var positions = programsManager.ProgramsRepository.GetAllPositions();                        
            viewModel.Positions = Mapper.Map<IEnumerable<Position>, IEnumerable<PositionViewModel>>(positions);
            viewModel.FlightPrograms = Mapper.Map<IEnumerable<FlightProgram>, IEnumerable<FlightProgramListItemViewModel>>(programs);
            return View(viewModel);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public virtual ViewResult CreateFlightProgram()
        {
            throw new NotImplementedException();
        }

        [RequireTransaction]
        [AcceptVerbs(HttpVerbs.Get)]
        public virtual ViewResult EditFlightProgram(int id)
        {
            throw new NotImplementedException();
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public virtual ViewResult CreatePosition()
        {
            throw new NotImplementedException();
        }

        [RequireTransaction]
        [AcceptVerbs(HttpVerbs.Get)]
        public virtual ViewResult RenamePosition(int id)
        {
            throw new NotImplementedException();
        }
    }
}
