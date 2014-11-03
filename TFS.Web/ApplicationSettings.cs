using System.Collections.Specialized;
using System.Configuration;

namespace TFS.Web
{
    public class ApplicationSettings : IApplicationSettings
    {
        private NameValueCollection settings;

        public ApplicationSettings()
            : this(ConfigurationManager.AppSettings)
        {
        }

        public ApplicationSettings(NameValueCollection settings)
        {
            this.settings = settings;
        }
    }
}
