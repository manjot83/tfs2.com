using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using TFS.Web.Mvc;

namespace TFS.Web.Controllers
{
    [Authorize]
    public partial class DashboardController : TransactionalController
    {
        public virtual ActionResult Index()
        {
#if DEBUG
            return View();
#else
            return Redirect("https://apollo.tfs2.com/secure");
#endif
        }
    }
}
