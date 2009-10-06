using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Configuration;

namespace com.cridion.HTTPHandlers
{
    public class DynamicPageHTTPHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            String WhereTo = ConfigurationManager.AppSettings["DynamicPageRedirect"];
            context.Server.Transfer(WhereTo);
        }
    }
}
