using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using TFS.Models.Site;
using TFS.Web.Mvc;

namespace TFS.Web.Controllers
{
    public partial class SiteController : TransactionalController
    {
        public virtual ActionResult Index()
        {
            //return this.RedirectToAction(Actions.Home());
            return this.Redirect("http://tacticalflightservices.com/");
        }
    }
}
