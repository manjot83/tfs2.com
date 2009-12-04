using System.Web.Mvc;
using TFS.Web.ViewModels;
using TFS.Models.Users;
using System;

namespace TFS.Web.Controllers
{
    public static class ControllerExtension
    {
        public static ViewResult RedirectToSuccess(this Controller controller, ActionResult redirectRoute)
        {
            return new ViewResult
            {
                ViewName = MVC.Shared.Views.Success,
                ViewData = new ViewDataDictionary(new SuccessViewModel { RedirectRoute = redirectRoute }),
            };
        }

        public static User GetCurrentUser(this Controller controller)
        {
            if (controller.User == null ||
                controller.User.Identity == null)
                return null;
            return GetUser(controller, controller.User.Identity.Name);
        }

        public static User GetUser(this Controller controller, string username)
        {
            return GetUserRepository(controller).GetUser(username);
        }

        public static IUserRepository GetUserRepository(this Controller controller)
        {
            var container = controller.HttpContext.ApplicationInstance as ICanResolveDependencies;
            if (container == null)
                throw new InvalidOperationException("HttpApplication must implemented ICanResolveDependencies");
            return container.Resolve<IUserRepository>();
        }
    }
}
