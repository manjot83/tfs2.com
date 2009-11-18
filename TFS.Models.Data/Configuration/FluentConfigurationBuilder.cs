using System.Collections.Generic;
using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

namespace TFS.Models.Data.Configuration
{
    public class FluentConfigurationBuilder
    {
        public static FluentConfiguration CreateFluentConfiguration(IPersistenceConfigurer databaseConfigurer, IEnumerable<Assembly> mappingAssemblies)
        {
            var configuration = new NHibernate.Cfg.Configuration();
            return Fluently.Configure(configuration)
                .Database(databaseConfigurer)
                .Mappings(m =>
                    {
                        foreach (var assembly in mappingAssemblies)
                            m.FluentMappings.AddFromAssembly(assembly);
                        foreach (var assembly in mappingAssemblies)
                            m.HbmMappings.AddFromAssembly(assembly);
                    });
        }
    }
}
