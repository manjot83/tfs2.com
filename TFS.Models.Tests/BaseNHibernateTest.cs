﻿using System.Collections.Generic;
using System.Reflection;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NUnit.Framework;
using TFS.Models.Data;
using TFS.Models.Data.Configuration;
using TFS.Models.Data.Mappings;

namespace TFS.Models.Tests
{
    public abstract class BaseNHibernateTest
    {
        private NHibernate.Cfg.Configuration cfg;
        private ISessionFactory sessionFactory;

        protected ISession Session { get; private set; }
        protected IUnitOfWork UnitOfWork { get; private set; }

        [TestFixtureSetUp]
        public virtual void TestFixtureSetUp()
        {
            HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();

            var mappingAssemblies = new List<Assembly> { typeof(MappingExtensions).Assembly };
            cfg = FluentConfigurationBuilder.CreateFluentConfiguration(MsSqlConfiguration.MsSql2008.ConnectionString(@"Server=.\SQLEXPRESS;Database=dev_tfs2.com;Trusted_Connection=yes;"), mappingAssemblies).BuildConfiguration();
            sessionFactory = cfg.BuildSessionFactory();
        }

        [SetUp]
        public virtual void SetUp()
        {
            Session = sessionFactory.OpenSession();
            UnitOfWork = new UnitOfWork(Session);
            UnitOfWork.Begin();
        }

        [TearDown]
        public virtual void TearDown()
        {
            UnitOfWork.Abort();
            Session.Close();
        }
    }
}
