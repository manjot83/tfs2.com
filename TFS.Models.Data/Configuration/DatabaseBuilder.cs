using System.Collections.Generic;
using NHibernate;
using NHibernate.Dialect;

namespace TFS.Models.Data.Configuration
{
    public class DatabaseBuilder
    {
        private readonly NHibernate.Cfg.Configuration configuration;
        private readonly ISession session;

        public DatabaseBuilder(NHibernate.Cfg.Configuration configuration, ISession session)
        {
            this.configuration = configuration;
            this.session = session;
        }

        public void BuildSchema()
        {
            var dialect = Dialect.GetDialect(configuration.Properties);
            var drops = configuration.GenerateDropSchemaScript(dialect);
            ExecuteSqlScripts(drops);

            var scripts = configuration.GenerateSchemaCreationScript(dialect);
            ExecuteSqlScripts(scripts);
        }

        private void ExecuteSqlScripts(IEnumerable<string> scripts)
        {
            foreach (var script in scripts)
            {
                var command = session.Connection.CreateCommand();
                command.CommandText = script;
                command.ExecuteNonQuery();
            }
        }
    }
}
