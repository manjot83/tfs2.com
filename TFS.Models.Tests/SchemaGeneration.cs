using System.Collections.Generic;
using System.Reflection;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using TFS.Models.Data;
using TFS.Models.Data.Configuration;

namespace TFS.Models.Tests
{
    [TestFixture]
    public class SchemaGeneration
    {
        private NHibernate.Cfg.Configuration cfg;

        [SetUp]
        public virtual void SetUp()
        {
            var mappingAssemblies = new List<Assembly> { typeof(UserMapping).Assembly };
            cfg = FluentConfigurationBuilder.CreateFluentConfiguration(MsSqlConfiguration.MsSql2008.ConnectionString(@"Server=.\SQLEXPRESS;Database=dev_tfs2.com;Trusted_Connection=yes;"), mappingAssemblies).BuildConfiguration();
        }

        [Test, Explicit("Generates Schema Creation Scripts")]
        public void GenerateSchema()
        {
            new SchemaExport(cfg).Create(true, false);
            Assert.Pass();
        }

        [Test, Explicit("Generates Schema Creation Scripts")]
        public void ExportCompleteSchema()
        {
            new SchemaExport(cfg).Execute(true, false, false);
            Assert.Pass();
        }

        [Test, Explicit("Generates Schema Update Scripts")]
        public void ExportSchemaUpdate()
        {
            new SchemaUpdate(cfg).Execute(true, false);
            Assert.Pass();
        }
    }
}
