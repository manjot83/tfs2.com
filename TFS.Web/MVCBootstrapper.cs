using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using FluentNHibernate.Cfg;
using StructureMap;
using StructureMap.Attributes;
using TFS.Models.Data.Configuration;
using TFS.Web.Controllers;
using TFS.Models;
using TFS.Models.Data;

namespace TFS.Web
{
    public class MvcBootstrapper
    {
        public static void SetupApplication()
        {
            RegisterRoutes(RouteTable.Routes);
            InitializeAutoMapper();
            var cfg = InitializeNHibernate();
            InitializeStructureMap(cfg);
            InitializeAssetCaching();
#if SQLITE
            LoadTestData(cfg);
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

        public static NHibernate.Cfg.Configuration InitializeNHibernate()
        {
#if DEBUG
            HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();
#endif
            var mappingAssemblies = new List<Assembly> { typeof(TFS.Models.Data.Mappings.Users.UserMapping).Assembly };
#if SQLITE
            return ConfigurationBuilder.CreateMsSql2005Configuration("TFS_Web", mappingAssemblies);
#else
            return ConfigurationBuilder.CreateMsSql2005Configuration("TFS_Web", mappingAssemblies);
#endif
        }

        public static void InitializeStructureMap(NHibernate.Cfg.Configuration cfg)
        {
            var coreRegistry = new CoreRegistry(cfg);
            ObjectFactory.Initialize(i =>
            {
                i.AddRegistry(coreRegistry);

                i.Scan(s =>
                {
                    s.IncludeNamespaceContainingType<DashboardController>();
                    s.AddAllTypesOf<IController>();
                });

                i.For<IAuthenticationService>()
                    .HybridHttpOrThreadLocalScoped()
                    .Use<FormsAuthenticationService>();

                i.ForSingletonOf<IApplicationSettings>()
                    .Use(x => new ApplicationSettings());
            });
#if DEBUG
            ObjectFactory.AssertConfigurationIsValid();
#endif
            ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory());
        }

#if SQLITE
        public static void LoadTestData(NHibernate.Cfg.Configuration cfg)
        {
            var unitOfWork = ObjectFactory.GetInstance<IUnitOfWork>() as INHibernateUnitOfWork;
            new DatabaseBuilder(cfg, unitOfWork.Session);
            unitOfWork.Start();
            TestData.Execute(unitOfWork.Session);
            unitOfWork.Finish();
            unitOfWork.Session.Clear();
        }
#endif
    }
}
