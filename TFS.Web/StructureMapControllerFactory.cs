using System;
using System.Web.Mvc;
using StructureMap;

namespace TFS.Web
{
    public class StructureMapControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(Type controllerType)
        {
            var container = RequestContext.HttpContext.ApplicationInstance as ICanResolveDependencies;
            if (container == null)
                throw new InvalidOperationException("HttpApplication must implemented ICanResolveDependencies");

            IController controller = null;
            if (controllerType == null)
                controller = base.GetControllerInstance(controllerType);
            controller = (IController)container.Resolve(controllerType) ?? base.GetControllerInstance(controllerType);

            if (controller is Controller)
                ((Controller)controller).ActionInvoker = new TransactionalActionInvoker();

            return controller;
        }
    }
}
