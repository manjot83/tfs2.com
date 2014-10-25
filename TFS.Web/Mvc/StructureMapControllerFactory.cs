using System;
using System.Web.Mvc;
using TFS.Models;
using StructureMap;
using System.Web.Routing;

namespace TFS.Web.Mvc {
    public class StructureMapControllerFactory : DefaultControllerFactory {
        private readonly IContainer container;

        public StructureMapControllerFactory(IContainer container) {
            this.container = container;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
                return base.GetControllerInstance(requestContext, controllerType);
            var controller = (TransactionalController)container.GetInstance(controllerType);
            if (controller == null)
                return base.GetControllerInstance(requestContext, controllerType);
            controller.UnitOfWork = container.GetInstance<IUnitOfWork>();
            controller.ActionInvoker = new TransactionalActionInvoker();
            return controller;
        }
    }
}
