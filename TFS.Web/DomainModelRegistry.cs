using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap.Configuration.DSL;
using NHibernate;
using StructureMap.Attributes;
using FluentNHibernate.Cfg;
using TFS.Models.Data.Users;
using TFS.Models.Users;
using TFS.Models.FlightLogs;
using TFS.Models.FlightPrograms;

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
                x.AssemblyContainingType<IUserRepository>();
                x.AssemblyContainingType<UserRepository>();
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
