using System.Web.Mvc;
using TFS.Models.Validation;
using TFS.Web.ViewModels;

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
    }
}
