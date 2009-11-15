using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using Centro.Data;
using Centro.Validation;
using Centro.Web.Mvc.Controllers;
using NHibernate;
using StructureMap;
using StructureMap.Attributes;
using TFS.Models;
using TFS.Models.Data;
using TFS.Web.Controllers;

namespace TFS.Web
{
    public class MVCConfiguration
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });
            routes.IgnoreRoute("Content/{*resource}");
            routes.IgnoreRoute("Scripts/{*resource}");

            routes.MapRoute(
                string.Empty,
                "{controller}/{action}/{id}",
                new { controller = MVC.Dashboard.Name, action = MVC.Dashboard.Actions.Index, id = "" }
            );

        }

        public static void InitializeIoCAndDataAccess()
        {
#if DEBUG
            HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();
#endif

            var mappingAssemblies = new List<Assembly> { typeof(TFS.Models.Data.UserMapping).Assembly };
#if SQLITE
            var fluentConfiguration = SQLiteBuilder.CreateConfiguration("TFS_Web", mappingAssemblies, false);
#else
            var fluentConfiguration = MSSqlBuilder.CreateConfiguration("TFS_Web", mappingAssemblies, false);
#endif
            ObjectFactory.Initialize(i =>
            {
                i.ForRequestedType<ISessionFactory>()
                    .CacheBy(InstanceScope.Singleton)
                    .TheDefault.Is.IsThis(fluentConfiguration.BuildSessionFactory());

                i.ForRequestedType<ISession>()
                    .CacheBy(InstanceScope.Hybrid)
                    .TheDefault.Is.ConstructedBy(x => x.GetInstance<ISessionFactory>().OpenSession());

                i.Scan(s =>
                {
                    s.IncludeNamespaceContainingType<DashboardController>();
                    s.AddAllTypesOf<IController>();
                });

                i.Scan(x =>
                {
                    x.AssemblyContainingType<IUserManager>();
                    x.AssemblyContainingType<UserManager>();
                    x.With<StructureMap.Graph.DefaultConventionScanner>();
                });

                i.ForRequestedType<IAuthenticationService>()
                    .CacheBy(InstanceScope.Hybrid)
                    .TheDefaultIsConcreteType<FormsAuthenticationService>();
            });

#if DEBUG
            ObjectFactory.AssertConfigurationIsValid();
#endif

            ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory());
            SharedValidator.Default.Validator = new DataAnnotationsValidator();

#if SQLITE
            var session = ObjectFactory.GetInstance<ISession>();
            SqlSchemaUtil.GenerateSchema(fluentConfiguration.BuildConfiguration(), session);
            TestData.Execute(session);
            session.Clear();
#endif
        }
    }
}
