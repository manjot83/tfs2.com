using System.Collections.Generic;
using System.IO;
using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

namespace TFS.Models.Data.Configuration
{
    public static class SQLiteBuilder
    {
        public static FluentConfiguration CreateConfiguration(string databaseIdentifier, IEnumerable<Assembly> mappingAssemblies)
        {
            var dbPath = new FileInfo(Path.GetTempPath() + databaseIdentifier + ".sqlite");
            dbPath.Delete();

            var configurer = SQLiteConfiguration.Standard.ConnectionString(c => c.Is(string.Format("Data Source={0};Version=3;New=True;BinaryGuid=False", dbPath.FullName)));
            var config = FluentConfigurationBuilder.CreateFluentConfiguration(configurer, mappingAssemblies);
            return config;
        }

        public static FluentConfiguration CreateConfiguration(IEnumerable<Assembly> mappingAssemblies)
        {
            var config = FluentConfigurationBuilder.CreateFluentConfiguration(SQLiteConfiguration.Standard.InMemory(), mappingAssemblies);
            return config;
        }
    }
}
