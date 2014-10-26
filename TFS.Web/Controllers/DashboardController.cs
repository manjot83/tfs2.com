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
            return Redirect("default.aspx");
        }
    }
}
