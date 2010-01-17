using System.Collections.Generic;
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

        protected NHibernateRepository Repository { get; private set; }
        protected IUnitOfWork UnitOfWork { get; private set; }

        [TestFixtureSetUp]
        public virtual void TestFixtureSetUp()
        {
            HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();

            var mappingAssemblies = new List<Assembly> { typeof(MappingExtensions).Assembly };
#if SQLITE
            cfg = ConfigurationBuilder.CreateMsSql2005Configuration("TFS_Models_Specs", mappingAssemblies);
#else
            cfg = ConfigurationBuilder.CreateMsSql2005Configuration(MsSqlConfiguration.MsSql2008.ConnectionString(@"Server=.\SQLEXPRESS;Database=dev_tfs2.com;Trusted_Connection=yes;"), mappingAssemblies);
#endif

            sessionFactory = cfg.BuildSessionFactory();
                        
#if SQLITE
            using (var session = sessionFactory.OpenSession())
            {
                new DatabaseBuilder(cfg, session).BuildSchema();
            }
#endif
        }

        [SetUp]
        public virtual void SetUp()
        {
            UnitOfWork = new NHibernateUnitOfWork(sessionFactory);
            UnitOfWork.Start();
            Repository = new NHibernateRepository(((INHibernateUnitOfWork)UnitOfWork).Session);
        }

        [TearDown]
        public virtual void TearDown()
        {
            UnitOfWork.Abort();
        }
    }
}
