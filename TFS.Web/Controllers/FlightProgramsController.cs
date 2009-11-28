using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using TFS.Web.ActionFilters;
using TFS.Models.FlightPrograms;
using TFS.Web.ViewModels.FlightPrograms;
using TFS.Web.ViewModels;
using AutoMapper;

namespace TFS.Web.Controllers
{
    [DomainAuthorize]
    public partial class FlightProgramsController : Controller
    {
        private readonly FlightProgramsManager flightProgramsManager;

        public FlightProgramsController(FlightProgramsManager flightProgramsManager)
        {
            this.flightProgramsManager = flightProgramsManager;
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
                programs = flightProgramsManager.ProgramsRepository.GetAllActivePrograms();
            else
                programs = flightProgramsManager.ProgramsRepository.GetAllPrograms();
            var positions = flightProgramsManager.ProgramsRepository.GetAllPositions();                        
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
            return View(Views.CreatePosition, new PositionViewModel());
        }

        [RequireTransaction]
        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult CreatePosition(PositionViewModel positionViewModel)
        {
            positionViewModel.Validate(ModelState, string.Empty);
            if (!ModelState.IsValid)
                return View(Views.CreatePosition, positionViewModel);
            flightProgramsManager.CreateNewPosition(positionViewModel.Title);
            return RedirectToAction(MVC.FlightPrograms.Manage());
        }

        [RequireTransaction]
        [AcceptVerbs(HttpVerbs.Get)]
        public virtual ViewResult RenamePosition(int id)
        {
            var position = flightProgramsManager.ProgramsRepository.GetPositionById(id);
            var viewModel = Mapper.Map<Position, PositionViewModel>(position);
            return View(Views.EditPosition, viewModel);
        }

        [RequireTransaction]
        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult RenamePosition(int id, PositionViewModel positionViewModel)
        {
            var position = flightProgramsManager.ProgramsRepository.GetPositionById(id);
            positionViewModel.Validate(ModelState, string.Empty);
            if (!ModelState.IsValid)
            {
                var viewModel = Mapper.Map<Position, PositionViewModel>(position);
                return View(Views.EditPosition, viewModel);
            }
            Mapper.Map<PositionViewModel, Position>(positionViewModel, position);
            return RedirectToAction(MVC.FlightPrograms.Manage());
        }
    }
}
