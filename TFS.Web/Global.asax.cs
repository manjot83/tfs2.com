using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Security.Principal;
using StructureMap;
using NHibernate;
using TFS.Models.Users;

namespace TFS.Web
{
    public class MvcApplication : System.Web.HttpApplication, ICanResolveDependencies
    {
        protected void Application_Start()
        {
            MvcBootstrapper.SetupApplication();
        }

        public object Resolve(Type type)
        {
            return ObjectFactory.GetInstance(type);
        }

        public TObject Resolve<TObject>()
        {
            return ObjectFactory.GetInstance<TObject>();
        }
    }
}