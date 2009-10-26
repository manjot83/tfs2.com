using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Centro.Web.Mvc;
using Centro.Web.Mvc.ActionFilters;
using TFS.Models.FlightLogs;
using TFS.Web.ViewModels;
using System;

namespace TFS.Web.Controllers
{
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
            var viewModel = FlightLogViewModel.CreateFromMissionLog(missionLog);
            flightLog.Validate(ModelState, string.Empty);
            if (!ModelState.IsValid)
                return View(viewModel);            
            missionLog.LogDate = flightLog.MissionLogDate.ToUniversalTime();
            missionLog.AircraftMDS = flightLog.AircraftMDS;
            missionLog.AircraftSerialNumber = flightLog.AircraftSerialNumber;
            missionLog.Location = flightLog.Location;
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
            return View(viewModel);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [RequireTransaction]
        public virtual ActionResult EditMission(int id, MissionViewModel missionViewModel)
        {
            var mission = flightLogRepository.GetMission(id);
            var viewModel = new MissionViewModel();
            viewModel.Mission = mission;
            missionViewModel.Validate(ModelState, string.Empty);
            missionViewModel.Mission.Validate(ModelState, "mission");
            if (!ModelState.IsValid)
                return View(viewModel);
            throw new NotImplementedException();
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
            missionViewModel.Mission.Validate(ModelState, "mission");
            if (!ModelState.IsValid)
                return View(missionViewModel);
            var missionLog = flightLogRepository.GetMissionLog(missionViewModel.MissionLogId);
            flightLogRepository.AddMission(missionLog, missionViewModel.Mission);
            return RedirectToAction(MVC.FlightLogs.EditMissionLog(missionViewModel.MissionLogId));
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public virtual ViewResult EditSquadronLog(int id)
        {
            throw new NotImplementedException();
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public virtual ViewResult CreateSquadronLog()
        {
            throw new NotImplementedException();
        }
    }
}
