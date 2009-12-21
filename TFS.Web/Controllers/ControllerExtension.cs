using System.Web.Mvc;
using TFS.Web.ViewModels;
using TFS.Models.Users;
using System;
using TFS.Models.Validation;

namespace TFS.Web.Controllers
{
    public static class ControllerExtension
    {
        private readonly static DataAnnotationsValidator Validator;

        static ControllerExtension()
        {
            Validator = new DataAnnotationsValidator();
        }

        public static void Validate(this Controller controller, object viewModel, string prefix)
        {
            var fixedPrefix = prefix ?? string.Empty;
            if (!string.IsNullOrEmpty(fixedPrefix) && !fixedPrefix.EndsWith("."))
                fixedPrefix += ".";
            foreach (var error in Validator.ValidationErrorsFor(viewModel))
            {
                var key = fixedPrefix + error.PropertyName;
                controller.ModelState.AddModelError(key, error.ErrorMessage);
            }
        }

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
