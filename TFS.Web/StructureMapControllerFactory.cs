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
            if (controllerType == null)
                return base.GetControllerInstance(controllerType);
            return (IController)container.Resolve(controllerType) ??
                   base.GetControllerInstance(controllerType);
        }
    }
}
