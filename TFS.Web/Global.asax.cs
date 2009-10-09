﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TFS.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            MVCConfiguration.RegisterRoutes(RouteTable.Routes);
            MVCConfiguration.InitializeIoCAndDataAccess();
        }
    }
}