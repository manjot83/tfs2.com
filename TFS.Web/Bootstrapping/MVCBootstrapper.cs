using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using StructureMap;
using TFS.Models;
using TFS.Models.Data;
using TFS.Models.Data.Configuration;
using TFS.Web.Controllers;

namespace TFS.Web
{
    public class MvcBootstrapper
    {
        public static void SetupApplication()
        {
            RegisterRoutes(RouteTable.Routes);
            InitializeNHibernate();
            InitializeAutoMapper();
            InitializeAssetCaching();
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("elmah.axd");
            routes.IgnoreRoute("robots.txt");
            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });
            routes.IgnoreRoute("Content/{*resource}");
            routes.IgnoreRoute("Static/{*resource}");

            routes.MapRoute(
                string.Empty,
                "{controller}/{action}/{id}",
                new { controller = MVC.Dashboard.Name, action = MVC.Dashboard.ActionNames.Index, id = "" }
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

        public static void InitializeNHibernate()
        {
#if DEBUG
            HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();
#endif
            var mappingAssemblies = new List<Assembly> { typeof(TFS.Models.Data.Mappings.Users.UserMapping).Assembly };
#if SQLITE
            var cfg = ConfigurationBuilder.CreateFileBasedSQLiteConfiguration("TFS_Web", mappingAssemblies);
#else
            var cfg = ConfigurationBuilder.CreateMsSql2005Configuration("TFS_Web", mappingAssemblies);
#endif
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
                    .Use<FormsAuthenticationWrapper>();

                i.ForSingletonOf<IApplicationSettings>()
                    .Use(x => new ApplicationSettings());
            });
#if DEBUG
            ObjectFactory.AssertConfigurationIsValid();
#endif
            ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory());

#if TESTDATA
            var unitOfWork = ObjectFactory.GetInstance<IUnitOfWork>() as INHibernateUnitOfWork;
#if SQLITE
            new DatabaseBuilder(cfg, unitOfWork.Session).BuildSchema();
#endif
            unitOfWork.Start();
            TestData.Execute(ObjectFactory.GetInstance<IRepository>() as NHibernateRepository);
            unitOfWork.Finish();
            unitOfWork.Session.Clear();
#endif
        }
    }
}
