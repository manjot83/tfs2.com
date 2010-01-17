using System;
using StructureMap;

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