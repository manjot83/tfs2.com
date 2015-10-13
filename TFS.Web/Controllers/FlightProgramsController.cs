using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using TFS.Models.FlightPrograms;
using TFS.Web.ViewModels.FlightPrograms;
using TFS.Web.ViewModels;
using AutoMapper;
using NHibernate;
using TFS.Models;

namespace TFS.Web.Controllers
{
    [Authorize]
    public partial class FlightProgramsController : BaseController
    {
        private readonly IFlightProgramsRepository flightProgramsRepository;

        public FlightProgramsController(IApplicationSettings applicationSettings, IFlightProgramsRepository flightProgramsRepository)
            :base(applicationSettings, flightProgramsRepository)
        {
            this.flightProgramsRepository = flightProgramsRepository;
        }

        public virtual ViewResult Index()
        {
            return Manage(null);
        }

        public virtual ViewResult Manage(bool? showAllPrograms)
        {
            var viewModel = new DashboardViewModel()
            {
                ShowAllPrograms = showAllPrograms.HasValue && showAllPrograms.Value,
            };
            IEnumerable<FlightProgram> programs = null;
            IEnumerable<AircraftMDS> aircraft = null;

            if (viewModel.ShowAllPrograms)
                programs = flightProgramsRepository.GetAllPrograms();
            else
                programs = flightProgramsRepository.GetAllActivePrograms();

            if (viewModel.ShowAllPrograms)
                aircraft = flightProgramsRepository.GetAllAircrafts();
            else
                aircraft = flightProgramsRepository.GetAllActiveAircraftMds();

            var positions = flightProgramsRepository.GetAllPositions();

            viewModel.Aircrafts = Mapper.Map<IEnumerable<AircraftMDS>, IEnumerable<AircraftViewModel>>(aircraft);
            viewModel.Positions = Mapper.Map<IEnumerable<Position>, IEnumerable<PositionViewModel>>(positions);
            viewModel.FlightPrograms = Mapper.Map<IEnumerable<FlightProgram>, IEnumerable<FlightProgramListItemViewModel>>(programs);
            return View(Views.Manage, viewModel);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public virtual ViewResult CreateFlightProgram()
        {
            return View(Views.CreateFlightProgram, new FlightProgramViewModel());
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult CreateFlightProgram(FlightProgramViewModel flightProgramViewModel)
        {
            this.Validate(flightProgramViewModel, string.Empty);
            if (!ModelState.IsValid)
                return View(Views.CreateFlightProgram, flightProgramViewModel);
            var flightProgram = Mapper.Map<FlightProgramViewModel, FlightProgram>(flightProgramViewModel);
            flightProgram = flightProgramsRepository.AddNewFlightProgram(flightProgram);
            return RedirectToAction(MVC.FlightPrograms.EditFlightProgram(flightProgram.Id.Value));
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public virtual ViewResult EditFlightProgram(Guid id)
        {
            var flightProgram = Repository.Get<FlightProgram>(id);
            var viewModel = Mapper.Map<FlightProgram, FlightProgramViewModel>(flightProgram);
            return View(Views.EditFlightProgram, viewModel);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult EditFlightProgram(Guid id, FlightProgramViewModel flightProgramViewModel)
        {
            var flightProgram = Repository.Get<FlightProgram>(id);
            this.Validate(flightProgramViewModel, string.Empty);
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

        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult CreatePosition(PositionViewModel positionViewModel)
        {
            this.Validate(positionViewModel, string.Empty);
            if (!ModelState.IsValid)
                return View(Views.CreatePosition, positionViewModel);
            flightProgramsRepository.AddNewPosition(positionViewModel.Title);
            return RedirectToAction(MVC.FlightPrograms.Manage());
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public virtual ViewResult CreateAircraft()
        {
            return View(Views.CreateAircraft, new AircraftViewModel());
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult CreateAircraft(AircraftViewModel aircraftViewModel)
        {
            this.Validate(aircraftViewModel, string.Empty);
            if (!ModelState.IsValid)
                return View(Views.CreateAircraft, aircraftViewModel);
            flightProgramsRepository.AddNewAircraftMds(aircraftViewModel.Name);
            return RedirectToAction(MVC.FlightPrograms.Manage());
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public virtual ViewResult RenamePosition(Guid id)
        {
            var position = Repository.Get<Position>(id);
            var viewModel = Mapper.Map<Position, PositionViewModel>(position);
            return View(Views.EditPosition, viewModel);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult RenamePosition(Guid id, PositionViewModel positionViewModel)
        {
            var position = Repository.Get<Position>(id);
            this.Validate(positionViewModel, string.Empty);            
            if (!ModelState.IsValid)
            {
                var viewModel = Mapper.Map<Position, PositionViewModel>(position);
                return View(Views.EditPosition, viewModel);
            }
            Mapper.Map<PositionViewModel, Position>(positionViewModel, position);
            return RedirectToAction(MVC.FlightPrograms.Manage());
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public virtual ViewResult EditAircraft(Guid id)
        {
            var aircraft = Repository.Get<AircraftMDS>(id);
            var viewModel = Mapper.Map<AircraftMDS, AircraftViewModel>(aircraft);
            return View(Views.EditAircraft, viewModel);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult EditAircraft(Guid id, AircraftViewModel aircraftViewModel)
        {
            var aircraft = Repository.Get<AircraftMDS>(id);
            this.Validate(aircraftViewModel, string.Empty);
            if (!ModelState.IsValid)
            {
                var viewModel = Mapper.Map<AircraftMDS, AircraftViewModel>(aircraft);
                return View(Views.EditAircraft, viewModel);
            }
            Mapper.Map<AircraftViewModel, AircraftMDS>(aircraftViewModel, aircraft);
            return RedirectToAction(MVC.FlightPrograms.Manage());
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public virtual ViewResult CreateProgramLocation(Guid flightProgramId)
        {
            var program = Repository.Get<FlightProgram>(flightProgramId);
            return View(Views.CreateProgramLocation, new ProgramLocationViewModel() { ProgramId = program.Id.Value, ProgramName = program.Name });
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult CreateProgramLocation(ProgramLocationViewModel programLocationViewModel)
        {
            this.Validate(programLocationViewModel, string.Empty);
            if (!ModelState.IsValid)
                return View(Views.CreateProgramLocation, programLocationViewModel);
            var program = Repository.Get<FlightProgram>(programLocationViewModel.ProgramId);
            var location = Mapper.Map<ProgramLocationViewModel, ProgramLocation>(programLocationViewModel);
            program.AddLocation(location);
            return RedirectToAction(MVC.FlightPrograms.EditFlightProgram(program.Id.Value));
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public virtual ViewResult EditProgramLocation(Guid id)
        {
            var location = Repository.Get<ProgramLocation>(id);
            var viewModel = Mapper.Map<ProgramLocation, ProgramLocationViewModel>(location);
            return View(Views.EditProgramLocation, viewModel);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult EditProgramLocation(ProgramLocationViewModel programLocationViewModel)
        {
            var location = Repository.Get<ProgramLocation>(programLocationViewModel.Id.Value);
            this.Validate(programLocationViewModel, string.Empty);
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
