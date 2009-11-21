using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using TFS.Web.ActionFilters;

namespace TFS.Web.Controllers
{
    [DomainAuthorize]
    public partial class DashboardController : Controller
    {
        public virtual ViewResult Index()
        {
            return View();
        }

        public virtual ViewResult GenerateSideBar()
        {
            return View(MVC.Shared.Views.DashboardSideBar);
        }
    }
}
