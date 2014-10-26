using System;
using System.IO;
using System.Reflection;
using System.Web;
using StructureMap;

namespace TFS.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        [System.Runtime.InteropServices.DllImport("kernel32", SetLastError = true)]
        static extern IntPtr LoadLibrary(string lpFileName);

        protected void Application_Start()
        {
            if (Environment.Version.Major >= 4)
            {
                string folder = HttpContext.Current.Server.MapPath("~/bin");
                folder = Path.GetFullPath(folder);
                LoadLibrary(Path.Combine(folder, "vjsnativ.dll"));
            }

            MvcBootstrapper.SetupApplication();
        }

        // Legacy Container reference for DomainRoleProvider
        public static IContainer Container { get; set; }
    }
}