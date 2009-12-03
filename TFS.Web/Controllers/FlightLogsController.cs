using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using TFS.Models.FlightLogs;
using TFS.Web.ViewModels;
using TFS.Models.Reports;
using TFS.Web.ActionFilters;
using System;
using TFS.Web.ViewModels.FlightLogs;
using AutoMapper;
using System.Collections.Generic;
using TFS.Models.FlightPrograms;

namespace TFS.Web.Controllers
{
    [DomainAuthorize]
    public partial class FlightLogsController : Controller
    {
        private readonly FlightLogManager flightLogManager;

        public FlightLogsController(FlightLogManager flightLogManager)
        {
            this.flightLogManager = flightLogManager;
        }

        [RequireTransaction]
        public virtual ViewResult Index()
        {
            return List(null, null);
        }

        [RequireTransaction]
        public virtual ViewResult List(string sortType, SortDirection? sortDirection)
        {
            if (string.IsNullOrEmpty(sortType))
                sortType = "date";
            if (sortDirection == null)
                sortDirection = SortDirection.Descending;
            var viewModel = new SortedListViewModel<FlightLogListItemViewModel>();
            viewModel.SortDirection = sortDirection ?? SortDirection.Ascending;
            viewModel.SortType = sortType;
            var flightLogs = flightLogManager.FlightLogRepository.GetAllFlightLogs();
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
        [RequireTransaction]
        public virtual ViewResult EditFlightLog(int id)
        {
            var flightLog = flightLogManager.FlightLogRepository.GetFlightLogById(id);
            var viewModel = CreateFlightLogViewModel(flightLog);
            viewModel.PreviouslySaved = (bool?)TempData["SavedFlightLog"] ?? false;
            return View(viewModel);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [RequireTransaction]
        public virtual ActionResult EditFlightLog(int id, FlightLogViewModel flightLogViewModel)
        {
            var flightLog = flightLogManager.FlightLogRepository.GetFlightLogById(id);
            flightLogViewModel.Validate(ModelState, string.Empty);
            if (!ModelState.IsValid)
            {
                var viewModel = CreateFlightLogViewModel(flightLog);
                return View(viewModel);
            }
            Mapper.Map<FlightLogViewModel, FlightLog>(flightLogViewModel, flightLog);
            flightLog.Location = flightLogManager.FlightProgramsRepository.GetProgramLocationById(flightLogViewModel.LocationId);
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
        [RequireTransaction]
        public virtual ActionResult CreateFlightLog(FlightLogViewModel flightLogViewModel)
        {
            flightLogViewModel.Validate(ModelState, string.Empty);
            if (!ModelState.IsValid)
                return View(CreateFlightLogViewModel(null));
            var flightLog = Mapper.Map<FlightLogViewModel, FlightLog>(flightLogViewModel);
            flightLog.Location = flightLogManager.FlightProgramsRepository.GetProgramLocationById(flightLogViewModel.LocationId);
            flightLog = flightLogManager.AddFlightLog(flightLog);
            return RedirectToAction(MVC.FlightLogs.EditFlightLog(flightLog.Id.Value));
        }

        [NonAction]
        private FlightLogViewModel CreateFlightLogViewModel(FlightLog flightLog)
        {
            var viewModel = new FlightLogViewModel();
            var activeLocations = flightLogManager.FlightProgramsRepository.GetAllActiveProgramLocations();
            if (flightLog != null)
            {
                Mapper.Map<FlightLog, FlightLogViewModel>(flightLog, viewModel);
                activeLocations = activeLocations.Union(new ProgramLocation[] { flightLog.Location });
            }
            viewModel.SetActiveLocations(activeLocations);
            return viewModel;
        }

        [AcceptVerbs(HttpVerbs.Get)]
        [RequireTransaction]
        public virtual ViewResult EditMission(int id)
        {
            var mission = flightLogManager.FlightLogRepository.GetMissionById(id);
            var viewModel = Mapper.Map<Mission, MissionViewModel>(mission);
            return View(viewModel);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [RequireTransaction]
        public virtual ActionResult EditMission(int id, MissionViewModel missionViewModel)
        {
            var mission = flightLogManager.FlightLogRepository.GetMissionById(id);
            missionViewModel.Validate(ModelState, string.Empty);
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
        [RequireTransaction]
        public virtual ActionResult CreateMission(MissionViewModel missionViewModel)
        {
            missionViewModel.Validate(ModelState, string.Empty);
            if (!ModelState.IsValid)
            {
                return View(missionViewModel);
            }
            var flightLog = flightLogManager.FlightLogRepository.GetFlightLogById(missionViewModel.FlightLogId.Value);
            var mission = Mapper.Map<MissionViewModel, Mission>(missionViewModel);
            flightLog.AddMission(mission);
            return RedirectToAction(MVC.FlightLogs.EditFlightLog(missionViewModel.FlightLogId.Value));
        }

        [AcceptVerbs(HttpVerbs.Get)]
        [RequireTransaction]
        public virtual ViewResult EditSquadronLog(int id)
        {
            var squadronLog = flightLogManager.FlightLogRepository.GetSquadronLogById(id);
            var viewModel = Mapper.Map<SquadronLog, SquadronLogViewModel>(squadronLog);
            viewModel.SetAvailablePersons(flightLogManager.FlightLogRepository.GetAvailableSquadronPersons());
            return View(viewModel);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [RequireTransaction]
        public virtual ActionResult EditSquadronLog(int id, SquadronLogViewModel squadronLogViewModel)
        {
            var squadronLog = flightLogManager.FlightLogRepository.GetSquadronLogById(id);
            squadronLogViewModel.Validate(ModelState, string.Empty);
            if (!ModelState.IsValid)
            {
                var viewModel = Mapper.Map<SquadronLog, SquadronLogViewModel>(squadronLog);
                viewModel.SetAvailablePersons(flightLogManager.FlightLogRepository.GetAvailableSquadronPersons());
                return View(viewModel);
            }
            Mapper.Map<SquadronLogViewModel, SquadronLog>(squadronLogViewModel, squadronLog);
            squadronLog.Person = flightLogManager.FlightLogRepository.GetSquadronPersonForUsername(squadronLogViewModel.PersonUsername);
            squadronLog.MarkedUpdated();
            return RedirectToAction(MVC.FlightLogs.EditFlightLog(squadronLogViewModel.FlightLogId.Value));
        }

        [AcceptVerbs(HttpVerbs.Get)]
        [RequireTransaction]
        public virtual ViewResult CreateSquadronLog(int flightLogId)
        {
            var viewModel = new SquadronLogViewModel() { FlightLogId = flightLogId };
            viewModel.SetAvailablePersons(flightLogManager.FlightLogRepository.GetAvailableSquadronPersons());
            return View(viewModel);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [RequireTransaction]
        public virtual ActionResult CreateSquadronLog(SquadronLogViewModel squadronLogViewModel)
        {
            squadronLogViewModel.Validate(ModelState, string.Empty);
            if (!ModelState.IsValid)
            {
                squadronLogViewModel.SetAvailablePersons(flightLogManager.FlightLogRepository.GetAvailableSquadronPersons());
                return View(squadronLogViewModel);
            }
            var flightLog = flightLogManager.FlightLogRepository.GetFlightLogById(squadronLogViewModel.FlightLogId.Value);
            var squadronLog = Mapper.Map<SquadronLogViewModel, SquadronLog>(squadronLogViewModel);
            squadronLog.Person = flightLogManager.FlightLogRepository.GetSquadronPersonForUsername(squadronLogViewModel.PersonUsername);
            flightLog.AddSquadronLog(squadronLog);
            return RedirectToAction(MVC.FlightLogs.EditFlightLog(squadronLogViewModel.FlightLogId.Value));
        }

        [AcceptVerbs(HttpVerbs.Get)]
        [RequireTransaction]
        public virtual ViewResult BulkCreateSquadronLog(int flightLogId)
        {
            var viewModel = CreateSquadronLogListViewModel(flightLogId, null);
            return View(Views.BulkCreateSquadronLog, viewModel);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [RequireTransaction]
        public virtual ActionResult BulkCreateSquadronLog(SquadronLogViewModel squadronLogViewModel)
        {
            squadronLogViewModel.Validate(ModelState, string.Empty);
            if (!ModelState.IsValid)
            {
                var viewModel = CreateSquadronLogListViewModel(squadronLogViewModel.FlightLogId.Value, squadronLogViewModel);
                return View(Views.BulkCreateSquadronLog, viewModel);
            }
            var flightLog = flightLogManager.FlightLogRepository.GetFlightLogById(squadronLogViewModel.FlightLogId.Value);
            var squadronLog = Mapper.Map<SquadronLogViewModel, SquadronLog>(squadronLogViewModel);
            squadronLog.Person = flightLogManager.FlightLogRepository.GetSquadronPersonForUsername(squadronLogViewModel.PersonUsername);
            flightLog.AddSquadronLog(squadronLog);
            return RedirectToAction(MVC.FlightLogs.BulkCreateSquadronLog(squadronLogViewModel.FlightLogId.Value));
        }

        [NonAction]
        private SquadronLogListViewModel CreateSquadronLogListViewModel(int flightLogId, SquadronLogViewModel squadronLogViewModel)
        {
            var viewModel = new SquadronLogListViewModel();
            var flightLog = flightLogManager.FlightLogRepository.GetFlightLogById(flightLogId);
            viewModel.FlightLog = Mapper.Map<FlightLog, FlightLogListItemViewModel>(flightLog);
            var squadronLogs = flightLog.SquadronLogs;
            viewModel.Items = Mapper.Map<IEnumerable<SquadronLog>, IEnumerable<SquadronLogViewModel>>(squadronLogs.ToList());
            viewModel.CurrentSquadronLog = squadronLogViewModel;
            if (squadronLogViewModel == null)
                viewModel.CurrentSquadronLog = new SquadronLogViewModel() { FlightLogId = flightLogId };
            viewModel.CurrentSquadronLog.SetAvailablePersons(flightLogManager.FlightLogRepository.GetAvailableSquadronPersons());
            return viewModel;
        }

        [RequireTransaction]
        public virtual FileContentResult DownloadPDF(int id)
        {
            var flightLog = flightLogManager.FlightLogRepository.GetFlightLogById(id);
            var reportGenerator = new PdfReportGenerator(new FlightTimeSummaryReport(flightLog));
            var bytes = reportGenerator.GenerateReport();
            return File(bytes, "application/pdf", "FlightTimeSummary(" + flightLog.LogDate.ToString("MM-dd-yy") + ").pdf");
        }
    }
}
