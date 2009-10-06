using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace TFS.Security
{
    public static class Utility
    {
        public static String GetUsername()
        {
            String name = HttpContext.Current.Request.Params["username"];
            if (String.IsNullOrEmpty(name))
                name = HttpContext.Current.User.Identity.Name;
            return name.Substring(name.IndexOf('\\') + 1);
        }

        public static bool IsCurrentUserInRole(string role)
        {
            return HttpContext.Current.User.IsInRole(role);
        }
    }
}
