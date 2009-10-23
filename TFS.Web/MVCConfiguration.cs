﻿using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using Centro.Web.Mvc.Controllers;
using Centro.Data;
using StructureMap;
using StructureMap.Attributes;
using TFS.Web.Controllers;
using TFS.Models;
using NHibernate;
using TFS.Models.Site;
using TFS.Models.Data.Site;
using Centro.Validation;

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
            HibernatingRhinos.NHibernate.Profiler.Appender.NHibernateProfiler.Initialize();
#endif

            var mappingAssemblies = new List<Assembly> { typeof(TFS.Models.Data.UserMapping).Assembly };
#if SQLITE
            var nhibernateRegistry = SQLiteBuilder.CreateRegistry("TFS_Web", mappingAssemblies, InstanceScope.Hybrid, false);
#else
            var nhibernateRegistry = MSSqlBuilder.CreateRegistry("TFS_Web", mappingAssemblies, InstanceScope.HttpContext, false);
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
                    x.AssemblyContainingType<ISiteRepository>();
                    x.AssemblyContainingType<SiteRepository>();
                    x.With<StructureMap.Graph.DefaultConventionScanner>();
                });

                i.ForRequestedType<IAuthenticationService>()
                    .CacheBy(InstanceScope.PerRequest)
                    .TheDefaultIsConcreteType<FormsAuthenticationService>();

                i.ForRequestedType<IValidator>()
                    .CacheBy(InstanceScope.Singleton)
                    .TheDefaultIsConcreteType<DataAnnotationsValidator>();
            });

#if DEBUG
            ObjectFactory.AssertConfigurationIsValid();
#endif

            ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory());

#if SQLITE
            SQLiteUtil.GenerateSchema(nhibernateRegistry.Configuration, ObjectFactory.GetInstance<ISession>());
            SQLiteUtil.InitializeData(SQLiteTestData.Execute, ObjectFactory.GetInstance<ISession>());
            ObjectFactory.GetInstance<ISession>().Clear();
#endif
        }
    }
}
