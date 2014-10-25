using System;
using NHibernate.Bytecode;
using NHibernate.ByteCode.Castle;
using NHibernate.Properties;
using NHibernate.Type;
using StructureMap;

namespace TFS.Models.Data.Bytecode {
    public class StructureMapBackedBytecodeProvider : IBytecodeProvider {
        private readonly IContainer container;
        private readonly IObjectsFactory objectsFactory;
        private readonly ICollectionTypeFactory collectionTypefactory;

        public StructureMapBackedBytecodeProvider(IContainer container) {
            this.container = container;
            objectsFactory = new StructureMapBackedObjectsFactory(this.container);
            collectionTypefactory = new DefaultCollectionTypeFactory();
        }

        public IReflectionOptimizer GetReflectionOptimizer(Type clazz, IGetter[] getters, ISetter[] setters) {
            return new StructureMapBackedReflectionOptimizer(container, clazz, getters, setters);
        }

        public IProxyFactoryFactory ProxyFactoryFactory {
            get { return new ProxyFactoryFactory(); }
        }

        public IObjectsFactory ObjectsFactory {
            get { return objectsFactory; }
        }

        public ICollectionTypeFactory CollectionTypeFactory {
            get { return collectionTypefactory; }
        }

    }
}