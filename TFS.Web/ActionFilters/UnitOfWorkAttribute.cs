using System;
using System.Web.Mvc;
using TFS.Models;

namespace TFS.Web.ActionFilters
{
    public class UnitOfWorkAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var container = filterContext.HttpContext.ApplicationInstance as ICanResolveDependencies;
            if (container == null)
                throw new InvalidOperationException("HttpApplication must implemented ICanResolveDependencies");

            var unitOfWork = container.Resolve<IUnitOfWork>();
            unitOfWork.Begin();
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var container = filterContext.HttpContext.ApplicationInstance as ICanResolveDependencies;
            if (container == null)
                throw new InvalidOperationException("HttpApplication must implemented ICanResolveDependencies");

            var unitOfWork = container.Resolve<IUnitOfWork>();
            if (filterContext.Exception == null)
                unitOfWork.Finish();
            else
                unitOfWork.Abort();
        }
    }
}
