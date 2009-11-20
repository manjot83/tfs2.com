using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using TFS.Web.ActionFilters;

namespace TFS.Web.Controllers
{
    public partial class SecurityController : Controller
    {
        private readonly IAuthenticationService authenticationService;

        public SecurityController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        public virtual ViewResult LogOn(Uri returnUrl)
        {
            ViewData["returnUrl"] = returnUrl;
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [RequireTransaction]
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
        [RequireTransaction]
        public virtual ViewResult ChangePassword()
        {
            var user = authenticationService.UserManager.UserRepository.GetUser(User.Identity.Name);
            return View(user);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [Authorize]
        [RequireTransaction]
        public virtual ActionResult ChangePassword(string originalPassword, string newPassword, string confirmNewPassword)
        {
            if (string.IsNullOrEmpty(originalPassword))
                ModelState.AddModelError("originalPassword", "Password cannot be blank.");
            if (string.IsNullOrEmpty(newPassword))
                ModelState.AddModelError("newPassword", "Password cannot be blank.");
            if (string.IsNullOrEmpty(confirmNewPassword))
                ModelState.AddModelError("confirmNewPassword", "Password cannot be blank.");
            if (newPassword.Length < authenticationService.MinRequiredPasswordLength)
                ModelState.AddModelError("newPassword", string.Format("Password must be at least {0} characters long.", authenticationService.MinRequiredPasswordLength));
            if (newPassword != confirmNewPassword)
                ModelState.AddModelError("confirmNewPassword", "New password's must match.");
            var user = authenticationService.UserManager.UserRepository.GetUser(User.Identity.Name);
            if (!ModelState.IsValid)
                return View(user);
            if (!authenticationService.ChangePassword(user, originalPassword, newPassword))
            {
                ModelState.AddModelError("originalPassword", "Incorrect password.");
                return View(user);
            }
            return RedirectToAction(MVC.Dashboard.Index());
        }
    }
}
