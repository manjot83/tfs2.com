using System;
using NHibernate.Bytecode;
using StructureMap;

namespace TFS.Models.Data.Bytecode {
    public class StructureMapBackedObjectsFactory : IObjectsFactory {
        private readonly IContainer container;

        public StructureMapBackedObjectsFactory(IContainer container) {
            this.container = container;
        }

        public object CreateInstance(Type type) {
            return CreateFromStructureMap(type) ?? Activator.CreateInstance(type);
        }

        public object CreateInstance(Type type, bool nonPublic) {
            return CreateFromStructureMap(type) ?? Activator.CreateInstance(type, nonPublic);
        }

        private object CreateFromStructureMap(Type type) {
            if (container.Model.HasImplementationsFor(type))
                return container.GetInstance(type);
            return null;
        }

        public object CreateInstance(Type type, params object[] ctorArgs) {
            return Activator.CreateInstance(type, ctorArgs);
        }
    }
}