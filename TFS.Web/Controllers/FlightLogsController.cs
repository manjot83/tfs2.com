using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using TFS.Models.FlightLogs;
using TFS.Web.ViewModels;
using TFS.Models.Reports;
using System;
using TFS.Web.ViewModels.FlightLogs;
using AutoMapper;
using System.Collections.Generic;
using TFS.Models.FlightPrograms;
using TFS.Models;
using NHibernate;

namespace TFS.Web.Controllers
{
    [Authorize]
    public partial class FlightLogsController : Controller
    {
        private readonly ISession session;
        private readonly IFlightLogRepository flightLogRepository;
        private readonly IFlightProgramsRepository flightProgramsRepository;

        public FlightLogsController(ISession session, 
                                    IFlightLogRepository flightLogRepository,
                                    IFlightProgramsRepository flightProgramsRepository)
        {
            this.session = session;
            this.flightLogRepository = flightLogRepository;
            this.flightProgramsRepository = flightProgramsRepository;
        }

        public virtual ViewResult Index()
        {
            return List(null, null);
        }

        public virtual ViewResult List(string sortType, SortDirection? sortDirection)
        {
            if (string.IsNullOrEmpty(sortType))
                sortType = "date";
            if (sortDirection == null)
                sortDirection = SortDirection.Descending;
            var viewModel = new SortedListViewModel<FlightLogListItemViewModel>();
            viewModel.SortDirection = sortDirection ?? SortDirection.Ascending;
            viewModel.SortType = sortType;
            var flightLogs = flightLogRepository.GetAllFlightLogs();
            var viewModelItems = Mapper.Map<IEnumerable<FlightLog>, IEnumerable<FlightLogListItemViewModel>>(flightLogs.ToList());
            if (viewModel.IsCurrentSortType("date") && viewModel.SortDirection == SortDirection.Ascending)
                viewModelItems = viewModelItems.OrderBy(x => x.LogDate);
            else if (viewModel.IsCurrentSortType("date"))
                viewModelItems = viewModelItems.OrderByDescending(x => x.LogDate);
            if (viewModel.IsCurrentSortType("aircraft") && viewModel.SortDirection == SortDirection.Ascending)
                viewModelItems = viewModelItems.OrderBy(x => x.AircraftMDS);
            else if (viewModel.IsCurrentSortType("aircraft"))
                viewModelItems = viewModelItems.OrderByDescending(x => x.AircraftMDS);
            if (viewModel.IsCurrentSortType("program") && viewModel.SortDirection == SortDirection.Ascending)
                viewModelItems = viewModelItems.OrderBy(x => x.Program);
            else if (viewModel.IsCurrentSortType("program"))
                viewModelItems = viewModelItems.OrderByDescending(x => x.Program);
            if (viewModel.IsCurrentSortType("location") && viewModel.SortDirection == SortDirection.Ascending)
                viewModelItems = viewModelItems.OrderBy(x => x.Location);
            else if (viewModel.IsCurrentSortType("location"))
                viewModelItems = viewModelItems.OrderByDescending(x => x.Location);
            viewModel.Items = viewModelItems.ToList();
            return View(Views.List, viewModel);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public virtual ViewResult EditFlightLog(int id)
        {
            var flightLog = session.Get<FlightLog>(id);
            var viewModel = CreateFlightLogViewModel(flightLog);
            viewModel.PreviouslySaved = (bool?)TempData["SavedFlightLog"] ?? false;
            return View(viewModel);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult EditFlightLog(int id, FlightLogViewModel flightLogViewModel)
        {
            var flightLog = session.Get<FlightLog>(id);
            this.Validate(flightLogViewModel, string.Empty);
            if (!ModelState.IsValid)
            {
                var viewModel = CreateFlightLogViewModel(flightLog);
                return View(viewModel);
            }
            Mapper.Map<FlightLogViewModel, FlightLog>(flightLogViewModel, flightLog);
            flightLog.Location = session.Get<ProgramLocation>(flightLogViewModel.LocationId);
            flightLog.MarkedUpdated();
            TempData["SavedFlightLog"] = true;
            return RedirectToAction(MVC.FlightLogs.EditFlightLog(id));
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public virtual ViewResult CreateFlightLog()
        {
            return View(CreateFlightLogViewModel(null));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult CreateFlightLog(FlightLogViewModel flightLogViewModel)
        {
            this.Validate(flightLogViewModel, string.Empty);
            if (!ModelState.IsValid)
                return View(CreateFlightLogViewModel(null));
            var flightLog = Mapper.Map<FlightLogViewModel, FlightLog>(flightLogViewModel);
            flightLog.Location = session.Get<ProgramLocation>(flightLogViewModel.LocationId);
            flightLog = flightLogRepository.AddFlightLog(flightLog);
            return RedirectToAction(MVC.FlightLogs.EditFlightLog(flightLog.Id.Value));
        }

        [NonAction]
        private FlightLogViewModel CreateFlightLogViewModel(FlightLog flightLog)
        {
            var viewModel = new FlightLogViewModel();
            var activeLocations = flightProgramsRepository.GetAllActiveProgramLocations();
            if (flightLog != null)
            {
                Mapper.Map<FlightLog, FlightLogViewModel>(flightLog, viewModel);
                activeLocations = activeLocations.Union(new ProgramLocation[] { flightLog.Location });
            }
            viewModel.SetActiveLocations(activeLocations);
            return viewModel;
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public virtual ViewResult EditMission(int id)
        {
            var mission = session.Get<Mission>(id);
            var viewModel = Mapper.Map<Mission, MissionViewModel>(mission);
            return View(viewModel);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult EditMission(int id, MissionViewModel missionViewModel)
        {
            var mission = session.Get<Mission>(id);
            this.Validate(missionViewModel, string.Empty);
            if (!ModelState.IsValid)
            {
                var viewModel = Mapper.Map<Mission, MissionViewModel>(mission);
                return View(viewModel);
            }
            Mapper.Map<MissionViewModel, Mission>(missionViewModel, mission);
            mission.MarkedUpdated();
            return RedirectToAction(MVC.FlightLogs.EditFlightLog(missionViewModel.FlightLogId.Value));
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public virtual ViewResult CreateMission(int flightLogId)
        {
            return View(new MissionViewModel { FlightLogId = flightLogId });
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult CreateMission(MissionViewModel missionViewModel)
        {
            this.Validate(missionViewModel, string.Empty);
            if (!ModelState.IsValid)
            {
                return View(missionViewModel);
            }
            var flightLog = session.Get<FlightLog>(missionViewModel.FlightLogId);
            var mission = Mapper.Map<MissionViewModel, Mission>(missionViewModel);
            flightLog.AddMission(mission);
            return RedirectToAction(MVC.FlightLogs.EditFlightLog(missionViewModel.FlightLogId.Value));
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public virtual ViewResult EditSquadronLog(int id)
        {
            var squadronLog = session.Get<SquadronLog>(id);
            var viewModel = CreateSquadronLogViewModel(squadronLog);
            return View(viewModel);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult EditSquadronLog(int id, SquadronLogViewModel squadronLogViewModel)
        {
            var squadronLog = session.Get<SquadronLog>(id);
            this.Validate(squadronLogViewModel, string.Empty);
            if (!ModelState.IsValid)
            {
                var viewModel = CreateSquadronLogViewModel(squadronLog);
                return View(viewModel);
            }
            Mapper.Map<SquadronLogViewModel, SquadronLog>(squadronLogViewModel, squadronLog);
            squadronLog.Person = this.GetUser(squadronLogViewModel.PersonUsername).Person;
            squadronLog.MarkedUpdated();
            return RedirectToAction(MVC.FlightLogs.EditFlightLog(squadronLogViewModel.FlightLogId.Value));
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public virtual ViewResult CreateSquadronLog(int flightLogId)
        {
            var viewModel = CreateSquadronLogViewModel(null);
            viewModel.FlightLogId = flightLogId;
            return View(viewModel);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult CreateSquadronLog(SquadronLogViewModel squadronLogViewModel)
        {
            this.Validate(squadronLogViewModel, string.Empty);
            if (!ModelState.IsValid)
            {
                var viewModel = CreateSquadronLogViewModel(null);
                viewModel.FlightLogId = squadronLogViewModel.FlightLogId.Value;
                return View(viewModel);
            }
            var flightLog = session.Get<FlightLog>(squadronLogViewModel.FlightLogId.Value);
            var squadronLog = Mapper.Map<SquadronLogViewModel, SquadronLog>(squadronLogViewModel);
            squadronLog.Person = this.GetUser(squadronLogViewModel.PersonUsername).Person;
            flightLog.AddSquadronLog(squadronLog);
            return RedirectToAction(MVC.FlightLogs.EditFlightLog(squadronLogViewModel.FlightLogId.Value));
        }

        private SquadronLogViewModel CreateSquadronLogViewModel(SquadronLog squadronLog)
        {
            var viewModel = new SquadronLogViewModel();
            if (squadronLog != null)
            {
                Mapper.Map<SquadronLog, SquadronLogViewModel>(squadronLog, viewModel);
            }
            viewModel.SetAvailablePersons(this.GetUserRepository().GetAllActivePersons());
            return viewModel;
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public virtual ViewResult BulkCreateSquadronLog(int flightLogId)
        {
            var viewModel = CreateSquadronLogListViewModel(flightLogId, null);
            return View(Views.BulkCreateSquadronLog, viewModel);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult BulkCreateSquadronLog(SquadronLogViewModel squadronLogViewModel)
        {
            this.Validate(squadronLogViewModel, string.Empty);
            if (!ModelState.IsValid)
            {
                var viewModel = CreateSquadronLogListViewModel(squadronLogViewModel.FlightLogId.Value, squadronLogViewModel);
                return View(Views.BulkCreateSquadronLog, viewModel);
            }
            var flightLog = session.Get<FlightLog>(squadronLogViewModel.FlightLogId.Value);
            var squadronLog = Mapper.Map<SquadronLogViewModel, SquadronLog>(squadronLogViewModel);
            squadronLog.Person = this.GetUser(squadronLogViewModel.PersonUsername).Person;
            flightLog.AddSquadronLog(squadronLog);
            return RedirectToAction(MVC.FlightLogs.BulkCreateSquadronLog(squadronLogViewModel.FlightLogId.Value));
        }

        [NonAction]
        private SquadronLogListViewModel CreateSquadronLogListViewModel(int flightLogId, SquadronLogViewModel squadronLogViewModel)
        {
            var viewModel = new SquadronLogListViewModel();
            var flightLog = session.Get<FlightLog>(flightLogId);
            viewModel.FlightLog = Mapper.Map<FlightLog, FlightLogListItemViewModel>(flightLog);
            var squadronLogs = flightLog.SquadronLogs;
            viewModel.Items = Mapper.Map<IEnumerable<SquadronLog>, IEnumerable<SquadronLogViewModel>>(squadronLogs.ToList());
            viewModel.CurrentSquadronLog = squadronLogViewModel;
            if (squadronLogViewModel == null)
                viewModel.CurrentSquadronLog = new SquadronLogViewModel() { FlightLogId = flightLogId };
            viewModel.CurrentSquadronLog.SetAvailablePersons(this.GetUserRepository().GetAllActivePersons());
            return viewModel;
        }

        public virtual FileContentResult DownloadPDF(int id)
        {
            var flightLog = session.Get<FlightLog>(id);
            var reportGenerator = new PdfReportGenerator(new FlightTimeSummaryReport(flightLog));
            var bytes = reportGenerator.GenerateReport();
            return File(bytes, "application/pdf", "FlightTimeSummary(" + flightLog.LogDate.ToString("MM-dd-yy") + ").pdf");
        }
    }
}
