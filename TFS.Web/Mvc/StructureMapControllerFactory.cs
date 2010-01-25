using System;
using System.Web.Mvc;
using TFS.Models;
using StructureMap;

namespace TFS.Web.Mvc {
    public class StructureMapControllerFactory : DefaultControllerFactory {
        private readonly IContainer container;

        public StructureMapControllerFactory(IContainer container) {
            this.container = container;
        }

        protected override IController GetControllerInstance(Type controllerType) {
            if (controllerType == null)
                return base.GetControllerInstance(controllerType);
            var controller = (TransactionalController)container.GetInstance(controllerType);
            if (controller == null)
                return base.GetControllerInstance(controllerType);
            controller.UnitOfWork = container.GetInstance<IUnitOfWork>();
            controller.ActionInvoker = new TransactionalActionInvoker();
            return controller;
        }
    }
}
