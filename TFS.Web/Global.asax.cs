using System;
using StructureMap;

namespace TFS.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            MvcBootstrapper.SetupApplication();
        }

        // Legacy Container reference for DomainRoleProvider
        public static IContainer Container { get; set; }
    }
}