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
        public virtual ViewResult Manage(bool? showAllPrograms)
        {
            var viewModel = new DashboardViewModel()
            {
                ShowAllPrograms = showAllPrograms.HasValue && showAllPrograms.Value,
            };
            IEnumerable<FlightProgram> programs = null;
            if (viewModel.ShowAllPrograms)
                programs = flightProgramsManager.ProgramsRepository.GetAllPrograms();
            else
                programs = flightProgramsManager.ProgramsRepository.GetAllActivePrograms();
            var positions = flightProgramsManager.ProgramsRepository.GetAllPositions();
            viewModel.Positions = Mapper.Map<IEnumerable<Position>, IEnumerable<PositionViewModel>>(positions);
            viewModel.FlightPrograms = Mapper.Map<IEnumerable<FlightProgram>, IEnumerable<FlightProgramListItemViewModel>>(programs);
            return View(Views.Manage, viewModel);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public virtual ViewResult CreateFlightProgram()
        {
            return View(Views.CreateFlightProgram, new FlightProgramViewModel());
        }

        [RequireTransaction]
        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult CreateFlightProgram(FlightProgramViewModel flightProgramViewModel)
        {
            flightProgramViewModel.Validate(ModelState, string.Empty);
            if (!ModelState.IsValid)
                return View(Views.CreateFlightProgram, flightProgramViewModel);
            var flightProgram = Mapper.Map<FlightProgramViewModel, FlightProgram>(flightProgramViewModel);
            flightProgram = flightProgramsManager.CreateNewFlightProgram(flightProgram);
            return RedirectToAction(MVC.FlightPrograms.EditFlightProgram(flightProgram.Id.Value));
        }

        [RequireTransaction]
        [AcceptVerbs(HttpVerbs.Get)]
        public virtual ViewResult EditFlightProgram(int id)
        {
            var flightProgram = flightProgramsManager.ProgramsRepository.GetProgramById(id);
            var viewModel = Mapper.Map<FlightProgram, FlightProgramViewModel>(flightProgram);
            return View(Views.EditFlightProgram, viewModel);
        }

        [RequireTransaction]
        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult EditFlightProgram(int id, FlightProgramViewModel flightProgramViewModel)
        {
            var flightProgram = flightProgramsManager.ProgramsRepository.GetProgramById(id);
            flightProgramViewModel.Validate(ModelState, string.Empty);
            if (!ModelState.IsValid)
            {
                var viewModel = Mapper.Map<FlightProgram, FlightProgramViewModel>(flightProgram);
                return View(Views.EditFlightProgram, viewModel);
            }
            Mapper.Map<FlightProgramViewModel, FlightProgram>(flightProgramViewModel, flightProgram);
            return this.RedirectToSuccess(MVC.FlightPrograms.EditFlightProgram(id));
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

        [RequireTransaction]
        [AcceptVerbs(HttpVerbs.Get)]
        public virtual ViewResult CreateProgramLocation(int flightProgramId)
        {
            var program = flightProgramsManager.ProgramsRepository.GetProgramById(flightProgramId);
            return View(Views.CreateProgramLocation, new ProgramLocationViewModel() { ProgramId = program.Id.Value, ProgramName = program.Name });
        }

        [RequireTransaction]
        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult CreateProgramLocation(ProgramLocationViewModel programLocationViewModel)
        {
            programLocationViewModel.Validate(ModelState, string.Empty);
            if (!ModelState.IsValid)
                return View(Views.CreateProgramLocation, programLocationViewModel);
            var program = flightProgramsManager.ProgramsRepository.GetProgramById(programLocationViewModel.ProgramId);
            var location = Mapper.Map<ProgramLocationViewModel, ProgramLocation>(programLocationViewModel);
            program.AddLocation(location);
            return RedirectToAction(MVC.FlightPrograms.EditFlightProgram(program.Id.Value));
        }

        [RequireTransaction]
        [AcceptVerbs(HttpVerbs.Get)]
        public virtual ViewResult EditProgramLocation(int id)
        {
            var location = flightProgramsManager.ProgramsRepository.GetProgramLocationById(id);
            var viewModel = Mapper.Map<ProgramLocation, ProgramLocationViewModel>(location);
            return View(Views.EditProgramLocation, viewModel);
        }

        [RequireTransaction]
        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult EditProgramLocation(ProgramLocationViewModel programLocationViewModel)
        {
            var location = flightProgramsManager.ProgramsRepository.GetProgramLocationById(programLocationViewModel.Id.Value);
            programLocationViewModel.Validate(ModelState, string.Empty);
            if (!ModelState.IsValid)
            {
                var viewModel = Mapper.Map<ProgramLocation, ProgramLocationViewModel>(location);
                return View(Views.EditProgramLocation, viewModel);
            }
            Mapper.Map<ProgramLocationViewModel, ProgramLocation>(programLocationViewModel, location);
            return RedirectToAction(MVC.FlightPrograms.EditFlightProgram(programLocationViewModel.ProgramId));
        }
    }
}
