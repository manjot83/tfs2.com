using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace TFS.Web.Mvc {
    public class TransactionalActionInvoker : ControllerActionInvoker {

        protected override AuthorizationContext InvokeAuthorizationFilters(ControllerContext controllerContext, IList<IAuthorizationFilter> filters, ActionDescriptor actionDescriptor) {
            var controller = (TransactionalController)controllerContext.Controller;
            AuthorizationContext authorizationContext = null;
            try {
                controller.UnitOfWork.Start();
                authorizationContext = base.InvokeAuthorizationFilters(controllerContext, filters, actionDescriptor);
                if (authorizationContext.Result != null)
                    controller.UnitOfWork.Abort();
                else
                    controller.UnitOfWork.Finish();
            } catch (Exception) {
                controller.UnitOfWork.Abort();
                throw;
            }
            return authorizationContext;
        }

        protected override ActionExecutedContext InvokeActionMethodWithFilters(ControllerContext controllerContext, IList<IActionFilter> filters, ActionDescriptor actionDescriptor, IDictionary<string, object> parameters) {
            var controller = (TransactionalController)controllerContext.Controller;
            ActionExecutedContext actionExecutedContext = null;
            try {
                controller.UnitOfWork.Start();
                actionExecutedContext = base.InvokeActionMethodWithFilters(controllerContext, filters, actionDescriptor, parameters);
                if (actionExecutedContext.Canceled || actionExecutedContext.Exception != null)
                    controller.UnitOfWork.Abort();
                else
                    controller.UnitOfWork.Finish();
            } catch (Exception) {
                controller.UnitOfWork.Abort();
                throw;
            }
            return actionExecutedContext;
        }
    }
}
