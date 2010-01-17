using NHibernate;
using StructureMap.Configuration.DSL;

namespace TFS.Models.Data.Configuration
{
    public class CoreRegistry : Registry
    {
        public CoreRegistry(NHibernate.Cfg.Configuration configuration)
        {
            ForSingletonOf<ISessionFactory>()
                    .Use(configuration.BuildSessionFactory());

            For<IUnitOfWork>()
                .HybridHttpOrThreadLocalScoped()
                .Use<NHibernateUnitOfWork>();

            For<ISession>()
                .Use(x => ((INHibernateUnitOfWork)x.GetInstance<IUnitOfWork>()).Session);

            For<IRepository>()
                .HybridHttpOrThreadLocalScoped()
                .Use<NHibernateRepository>();

            Scan(x =>
            {
                x.AssemblyContainingType<IUnitOfWork>();
                x.TheCallingAssembly();
                x.ExcludeType<INHibernateUnitOfWork>();
                x.WithDefaultConventions();
            });
        }
    }
}
