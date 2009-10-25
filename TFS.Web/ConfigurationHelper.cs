using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace TFS.Web
{
    public static class ConfigurationHelper
    {
        public const string AuthenticationServiceKey = "AuthenticationService";
        public const string ChangePasswordServiceKey = "ChangePasswordService";

        public static string AuthenticationService
        {
            get
            {
                return ConfigurationManager.AppSettings[AuthenticationServiceKey];
            }
        }

        public static string ChangePasswordService
        {
            get
            {
                return ConfigurationManager.AppSettings[ChangePasswordServiceKey];
            }
        }
    }
}
