using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.UI.WebControls;

namespace TFS.Web.Controllers
{
    public partial class FlightLogsController : Controller
    {
        public virtual ViewResult Index()
        {
            return List(null, null);
        }

        public virtual ViewResult List(string sortType, SortDirection? sortDirection)
        {
            return View(Views.List);
        }
    }
}
