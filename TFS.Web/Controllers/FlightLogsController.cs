using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using TFS.Models.FlightLogs;
using TFS.Web.ViewModels;
using TFS.Models.Reports;
using TFS.Web.ActionFilters;
using System;

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
            var viewModel = new SortedListViewModel<FlightLog>();
            viewModel.SortDirection = sortDirection ?? SortDirection.Ascending;
            viewModel.SortType = sortType;
            var flightLogs = flightLogManager.FlightLogRepository.GetAllFlightLogs();
            if (viewModel.IsCurrentSortType("date") && viewModel.SortDirection == SortDirection.Ascending)
                flightLogs = flightLogs.OrderBy(x => x.LogDate);
            else if (viewModel.IsCurrentSortType("date"))
                flightLogs = flightLogs.OrderByDescending(x => x.LogDate);
            if (viewModel.IsCurrentSortType("aircraft") && viewModel.SortDirection == SortDirection.Ascending)
                flightLogs = flightLogs.OrderBy(x => x.AircraftMDS);
            else if (viewModel.IsCurrentSortType("aircraft"))
                flightLogs = flightLogs.OrderByDescending(x => x.AircraftMDS);
            if (viewModel.IsCurrentSortType("location") && viewModel.SortDirection == SortDirection.Ascending)
                flightLogs = flightLogs.OrderBy(x => x.Location);
            else if (viewModel.IsCurrentSortType("location"))
                flightLogs = flightLogs.OrderByDescending(x => x.Location);
            viewModel.Items = flightLogs;
            return View(Views.List, viewModel);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        [RequireTransaction]
        public virtual ViewResult EditFlightLog(int id)
        {
            var flightLog = flightLogManager.FlightLogRepository.GetFlightLogById(id);
            var viewModel = FlightLogViewModel.CreateFromFlightLog(flightLog);
            viewModel.SavedFlightLog = (bool?)TempData["SavedFlightLog"] ?? false;
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
                var viewModel = FlightLogViewModel.CreateFromFlightLog(flightLog);
                return View(viewModel);
            }
            flightLog.LogDate = flightLogViewModel.FlightLogDate.ToUniversalTime();
            flightLog.AircraftMDS = flightLogViewModel.AircraftMDS;
            flightLog.AircraftSerialNumber = flightLogViewModel.AircraftSerialNumber;
            flightLog.Location = flightLogViewModel.Location;
            flightLog.MarkedUpdated();
            TempData["SavedFlightLog"] = true;
            return RedirectToAction(MVC.FlightLogs.EditFlightLog(id));
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public virtual ViewResult CreateFlightLog()
        {
            return View(new FlightLogViewModel());
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [RequireTransaction]
        public virtual ActionResult CreateFlightLog(FlightLogViewModel flightLog)
        {
            flightLog.Validate(ModelState, string.Empty);
            if (!ModelState.IsValid)
                return View(flightLog);
            var missiongLog = flightLogManager.CreateNewFlightLog(flightLog.FlightLogDate.ToUniversalTime(), flightLog.AircraftMDS, flightLog.AircraftSerialNumber, flightLog.Location);
            return RedirectToAction(MVC.FlightLogs.EditFlightLog(missiongLog.Id.Value));
        }

        [AcceptVerbs(HttpVerbs.Get)]
        [RequireTransaction]
        public virtual ViewResult EditMission(int id)
        {
            var viewModel = new MissionViewModel();
            viewModel.Mission = flightLogManager.FlightLogRepository.GetMissionById(id);
            viewModel.FlightLogId = viewModel.Mission.FlightLog.Id.Value;
            return View(viewModel);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [RequireTransaction]
        public virtual ActionResult EditMission(int id, MissionViewModel missionViewModel)
        {
            var mission = flightLogManager.FlightLogRepository.GetMissionById(id);
            missionViewModel.Validate(ModelState, string.Empty);
            missionViewModel.Mission.Validate(ModelState, "Mission");
            if (!ModelState.IsValid)
            {
                var viewModel = new MissionViewModel();
                viewModel.Mission = mission;
                viewModel.FlightLogId = viewModel.Mission.FlightLog.Id.Value;
                return View(viewModel);
            }
            mission.Name = missionViewModel.Mission.Name;
            mission.AdditionalInfo = missionViewModel.Mission.AdditionalInfo;
            mission.FromICAO = missionViewModel.Mission.FromICAO;
            mission.ToICAO = missionViewModel.Mission.ToICAO;
            mission.TakeOffTime = missionViewModel.Mission.TakeOffTime;
            mission.LandingTime = missionViewModel.Mission.LandingTime;
            mission.TouchAndGos = missionViewModel.Mission.TouchAndGos;
            mission.FullStops = missionViewModel.Mission.FullStops;
            mission.Sorties = missionViewModel.Mission.Sorties;
            mission.Totals = missionViewModel.Mission.Totals;
            mission.MarkedUpdated();
            return RedirectToAction(MVC.FlightLogs.EditFlightLog(missionViewModel.FlightLogId));
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
            missionViewModel.Mission.Validate(ModelState, "Mission");
            if (!ModelState.IsValid)
            {
                return View(missionViewModel);
            }
            var flightLog = flightLogManager.FlightLogRepository.GetFlightLogById(missionViewModel.FlightLogId);
            flightLog.AddMission(missionViewModel.Mission);
            return RedirectToAction(MVC.FlightLogs.EditFlightLog(missionViewModel.FlightLogId));
        }

        [AcceptVerbs(HttpVerbs.Get)]
        [RequireTransaction]
        public virtual ViewResult EditSquadronLog(int id)
        {
            var viewModel = new SquadronLogViewModel();
            viewModel.SquadronLog = flightLogManager.FlightLogRepository.GetSquadronLogById(id);
            viewModel.FlightLogId = viewModel.SquadronLog.FlightLog.Id.Value;
            viewModel.PersonUsername = viewModel.SquadronLog.Person.User.Username;
            viewModel.AvailablePersons = flightLogManager.FlightLogRepository.GetAvailableSquadronPersons();
            return View(viewModel);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [RequireTransaction]
        public virtual ActionResult EditSquadronLog(int id, SquadronLogViewModel squadronLogViewModel)
        {
            var squadronLog = flightLogManager.FlightLogRepository.GetSquadronLogById(id);
            squadronLogViewModel.Validate(ModelState, string.Empty);
            squadronLogViewModel.SquadronLog.Validate(ModelState, "SquadronLog");
            if (!ModelState.IsValid)
            {
                var viewModel = new SquadronLogViewModel();
                viewModel.SquadronLog = squadronLog;
                viewModel.FlightLogId = viewModel.SquadronLog.FlightLog.Id.Value;
                viewModel.PersonUsername = viewModel.SquadronLog.Person.User.Username;
                viewModel.AvailablePersons = flightLogManager.FlightLogRepository.GetAvailableSquadronPersons();
                return View(viewModel);
            }
            squadronLog.Person = flightLogManager.FlightLogRepository.GetSquadronPersonForUsername(squadronLogViewModel.PersonUsername);
            squadronLog.DutyCode = squadronLogViewModel.SquadronLog.DutyCode;
            squadronLog.PrimaryHours = squadronLogViewModel.SquadronLog.PrimaryHours;
            squadronLog.SecondaryHours = squadronLogViewModel.SquadronLog.SecondaryHours;
            squadronLog.InstructorHours = squadronLogViewModel.SquadronLog.InstructorHours;
            squadronLog.EvaluatorHours = squadronLogViewModel.SquadronLog.EvaluatorHours;
            squadronLog.OtherHours = squadronLogViewModel.SquadronLog.OtherHours;
            squadronLog.Sorties = squadronLogViewModel.SquadronLog.Sorties;
            squadronLog.PrimaryNightHours = squadronLogViewModel.SquadronLog.PrimaryNightHours;
            squadronLog.PrimaryInstrumentHours = squadronLogViewModel.SquadronLog.PrimaryInstrumentHours;
            squadronLog.SimulatedInstrumentHours = squadronLogViewModel.SquadronLog.SimulatedInstrumentHours;
            squadronLog.MarkedUpdated();
            return RedirectToAction(MVC.FlightLogs.EditFlightLog(squadronLogViewModel.FlightLogId));
        }

        [AcceptVerbs(HttpVerbs.Get)]
        [RequireTransaction]
        public virtual ViewResult CreateSquadronLog(int flightLogId)
        {
            var viewModel = new SquadronLogViewModel();
            viewModel.FlightLogId = flightLogId;
            viewModel.SetAvailablePersons(flightLogManager.FlightLogRepository.GetAvailableSquadronPersons());
            return View(viewModel);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [RequireTransaction]
        public virtual ActionResult CreateSquadronLog(SquadronLogViewModel squadronLogViewModel)
        {
            squadronLogViewModel.Validate(ModelState, string.Empty);
            squadronLogViewModel.SquadronLog.Validate(ModelState, "SquadronLog");
            if (!ModelState.IsValid)
            {
                squadronLogViewModel.SetAvailablePersons(flightLogManager.FlightLogRepository.GetAvailableSquadronPersons());
                return View(squadronLogViewModel);
            }
            CreateNewSquadronLog(squadronLogViewModel);
            return RedirectToAction(MVC.FlightLogs.EditFlightLog(squadronLogViewModel.FlightLogId));
        }

        

        [AcceptVerbs(HttpVerbs.Get)]
        [RequireTransaction]
        public virtual ViewResult BulkCreateSquadronLog(int flightLogId)
        {
            var viewModel = CreateSquadronLogListViewModel(flightLogId);
            return View(Views.BulkCreateSquadronLog, viewModel);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [RequireTransaction]
        public virtual ActionResult BulkCreateSquadronLog(SquadronLogViewModel squadronLogViewModel)
        {
            squadronLogViewModel.Validate(ModelState, string.Empty);
            squadronLogViewModel.SquadronLog.Validate(ModelState, "SquadronLog");
            if (!ModelState.IsValid)
            {
                var viewModel = CreateSquadronLogListViewModel(squadronLogViewModel.FlightLogId);
                viewModel.CurrentSquadronLog = squadronLogViewModel;
                return View(Views.BulkCreateSquadronLog, viewModel);
            }
            CreateNewSquadronLog(squadronLogViewModel);
            return RedirectToAction(MVC.FlightLogs.BulkCreateSquadronLog(squadronLogViewModel.FlightLogId));
        }

        [RequireTransaction]
        public virtual FileContentResult DownloadPDF(int id)
        {
            var flightLog = flightLogManager.FlightLogRepository.GetFlightLogById(id);
            var reportGenerator = new PdfReportGenerator(new FlightTimeSummaryReport(flightLog));
            var bytes = reportGenerator.GenerateReport();
            return File(bytes, "application/pdf", "FlightTimeSummary(" + flightLog.LogDate.ToString("MM-dd-yy") + ").pdf");
        }

        private SquadronLogListViewModel CreateSquadronLogListViewModel(int flightLogId)
        {
            var viewModel = new SquadronLogListViewModel();
            viewModel.FlightLog = flightLogManager.FlightLogRepository.GetFlightLogById(flightLogId);
            viewModel.Items = viewModel.FlightLog.SquadronLogs;
            viewModel.CurrentSquadronLog = new SquadronLogViewModel
            {
                FlightLogId = viewModel.FlightLog.Id.Value,
            };
            viewModel.CurrentSquadronLog.SetAvailablePersons(flightLogManager.FlightLogRepository.GetAvailableSquadronPersons());
            return viewModel;
        }

        private void CreateNewSquadronLog(SquadronLogViewModel squadronLogViewModel)
        {
            var flightLog = flightLogManager.FlightLogRepository.GetFlightLogById(squadronLogViewModel.FlightLogId);
            squadronLogViewModel.SquadronLog.Person = flightLogManager.FlightLogRepository.GetSquadronPersonForUsername(squadronLogViewModel.PersonUsername);
            flightLog.AddSquadronLog(squadronLogViewModel.SquadronLog);
        }
    }
}
