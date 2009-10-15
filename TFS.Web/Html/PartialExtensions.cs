using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Web.Mvc;
using System.Web.Mvc;

namespace TFS.Web.Html
{
    public static class PartialExtensions
    {
        public static void RenderAction(this HtmlHelper htmlHelper, ActionResult actionResult)
        {
            htmlHelper.RenderRoute(actionResult.GetRouteValueDictionary());
        }
    }
}
