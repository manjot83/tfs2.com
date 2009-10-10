using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace TFS.Web.Controllers
{
    public class SiteController : Controller
    {
        public ActionResult Index()
        {
            return View("SitePage");
        }

    }
}
