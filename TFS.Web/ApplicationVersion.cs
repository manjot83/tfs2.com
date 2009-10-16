using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Centro.Extensions;

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
