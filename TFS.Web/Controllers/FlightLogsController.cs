using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Centro.Web.Mvc;
using Centro.Web.Mvc.ActionFilters;
using TFS.Models.FlightLogs;
using TFS.Web.ViewModels;

namespace TFS.Web.Controllers
{
    [Authorize]
    public partial class FlightLogsController : Controller
    {
        private readonly IFlightLogRepository flightLogRepository;

        public FlightLogsController(IFlightLogRepository flightLogRepository)
        {
            this.flightLogRepository = flightLogRepository;
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
            var viewModel = new SortedListViewModel<MissionLog>();
            viewModel.SortDirection = sortDirection ?? SortDirection.Ascending;
            viewModel.SortType = sortType;
            var missionLogs = flightLogRepository.GetAllMissionLogs();
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
        public virtual ViewResult EditMissionLog(int id)
        {
            var missionLog = flightLogRepository.GetMissionLog(id);
            var viewModel = FlightLogViewModel.CreateFromMissionLog(missionLog);
            viewModel.SavedMissionLog = (bool?)TempData["SavedMissionLog"] ?? false;
            return View(viewModel);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [RequireTransaction]
        public virtual ActionResult EditMissionLog(int id, FlightLogViewModel flightLog)
        {
            var missionLog = flightLogRepository.GetMissionLog(id);
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
            var missiongLog = flightLogRepository.CreateNewMissionLog(flightLog.MissionLogDate.ToUniversalTime(), flightLog.AircraftMDS, flightLog.AircraftSerialNumber, flightLog.Location);
            return RedirectToAction(MVC.FlightLogs.EditMissionLog(missiongLog.Id.Value));
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public virtual ViewResult EditMission(int id)
        {
            var viewModel = new MissionViewModel();
            viewModel.Mission = flightLogRepository.GetMission(id);
            viewModel.MissionLogId = viewModel.Mission.MissionLog.Id.Value;
            return View(viewModel);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [RequireTransaction]
        public virtual ActionResult EditMission(int id, MissionViewModel missionViewModel)
        {
            var mission = flightLogRepository.GetMission(id);
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
            var missionLog = flightLogRepository.GetMissionLog(missionViewModel.MissionLogId);
            flightLogRepository.AddMission(missionLog, missionViewModel.Mission);
            return RedirectToAction(MVC.FlightLogs.EditMissionLog(missionViewModel.MissionLogId));
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public virtual ViewResult EditSquadronLog(int id)
        {
            var viewModel = new SquadronLogViewModel();
            viewModel.SquadronLog = flightLogRepository.GetSquadronLog(id);
            viewModel.MissionLogId = viewModel.SquadronLog.MissionLog.Id.Value;
            viewModel.PersonUsername = viewModel.SquadronLog.Person.User.Username;
            viewModel.AvailablePersons = flightLogRepository.GetAvailableSquadronPersons();
            return View(viewModel);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [RequireTransaction]
        public virtual ActionResult EditSquadronLog(int id, SquadronLogViewModel squadronLogViewModel)
        {
            var squadronLog = flightLogRepository.GetSquadronLog(id);
            squadronLogViewModel.Validate(ModelState, string.Empty);
            squadronLogViewModel.SquadronLog.Validate(ModelState, "SquadronLog");
            if (!ModelState.IsValid)
            {
                var viewModel = new SquadronLogViewModel();
                viewModel.SquadronLog = squadronLog;
                viewModel.MissionLogId = viewModel.SquadronLog.MissionLog.Id.Value;
                viewModel.PersonUsername = viewModel.SquadronLog.Person.User.Username;
                viewModel.AvailablePersons = flightLogRepository.GetAvailableSquadronPersons();
                return View(viewModel);
            }
            squadronLog.Person = flightLogRepository.GetSquadronPersonForUsername(squadronLogViewModel.PersonUsername);
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
        public virtual ViewResult CreateSquadronLog(int missionLogId)
        {
            var viewModel = new SquadronLogViewModel();
            viewModel.MissionLogId = missionLogId;
            viewModel.AvailablePersons = flightLogRepository.GetAvailableSquadronPersons();
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
                squadronLogViewModel.AvailablePersons = flightLogRepository.GetAvailableSquadronPersons();
                return View(squadronLogViewModel);
            }
            var missionLog = flightLogRepository.GetMissionLog(squadronLogViewModel.MissionLogId);
            squadronLogViewModel.SquadronLog.Person = flightLogRepository.GetSquadronPersonForUsername(squadronLogViewModel.PersonUsername);
            flightLogRepository.AddSquadronLog(missionLog, squadronLogViewModel.SquadronLog);
            return RedirectToAction(MVC.FlightLogs.EditMissionLog(squadronLogViewModel.MissionLogId));
        }
    }
}
