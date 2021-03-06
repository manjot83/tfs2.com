﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using StructureMap;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;
using StructureMap.TypeRules;
using TFS.Models;
using TFS.Models.Data;
using TFS.Models.Data.Configuration;
using TFS.Web.Controllers;
using TFS.Web.Mvc;
using TFS.Models.Data.Bytecode;
using TFS.Models.Data.Mappings;

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
            routes.IgnoreRoute("icons/{*resource}");
            routes.IgnoreRoute("images/{*resource}");
            routes.IgnoreRoute("style/{*resource}");

            routes.MapRoute(
                string.Empty,
                "oauth2callback",
                new { controller = MVC.Security.Name, action = MVC.Security.ActionNames.OAuth2callback }
            );

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
            var mappingAssemblies = new List<Assembly> { typeof(MappingExtensions).Assembly };
            var cfg = ConfigurationBuilder.CreateMsSql2005Configuration("tfsql", mappingAssemblies);
      
            var coreRegistry = new CoreRegistry(cfg);

            var container = new Container(i =>
            {
                i.AddRegistry(coreRegistry);

                i.Scan(s =>
                {
                    s.IncludeNamespaceContainingType<DashboardController>();
                    s.With(new SingletonConvention<IController>());
                    s.AddAllTypesOf<IController>();
                });

                i.ForSingletonOf<IApplicationSettings>()
                    .Use(x => new ApplicationSettings());
            });
#if DEBUG
            container.AssertConfigurationIsValid();
#endif
            ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory(container));
            ConfigurationBuilder.SetBytecodeProvider(new StructureMapBackedBytecodeProvider(container));
            MvcApplication.Container = container;
        }
    }

    internal class SingletonConvention<TPluginFamily> : IRegistrationConvention
    {
        public void Process(Type type, Registry registry)
        {
            if (!type.IsConcrete() || !type.CanBeCreated() || !type.AllInterfaces().Contains(typeof(TPluginFamily))) return;

            registry.For(typeof(TPluginFamily)).Singleton().Use(type);
        }
    }
}
