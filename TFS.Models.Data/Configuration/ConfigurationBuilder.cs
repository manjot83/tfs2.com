using System.Collections.Generic;
using System.IO;
using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

namespace TFS.Models.Data.Configuration
{
    public static class ConfigurationBuilder
    {
        public static NHibernate.Cfg.Configuration CreateMsSql2005Configuration(string sqlServerAddress, string username,
                                                                                string password, string database, string applicationName, IEnumerable<Assembly> mappingAssemblies)
        {
            var connectionString = string.Format("Data Source={0};Initial Catalog={1};User Id={2};Password={3};Application Name={4};", sqlServerAddress, database, username, password, applicationName);
            var configurer = MsSqlConfiguration.MsSql2005.ConnectionString(c => c.Is(connectionString));
            return CreateFluentConfiguration(configurer, mappingAssemblies);
        }

        public static NHibernate.Cfg.Configuration CreateMsSql2005Configuration(string connectionStringKey, IEnumerable<Assembly> mappingAssemblies)
        {
            var configurer = MsSqlConfiguration.MsSql2005.ConnectionString(c => c.FromConnectionStringWithKey(connectionStringKey));
            return CreateFluentConfiguration(configurer, mappingAssemblies);
        }
        
        public static NHibernate.Cfg.Configuration CreateMsSql2005Configuration(string sqlServerAddress, string databaseName, IEnumerable<Assembly> mappingAssemblies)
        {
            var configurer = MsSqlConfiguration.MsSql2005.ConnectionString(c => c.Server(sqlServerAddress).Database(databaseName).TrustedConnection());
            return CreateFluentConfiguration(configurer, mappingAssemblies);
        }

        public static NHibernate.Cfg.Configuration CreateFileBasedSQLiteConfiguration(string databaseIdentifier, IEnumerable<Assembly> mappingAssemblies)
        {
            var dbPath = new FileInfo(Path.GetTempPath() + databaseIdentifier + ".sqlite");
            dbPath.Delete();
            var configurer = SQLiteConfiguration.Standard.ConnectionString(c => c.Is(string.Format("Data Source={0};Version=3;New=True;BinaryGuid=False", dbPath.FullName)));
            return CreateFluentConfiguration(configurer, mappingAssemblies);
        }

        public static NHibernate.Cfg.Configuration CreateInMemorySQLiteConfiguration(IEnumerable<Assembly> mappingAssemblies)
        {
            return CreateFluentConfiguration(SQLiteConfiguration.Standard.InMemory(), mappingAssemblies);
        }

        public static NHibernate.Cfg.Configuration CreateFluentConfiguration(IPersistenceConfigurer persistenceConfigurer, IEnumerable<Assembly> mappingAssemblies)
        {
            return Fluently.Configure()
                .Database(persistenceConfigurer)
                .Mappings(m =>
                {
                    foreach (var assembly in mappingAssemblies)
                    {
                        m.FluentMappings.AddFromAssembly(assembly);
                        //m.HbmMappings.AddFromAssembly(assembly);
                    }
                })
                .ExposeConfiguration(c =>
                {
                    c.SetProperty(NHibernate.Cfg.Environment.BatchSize, "20");
                    c.SetProperty(NHibernate.Cfg.Environment.GenerateStatistics, "true");
                })
                .BuildConfiguration();
        }
    }
}
