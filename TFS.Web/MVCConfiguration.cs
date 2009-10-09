using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using Centro.MVC.Controllers;
using Centro.NHibernateUtils;
using StructureMap;
using StructureMap.Attributes;
using TFS.Web.Controllers;
using TFS.Models;
using NHibernate;

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
            var mappingAssemblies = new List<Assembly> { typeof(TFS.Models.User).Assembly };
#if SQLITE
            var nhibernateRegistry = SQLiteBuilder.CreateRegistry("TFS_Web", mappingAssemblies, InstanceScope.HttpContext);
#else
            var nhibernateRegistry = MSSqlBuilder.CreateRegistry("TFS_Web", mappingAssemblies, InstanceScope.HttpContext);
#endif
            ObjectFactory.Initialize(i =>
            {
                i.AddRegistry(nhibernateRegistry);

                i.Scan(s =>
                {
                    s.IncludeNamespaceContainingType<DashboardController>();
                    s.AddAllTypesOf<IController>();
                });

                i.Scan(x =>
                {
                    x.AssemblyContainingType<IRepository>();
                    x.AssemblyContainingType<RepositoryBase>();
                    x.With<StructureMap.Graph.DefaultConventionScanner>();
                });
            });

#if DEBUG
            ObjectFactory.AssertConfigurationIsValid();
#endif

            ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory());

#if SQLITE
            SQLiteUtil.GenerateSchema(nhibernateRegistry.Configuration, ObjectFactory.GetInstance<ISession>());
            SQLiteUtil.InitializeData(SQLiteTestData, ObjectFactory.GetInstance<ISession>());
            ObjectFactory.GetInstance<ISession>().Clear();
#endif
        }

#if SQLITE
        private static void SQLiteTestData()
        {
            var session = ObjectFactory.GetInstance<ISession>();
        }
#endif
    }
}
