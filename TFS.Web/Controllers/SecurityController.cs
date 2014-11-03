using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using TFS.Models;

namespace TFS.Web.Controllers
{
    public partial class SecurityController : BaseController
    {
        private readonly IAuthenticationService authenticationService;

        public SecurityController(IAuthenticationService authenticationService, IApplicationSettings applicationSettings, IRepository repository)
            :base(applicationSettings, repository)
        {
            this.authenticationService = authenticationService;
        }

        public virtual ViewResult LogOn(Uri returnUrl)
        {
            ViewData["returnUrl"] = returnUrl;
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult LogOn(string userName, string password, bool rememberMe, Uri returnUrl)
        {
            if (!authenticationService.Authenticate(userName, password))
            {
                this.ModelState.AddModelError("Logon Credentials", "Username or password incorrect.");
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

        [AcceptVerbs(HttpVerbs.Get)]
        [Authorize]
        public virtual ViewResult ChangePassword()
        {
            throw new NotSupportedException();
            //var user = this.CurrentUser;
            //return View(user);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [Authorize]
        public virtual ActionResult ChangePassword(string originalPassword, string newPassword, string confirmNewPassword)
        {
            throw new NotSupportedException();
            //if (string.IsNullOrEmpty(originalPassword))
            //    ModelState.AddModelError("originalPassword", "Password cannot be blank.");
            //if (string.IsNullOrEmpty(newPassword))
            //    ModelState.AddModelError("newPassword", "Password cannot be blank.");
            //if (string.IsNullOrEmpty(confirmNewPassword))
            //    ModelState.AddModelError("confirmNewPassword", "Password cannot be blank.");
            //if (newPassword.Length < authenticationService.MinRequiredPasswordLength)
            //    ModelState.AddModelError("newPassword", string.Format("Password must be at least {0} characters long.", authenticationService.MinRequiredPasswordLength));
            //if (newPassword != confirmNewPassword)
            //    ModelState.AddModelError("confirmNewPassword", "New password's must match.");
            //var user = this.CurrentUser;
            //if (!ModelState.IsValid)
            //    return View(user);
            //if (!authenticationService.ChangePassword(user, originalPassword, newPassword))
            //{
            //    ModelState.AddModelError("originalPassword", "Incorrect password.");
            //    return View(user);
            //}
            //return RedirectToAction(MVC.Dashboard.Index());
        }
    }
}
