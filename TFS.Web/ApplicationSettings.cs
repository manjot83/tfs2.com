using System.Collections.Specialized;
using System.Configuration;

namespace TFS.Web
{
    public class ApplicationSettings : IApplicationSettings
    {
        public const string AuthenticationServiceKey = "AuthenticationService";
        public const string ChangePasswordServiceKey = "ChangePasswordService";

        private NameValueCollection settings;

        public ApplicationSettings()
            : this(ConfigurationManager.AppSettings)
        {
        }

        public ApplicationSettings(NameValueCollection settings)
        {
            this.settings = settings;
        }

        public string AuthenticationService { get { return settings[AuthenticationServiceKey]; } }

        public string ChangePasswordService { get { return settings[ChangePasswordServiceKey]; } }
    }
}
