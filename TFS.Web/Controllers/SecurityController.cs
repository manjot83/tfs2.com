using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace TFS.Web.Controllers
{
    public partial class SecurityController : Controller
    {
        private readonly IAuthenticationService authenticationService;

        public SecurityController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        public virtual ViewResult LogOn()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult LogOn(string userName, string password, bool rememberMe, Uri returnUrl)
        {
            if (!authenticationService.Authenticate(userName, password))
            {
                this.ModelState.AddModelError("loginForm", "Username or password incorrect.");
                return View();
            }

            authenticationService.LogOn(userName, rememberMe);
            if (returnUrl != null && !String.IsNullOrEmpty(returnUrl.OriginalString))
            {
                return Redirect(returnUrl.OriginalString);
            }
            else
            {
                return RedirectToAction(MVC.Dashboard.Index());
            }
        }

        public virtual RedirectToRouteResult LogOff()
        {
            authenticationService.LogOff();
            return RedirectToAction(MVC.Site.Index());
        }
    }
}
