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
    [Authorize]
    public partial class FlightLogsController : Controller
    {
        private readonly IFlightLogManager flightLogManager;

        public FlightLogsController(IFlightLogManager flightLogManager)
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
            var viewModel = new SortedListViewModel<MissionLog>();
            viewModel.SortDirection = sortDirection ?? SortDirection.Ascending;
            viewModel.SortType = sortType;
            var missionLogs = flightLogManager.GetAllMissionLogs();
            if (viewModel.IsCurrentSortType("date") && viewModel.SortDirection == SortDirection.Ascending)
                missionLogs = missionLogs.OrderBy(x => x.LogDate);
            else if (viewModel.IsCurrentSortType("date"))
                missionLogs = missionLogs.OrderByDescending(x => x.LogDate);
            if (viewModel.IsCurrentSortType("aircraft") && viewModel.SortDirection == SortDirection.Ascending)
                missionLogs = missionLogs.OrderBy(x => x.AircraftMDS);
            else if (viewModel.IsCurrentSortType("aircraft"))
                missionLogs = missionLogs.OrderByDescending(x => x.AircraftMDS);
            if (viewModel.IsCurrentSortType("location") && viewModel.SortDirection == SortDirection.Ascending)
                missionLogs = missionLogs.OrderBy(x => x.Location);
            else if (viewModel.IsCurrentSortType("location"))
                missionLogs = missionLogs.OrderByDescending(x => x.Location);
            viewModel.Items = missionLogs;
            return View(Views.List, viewModel);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        [RequireTransaction]
        public virtual ViewResult EditMissionLog(int id)
        {
            var missionLog = flightLogManager.GetMissionLog(id);
            var viewModel = FlightLogViewModel.CreateFromMissionLog(missionLog);
            viewModel.SavedMissionLog = (bool?)TempData["SavedMissionLog"] ?? false;
            return View(viewModel);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [RequireTransaction]
        public virtual ActionResult EditMissionLog(int id, FlightLogViewModel flightLog)
        {
            var missionLog = flightLogManager.GetMissionLog(id);
            flightLog.Validate(ModelState, string.Empty);
            if (!ModelState.IsValid)
            {
                var viewModel = FlightLogViewModel.CreateFromMissionLog(missionLog);
                return View(viewModel);
            }
            missionLog.LogDate = flightLog.MissionLogDate.ToUniversalTime();
            missionLog.AircraftMDS = flightLog.AircraftMDS;
            missionLog.AircraftSerialNumber = flightLog.AircraftSerialNumber;
            missionLog.Location = flightLog.Location;
            missionLog.MarkedUpdated();
            TempData["SavedMissionLog"] = true;
            return RedirectToAction(MVC.FlightLogs.EditMissionLog(id));
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public virtual ViewResult CreateMissionLog()
        {
            return View(new FlightLogViewModel());
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [RequireTransaction]
        public virtual ActionResult CreateMissionLog(FlightLogViewModel flightLog)
        {
            flightLog.Validate(ModelState, string.Empty);
            if (!ModelState.IsValid)
                return View(flightLog);
            var missiongLog = flightLogManager.CreateNewMissionLog(flightLog.MissionLogDate.ToUniversalTime(), flightLog.AircraftMDS, flightLog.AircraftSerialNumber, flightLog.Location);
            return RedirectToAction(MVC.FlightLogs.EditMissionLog(missiongLog.Id.Value));
        }

        [AcceptVerbs(HttpVerbs.Get)]
        [RequireTransaction]
        public virtual ViewResult EditMission(int id)
        {
            var viewModel = new MissionViewModel();
            viewModel.Mission = flightLogManager.GetMission(id);
            viewModel.MissionLogId = viewModel.Mission.MissionLog.Id.Value;
            return View(viewModel);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [RequireTransaction]
        public virtual ActionResult EditMission(int id, MissionViewModel missionViewModel)
        {
            var mission = flightLogManager.GetMission(id);
            missionViewModel.Validate(ModelState, string.Empty);
            missionViewModel.Mission.Validate(ModelState, "Mission");
            if (!ModelState.IsValid)
            {
                var viewModel = new MissionViewModel();
                viewModel.Mission = mission;
                viewModel.MissionLogId = viewModel.Mission.MissionLog.Id.Value;
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
            return RedirectToAction(MVC.FlightLogs.EditMissionLog(missionViewModel.MissionLogId));
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public virtual ViewResult CreateMission(int missionLogId)
        {
            return View(new MissionViewModel { MissionLogId = missionLogId });
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
            var missionLog = flightLogManager.GetMissionLog(missionViewModel.MissionLogId);
            missionLog.AddMission(missionViewModel.Mission);
            return RedirectToAction(MVC.FlightLogs.EditMissionLog(missionViewModel.MissionLogId));
        }

        [AcceptVerbs(HttpVerbs.Get)]
        [RequireTransaction]
        public virtual ViewResult EditSquadronLog(int id)
        {
            var viewModel = new SquadronLogViewModel();
            viewModel.SquadronLog = flightLogManager.GetSquadronLog(id);
            viewModel.MissionLogId = viewModel.SquadronLog.MissionLog.Id.Value;
            viewModel.PersonUsername = viewModel.SquadronLog.Person.User.Username;
            viewModel.AvailablePersons = flightLogManager.GetAvailableSquadronPersons();
            return View(viewModel);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [RequireTransaction]
        public virtual ActionResult EditSquadronLog(int id, SquadronLogViewModel squadronLogViewModel)
        {
            var squadronLog = flightLogManager.GetSquadronLog(id);
            squadronLogViewModel.Validate(ModelState, string.Empty);
            squadronLogViewModel.SquadronLog.Validate(ModelState, "SquadronLog");
            if (!ModelState.IsValid)
            {
                var viewModel = new SquadronLogViewModel();
                viewModel.SquadronLog = squadronLog;
                viewModel.MissionLogId = viewModel.SquadronLog.MissionLog.Id.Value;
                viewModel.PersonUsername = viewModel.SquadronLog.Person.User.Username;
                viewModel.AvailablePersons = flightLogManager.GetAvailableSquadronPersons();
                return View(viewModel);
            }
            squadronLog.Person = flightLogManager.GetSquadronPersonForUsername(squadronLogViewModel.PersonUsername);
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
            return RedirectToAction(MVC.FlightLogs.EditMissionLog(squadronLogViewModel.MissionLogId));
        }

        [AcceptVerbs(HttpVerbs.Get)]
        [RequireTransaction]
        public virtual ViewResult CreateSquadronLog(int missionLogId)
        {
            var viewModel = new SquadronLogViewModel();
            viewModel.MissionLogId = missionLogId;
            viewModel.SetAvailablePersons(flightLogManager.GetAvailableSquadronPersons());
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
                squadronLogViewModel.SetAvailablePersons(flightLogManager.GetAvailableSquadronPersons());
                return View(squadronLogViewModel);
            }
            CreateNewSquadronLog(squadronLogViewModel);
            return RedirectToAction(MVC.FlightLogs.EditMissionLog(squadronLogViewModel.MissionLogId));
        }

        

        [AcceptVerbs(HttpVerbs.Get)]
        [RequireTransaction]
        public virtual ViewResult BulkCreateSquadronLog(int missionLogId)
        {
            var viewModel = CreateSquadronLogListViewModel(missionLogId);
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
                var viewModel = CreateSquadronLogListViewModel(squadronLogViewModel.MissionLogId);
                viewModel.CurrentSquadronLog = squadronLogViewModel;
                return View(Views.BulkCreateSquadronLog, viewModel);
            }
            CreateNewSquadronLog(squadronLogViewModel);
            return RedirectToAction(MVC.FlightLogs.BulkCreateSquadronLog(squadronLogViewModel.MissionLogId));
        }

        [RequireTransaction]
        public virtual FileContentResult DownloadPDF(int id)
        {
            var missionLog = flightLogManager.GetMissionLog(id);
            var reportGenerator = new PdfReportGenerator(new FlightTimeSummaryReport(missionLog));
            var bytes = reportGenerator.GenerateReport();
            return File(bytes, "application/pdf", "FlightTimeSummary(" + missionLog.LogDate.ToString("MM-dd-yy") + ").pdf");
        }

        private SquadronLogListViewModel CreateSquadronLogListViewModel(int missionLogId)
        {
            var viewModel = new SquadronLogListViewModel();
            viewModel.MissionLog = flightLogManager.GetMissionLog(missionLogId);
            viewModel.Items = viewModel.MissionLog.SquadronLogs;
            viewModel.CurrentSquadronLog = new SquadronLogViewModel
            {
                MissionLogId = viewModel.MissionLog.Id.Value,
            };
            viewModel.CurrentSquadronLog.SetAvailablePersons(flightLogManager.GetAvailableSquadronPersons());
            return viewModel;
        }

        private void CreateNewSquadronLog(SquadronLogViewModel squadronLogViewModel)
        {
            var missionLog = flightLogManager.GetMissionLog(squadronLogViewModel.MissionLogId);
            squadronLogViewModel.SquadronLog.Person = flightLogManager.GetSquadronPersonForUsername(squadronLogViewModel.PersonUsername);
            missionLog.AddSquadronLog(squadronLogViewModel.SquadronLog);
        }
    }
}
