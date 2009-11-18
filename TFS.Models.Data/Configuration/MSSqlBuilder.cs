using System.Collections.Generic;
using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

namespace TFS.Models.Data.Configuration
{
    public class MSSqlBuilder
    {
        public static FluentConfiguration CreateConfiguration(string connectionStringKey,
                                                              IEnumerable<Assembly> mappingAssemblies)
        {
            var configurer = MsSqlConfiguration.MsSql2005.ConnectionString(c => c.FromConnectionStringWithKey(connectionStringKey));
            var config = FluentConfigurationBuilder.CreateFluentConfiguration(configurer, mappingAssemblies);
            return config;
        }

        public static FluentConfiguration CreateConfiguration(string sqlServerAddress, string username, string password, string database, IEnumerable<Assembly> mappingAssemblies)
        {
            var configurer = MsSqlConfiguration.MsSql2005.ConnectionString(c => c.Server(sqlServerAddress)
                                                                                     .Username(username)
                                                                                     .Password(password)
                                                                                     .Database(database));
            var config = FluentConfigurationBuilder.CreateFluentConfiguration(configurer, mappingAssemblies);
            return config;
        }
    }
}
