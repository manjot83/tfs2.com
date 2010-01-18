using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace TFS.Web.Controllers
{
    [Authorize]
    public partial class DashboardController : Controller
    {
        public virtual ActionResult Index()
        {
            return Redirect("https://apollo.tfs2.com/secure");
            //return View();
        }
    }
}
