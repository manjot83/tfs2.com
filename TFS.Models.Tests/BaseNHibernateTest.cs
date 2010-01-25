using System.Collections.Generic;
using System.Reflection;
using FluentNHibernate.Cfg.Db;
using NUnit.Framework;
using StructureMap;
using TFS.Models.Data;
using TFS.Models.Data.Bytecode;
using TFS.Models.Data.Configuration;
using TFS.Models.Data.Mappings;

namespace TFS.Models.Tests
{
    public abstract class BaseNHibernateTest
    {
        private IContainer container;

        protected NHibernateRepository Repository { get; private set; }
        protected IUnitOfWork UnitOfWork { get; private set; }

        [TestFixtureSetUp]
        public virtual void TestFixtureSetUp()
        {
            HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();

            var mappingAssemblies = new List<Assembly> { typeof(MappingExtensions).Assembly };
            var cfg = ConfigurationBuilder.CreateFluentConfiguration(MsSqlConfiguration.MsSql2008.ConnectionString(@"Server=.\SQLEXPRESS;Database=dev_tfs2.com;Trusted_Connection=yes;"), mappingAssemblies);

            var coreRegistry = new CoreRegistry(cfg);

            container = new Container(i => {
                i.AddRegistry(coreRegistry);
            });
            ConfigurationBuilder.SetBytecodeProvider(new StructureMapBackedBytecodeProvider(container));
        }

        [SetUp]
        public virtual void SetUp()
        {
            UnitOfWork = container.GetInstance<IUnitOfWork>();
            UnitOfWork.Start();
            Repository = container.GetInstance<NHibernateRepository>();
        }

        [TearDown]
        public virtual void TearDown()
        {
            UnitOfWork.Abort();
        }
    }
}
