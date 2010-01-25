using System;
using NHibernate.Bytecode.Lightweight;
using NHibernate.Properties;
using StructureMap;

namespace TFS.Models.Data.Bytecode {
    public class StructureMapBackedReflectionOptimizer : ReflectionOptimizer {
        private readonly IContainer container;

        public StructureMapBackedReflectionOptimizer(IContainer container, Type mappedType, IGetter[] getters, ISetter[] setters)
            : base(mappedType, getters, setters) {
            this.container = container;
        }

        public override object CreateInstance() {
            return container.GetInstance(mappedType);
        }

        protected override void ThrowExceptionForNoDefaultCtor(Type type) {
        }
    }
}