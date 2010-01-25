using NHibernate;
using StructureMap.Configuration.DSL;

namespace TFS.Models.Data.Configuration {
    public class CoreRegistry : Registry {
        public CoreRegistry(NHibernate.Cfg.Configuration configuration) {
            ForSingletonOf<ISessionFactory>()
                .Use(configuration.BuildSessionFactory());
            For<IUnitOfWork>()
                .HybridHttpOrThreadLocalScoped()
                .Use<NHibernateUnitOfWork>();
            For<IRepository>()
                .HybridHttpOrThreadLocalScoped()
                .Use<NHibernateRepository>();
            For<INHibernateUnitOfWork>()
                .Use(x => (INHibernateUnitOfWork)x.GetInstance<IUnitOfWork>());
            Scan(x => {
                x.AssemblyContainingType<IDomainObject>();
                x.TheCallingAssembly();
                x.AddAllTypesOf<IDomainObject>();
                x.WithDefaultConventions();
            });
        }
    }
}
