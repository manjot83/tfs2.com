using System.Collections.Generic;
using System.Reflection;
using Centro.NHibernateUtils;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using TFS.Models.Data;

namespace TFS.Models.Tests
{
    [TestFixture]
    public class MSSqlSchemaTests
    {
        [Test, Explicit]
        public void GenerateSchema()
        {
            var mappingAssemblies = new List<Assembly> { typeof(UserMapping).Assembly };
            var fluentConfiguration = new FluentConfigurationBuilder(MsSqlConfiguration.MsSql2005.ConnectionString(@"Server=.\SQLEXPRESS;Database=dev_tfs2.com;Trusted_Connection=yes;"), mappingAssemblies);
            new SchemaExport(fluentConfiguration.Configuration).Create(true, false);
        }
    }
}
