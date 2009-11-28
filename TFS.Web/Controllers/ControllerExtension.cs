using System.Web.Mvc;
using TFS.Web.ViewModels;

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
    }
}
