using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.UI.WebControls;
using TFS.Models.FlightLogs;
using TFS.Web.ViewModels;

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
                sortDirection = SortDirection.Ascending;
            var viewModel = new SortedListViewModel<MissionLog>();
            viewModel.SortDirection = sortDirection ?? SortDirection.Ascending;
            viewModel.SortType = sortType;
            var missionLogs = flightLogRepository.GetAllMissionLogs();
            if (viewModel.IsCurrentSortType("date") && viewModel.SortDirection == SortDirection.Ascending)
                missionLogs = missionLogs.OrderBy(x => x.LastModifiedDate);
            else if (viewModel.IsCurrentSortType("date"))
                missionLogs = missionLogs.OrderByDescending(x => x.LastModifiedDate);
            if (viewModel.IsCurrentSortType("aircraft") && viewModel.SortDirection == SortDirection.Ascending)
                missionLogs = missionLogs.OrderBy(x => x.AircraftModel);
            else if (viewModel.IsCurrentSortType("aircraft"))
                missionLogs = missionLogs.OrderByDescending(x => x.AircraftModel);
            if (viewModel.IsCurrentSortType("location") && viewModel.SortDirection == SortDirection.Ascending)
                missionLogs = missionLogs.OrderBy(x => x.Location);
            else if (viewModel.IsCurrentSortType("location"))
                missionLogs = missionLogs.OrderByDescending(x => x.Location);
            viewModel.Items = missionLogs;
            return View(Views.List, viewModel);
        }

        public virtual ViewResult EditMissionLog(int id)
        {
            throw new NotImplementedException();
        }

        public virtual ViewResult CreateMissionLog()
        {
            throw new NotImplementedException();
        }
    }
}
