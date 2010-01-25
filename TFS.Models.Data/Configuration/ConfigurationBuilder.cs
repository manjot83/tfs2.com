using System.Collections.Generic;
using System.IO;
using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Bytecode;

namespace TFS.Models.Data.Configuration
{
    public class ConfigurationBuilder {
        public static NHibernate.Cfg.Configuration CreateMsSql2005Configuration(string connectionStringKey,
                                                                                IEnumerable<Assembly> mappingAssemblies) {
            var persistenceConfigurer = MsSqlConfiguration.MsSql2005.ConnectionString(c => c.FromConnectionStringWithKey(connectionStringKey));
            var config = ConfigurationBuilder.CreateFluentConfiguration(persistenceConfigurer, mappingAssemblies);
            return config;
        }

        public static NHibernate.Cfg.Configuration CreateMsSql2005Configuration(string sqlServerAddress,
                                                                                string username,
                                                                                string password,
                                                                                string database,
                                                                                IEnumerable<Assembly> mappingAssemblies) {
            var persistenceConfigurer = MsSqlConfiguration.MsSql2005.ConnectionString(c => c.Server(sqlServerAddress)
                                                                                     .Username(username)
                                                                                     .Password(password)
                                                                                     .Database(database));
            var config = ConfigurationBuilder.CreateFluentConfiguration(persistenceConfigurer, mappingAssemblies);
            return config;
        }

        public static NHibernate.Cfg.Configuration CreateFluentConfiguration(IPersistenceConfigurer persistenceConfigurer, IEnumerable<Assembly> mappingAssemblies) {
            return Fluently.Configure()
                .Database(persistenceConfigurer)
                .Mappings(m => {
                        foreach (var assembly in mappingAssemblies) {
                            m.FluentMappings.AddFromAssembly(assembly);
                            //m.HbmMappings.AddFromAssembly(assembly);
                        }
                    })
                .ExposeConfiguration(c => {
                        c.SetProperty(NHibernate.Cfg.Environment.BatchSize, "20");
                        c.SetProperty(NHibernate.Cfg.Environment.GenerateStatistics, "true");
                    })
                .BuildConfiguration();
        }

        public static void SetBytecodeProvider(IBytecodeProvider bytecodeProvider) {
            NHibernate.Cfg.Environment.BytecodeProvider = bytecodeProvider;
        }
    }
}
