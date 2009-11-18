using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TFS.Extensions;

namespace TFS.Web
{
    public static class ApplicationVersion
    {
        public static string GetVersion()
        {
            return typeof(ApplicationVersion).Assembly.GetVersion();
        }
    }
}
