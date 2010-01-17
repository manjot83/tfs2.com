using System;
using System.Collections.Generic;
using System.Web.Mvc;
using TFS.Models;

namespace TFS.Web
{
    public class TransactionalActionInvoker : ControllerActionInvoker
    {
        protected IUnitOfWork UnitOfWork { get; private set; }

        public override bool InvokeAction(ControllerContext controllerContext, string actionName)
        {
            var container = controllerContext.HttpContext.ApplicationInstance as ICanResolveDependencies;
            if (container == null)
                throw new InvalidOperationException("HttpApplication must implemented ICanResolveDependencies");
            UnitOfWork = container.Resolve<IUnitOfWork>();
            return base.InvokeAction(controllerContext, actionName);
        }

        protected override AuthorizationContext InvokeAuthorizationFilters(ControllerContext controllerContext, IList<IAuthorizationFilter> filters, ActionDescriptor actionDescriptor)
        {
            AuthorizationContext authorizationContext = null;
            try
            {
                UnitOfWork.Start();
                authorizationContext = base.InvokeAuthorizationFilters(controllerContext, filters, actionDescriptor);
                if (authorizationContext.Result != null)
                    UnitOfWork.Abort();
                else
                    UnitOfWork.Finish();
            }
            catch (Exception)
            {
                UnitOfWork.Abort();
                throw;
            }
            return authorizationContext;
        }

        protected override ActionExecutedContext InvokeActionMethodWithFilters(ControllerContext controllerContext, IList<IActionFilter> filters, ActionDescriptor actionDescriptor, IDictionary<string, object> parameters)
        {
            ActionExecutedContext actionExecutedContext = null;
            try
            {
                UnitOfWork.Start();
                actionExecutedContext = base.InvokeActionMethodWithFilters(controllerContext, filters, actionDescriptor, parameters);
                if (actionExecutedContext.Canceled || actionExecutedContext.Exception != null)
                    UnitOfWork.Abort();
                else
                    UnitOfWork.Finish();
            }
            catch (Exception)
            {
                UnitOfWork.Abort();
                throw;
            }
            return actionExecutedContext;
        }
    }
}
