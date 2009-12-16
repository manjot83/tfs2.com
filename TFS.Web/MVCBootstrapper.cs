using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using FluentNHibernate.Cfg;
using StructureMap;
using StructureMap.Attributes;
using TFS.Models.Data.Configuration;
using TFS.Web.Controllers;

namespace TFS.Web
{
    public class MvcBootstrapper
    {
        public static void SetupApplication()
        {
            RegisterRoutes(RouteTable.Routes);
            InitializeAutoMapper();
            var fluentConfiguration = InitializeNHibernate();
            InitializeStructureMap(fluentConfiguration);
            InitializeAssetCaching();
#if SQLITE
            LoadTestData(fluentConfiguration);
#endif
        }

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

        public static void InitializeAutoMapper()
        {
            AutoMapperConfiguration.InitializeAutoMapper();
        }

        public static void InitializeAssetCaching()
        {
            Tags.ConfigureTags();
        }

        public static FluentConfiguration InitializeNHibernate()
        {
#if DEBUG
            HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();
#endif
            var mappingAssemblies = new List<Assembly> { typeof(TFS.Models.Data.Mappings.Users.UserMapping).Assembly };
#if SQLITE
            return SQLiteBuilder.CreateConfiguration("TFS_Web", mappingAssemblies);
#else
            return MSSqlBuilder.CreateConfiguration("TFS_Web", mappingAssemblies);
#endif
        }

        public static void InitializeStructureMap(FluentConfiguration fluentConfiguration)
        {
            ObjectFactory.Initialize(i =>
            {
                i.AddRegistry(new DomainModelRegistry(fluentConfiguration));

                i.Scan(s =>
                {
                    s.IncludeNamespaceContainingType<DashboardController>();
                    s.AddAllTypesOf<IController>();
                });

                i.ForRequestedType<IAuthenticationService>()
                    .CacheBy(InstanceScope.Hybrid)
                    .TheDefaultIsConcreteType<FormsAuthenticationService>();

                i.ForRequestedType<IApplicationSettings>()
                    .CacheBy(InstanceScope.Singleton)
                    .TheDefault.Is.ConstructedBy(x => new ApplicationSettings());
            });
#if DEBUG
            ObjectFactory.AssertConfigurationIsValid();
#endif
            ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory());
        }

#if SQLITE
        public static void LoadTestData(FluentConfiguration fluentConfiguration)
        {
            var session = ObjectFactory.GetInstance<ISession>();
            SqlSchemaUtil.GenerateSchema(fluentConfiguration.BuildConfiguration(), session);
            TestData.Execute(session);
            session.Clear();
        }
#endif
    }
}
