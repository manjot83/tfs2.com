using FluentNHibernate.Cfg;
using NHibernate;
using StructureMap.Attributes;
using StructureMap.Configuration.DSL;
using TFS.Models;
using TFS.Models.Data;
using TFS.Models.FlightLogs;
using TFS.Models.FlightPrograms;
using TFS.Models.Users;

namespace TFS.Web
{
    public class DomainModelRegistry : Registry
    {
        public DomainModelRegistry(FluentConfiguration fluentConfiguration)
        {
            ForRequestedType<ISessionFactory>()
                  .CacheBy(InstanceScope.Singleton)
                  .TheDefault.Is.IsThis(fluentConfiguration.BuildSessionFactory());

            ForRequestedType<ISession>()
              .CacheBy(InstanceScope.Hybrid)
              .TheDefault.Is.ConstructedBy(x => x.GetInstance<ISessionFactory>().OpenSession());

            Scan(x =>
            {
                x.AssemblyContainingType<IUnitOfWork>();
                x.AssemblyContainingType<UnitOfWork>();
                x.With<StructureMap.Graph.DefaultConventionScanner>();
            });

            ForRequestedType<FlightLogManager>()
                .CacheBy(InstanceScope.Hybrid)
                .TheDefaultIsConcreteType<FlightLogManager>();

            ForRequestedType<FlightProgramsManager>()
                .CacheBy(InstanceScope.Hybrid)
                .TheDefaultIsConcreteType<FlightProgramsManager>();

            ForRequestedType<UserManager>()
                .CacheBy(InstanceScope.Hybrid)
                .TheDefaultIsConcreteType<UserManager>();
        }
    }
}
