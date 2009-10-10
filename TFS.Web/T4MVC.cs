﻿// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments
#pragma warning disable 1591
#region T4MVC

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;

[CompilerGenerated]
public static class MVC {
    public static TFS.Web.Controllers.DashboardController Dashboard = new T4MVC_DashboardController();
    public static T4MVC.SharedController Shared = new T4MVC.SharedController();
}


namespace TFS.Web.Controllers {
    public partial class DashboardController {

        public DashboardController() { }

        [CompilerGenerated]
        protected DashboardController(Dummy d) { }

        protected RedirectToRouteResult RedirectToAction(ActionResult result) {
            var callInfo = (IT4MVCActionResult)result;
            return RedirectToRoute(callInfo.RouteValues);
        }


        [CompilerGenerated]
        public readonly string Name = "Dashboard";

        static readonly ActionNames s_actions = new ActionNames();
        [CompilerGenerated]
        public ActionNames Actions { get { return s_actions; } }
        [CompilerGenerated]
        public class ActionNames {
            public readonly string Index = "Index";
        }


        static readonly ViewNames s_views = new ViewNames();
        [CompilerGenerated]
        public ViewNames Views { get { return s_views; } }
        [CompilerGenerated]
        public class ViewNames {
        }
    }
}
namespace T4MVC {
    public class SharedController {


        static readonly ViewNames s_views = new ViewNames();
        [CompilerGenerated]
        public ViewNames Views { get { return s_views; } }
        [CompilerGenerated]
        public class ViewNames {
        }
    }
}

namespace T4MVC {
    [CompilerGenerated]
    public class T4MVC_DashboardController: TFS.Web.Controllers.DashboardController {
        public T4MVC_DashboardController() : base(Dummy.Instance) { }

        public override System.Web.Mvc.ViewResult Index() {
            var callInfo = new T4MVC_ViewResult("Dashboard", Actions.Index);
            return callInfo;
        }

    }

    [CompilerGenerated]
    public class Dummy {
        private Dummy() { }
        public static Dummy Instance = new Dummy();
    }
}

namespace System.Web.Mvc {
    [CompilerGenerated]
    public static class T4Extensions {
        public static string ActionLink(this HtmlHelper htmlHelper, string linkText, ActionResult result) {
            return htmlHelper.RouteLink(linkText, result.GetRouteValueDictionary());
        }

        public static string ActionLink(this HtmlHelper htmlHelper, string linkText, ActionResult result, object htmlAttributes) {
            return ActionLink(htmlHelper, linkText, result, new RouteValueDictionary(htmlAttributes));
        }

        public static string ActionLink(this HtmlHelper htmlHelper, string linkText, ActionResult result, IDictionary<string, object> htmlAttributes) {
            return htmlHelper.RouteLink(linkText, result.GetRouteValueDictionary(), htmlAttributes);
        }

        public static MvcForm BeginForm(this HtmlHelper htmlHelper, ActionResult result, FormMethod formMethod) {
            return htmlHelper.BeginForm(result, formMethod, null);
        }

        public static MvcForm BeginForm(this HtmlHelper htmlHelper, ActionResult result, FormMethod formMethod, object htmlAttributes) {
            return BeginForm(htmlHelper, result, formMethod, new RouteValueDictionary(htmlAttributes));
        }

        public static MvcForm BeginForm(this HtmlHelper htmlHelper, ActionResult result, FormMethod formMethod, IDictionary<string, object> htmlAttributes) {
            var callInfo = (IT4MVCActionResult)result;
            return htmlHelper.BeginForm(callInfo.Action, callInfo.Controller, callInfo.RouteValues, formMethod, htmlAttributes);
        }

        public static string Action(this UrlHelper urlHelper, ActionResult result) {
            return urlHelper.RouteUrl(result.GetRouteValueDictionary());
        }

        public static string ActionLink(this AjaxHelper ajaxHelper, string linkText, ActionResult result, AjaxOptions ajaxOptions) {
            return ajaxHelper.RouteLink(linkText, result.GetRouteValueDictionary(), ajaxOptions);
        }

        public static string ActionLink(this AjaxHelper ajaxHelper, string linkText, ActionResult result, AjaxOptions ajaxOptions, object htmlAttributes) {
            return ajaxHelper.RouteLink(linkText, result.GetRouteValueDictionary(), ajaxOptions, new RouteValueDictionary(htmlAttributes));
        }

        public static string ActionLink(this AjaxHelper ajaxHelper, string linkText, ActionResult result, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes) {
            return ajaxHelper.RouteLink(linkText, result.GetRouteValueDictionary(), ajaxOptions, htmlAttributes);
        }

        public static Route MapRoute(this RouteCollection routes, string name, string url, ActionResult result) {
            return routes.MapRoute(name, url, result, (ActionResult)null);
        }

        public static Route MapRoute(this RouteCollection routes, string name, string url, ActionResult result, object defaults) {
            // Start by adding the default values from the anonymous object (if any)
            var routeValues = new RouteValueDictionary(defaults);

            // Then add the Controller/Action names and the parameters from the call
            foreach (var pair in result.GetRouteValueDictionary()) {
                routeValues.Add(pair.Key, pair.Value);
            }

            // Create and add the route
            var route = new Route(url, routeValues, new MvcRouteHandler());
            routes.Add(name, route);
            return route;
        }

        public static RouteValueDictionary GetRouteValueDictionary(this ActionResult result) {
            return ((IT4MVCActionResult)result).RouteValues;
        }

        public static void InitMVCT4Result(this IT4MVCActionResult result, string controller, string action) {
            result.Controller = controller;
            result.Action = action; ;
            result.RouteValues = new RouteValueDictionary();
            result.RouteValues.Add("Controller", controller);
            result.RouteValues.Add("Action", action);
        }
    }
}

[CompilerGenerated]
public interface IT4MVCActionResult {
    string Action { get; set; }
    string Controller { get; set; }
    RouteValueDictionary RouteValues { get; set; }
}

[CompilerGenerated]
public class T4MVC_ViewResult : System.Web.Mvc.ViewResult, IT4MVCActionResult {
    public T4MVC_ViewResult(string controller, string action): base()  {
        this.InitMVCT4Result(controller, action);
    }
    
    public string Controller { get; set; }
    public string Action { get; set; }
    public RouteValueDictionary RouteValues { get; set; }
}


namespace Links {
    [CompilerGenerated]
    public static class @Scripts {
        public static string Url() { return T4MVCHelpers.ProcessVirtualPath("~/Scripts"); }
        public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath("~/Scripts/" + fileName); }
        public static readonly string jquery_1_3_2_vsdoc_js = Url("jquery-1.3.2-vsdoc.js");
        public static readonly string jquery_1_3_2_js = Url("jquery-1.3.2.js");
        public static readonly string jquery_1_3_2_min_vsdoc_js = Url("jquery-1.3.2.min-vsdoc.js");
        public static readonly string jquery_1_3_2_min_js = Url("jquery-1.3.2.min.js");
    }

    [CompilerGenerated]
    public static class @Content {
        public static string Url() { return T4MVCHelpers.ProcessVirtualPath("~/Content"); }
        public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath("~/Content/" + fileName); }
    }

}

static class T4MVCHelpers {
    // You can change the ProcessVirtualPath method to modify the path that gets returned to the client.
    // e.g. you can prepend a domain, or append a query string:
    //      return "http://localhost" + path + "?foo=bar";
    public static string ProcessVirtualPath(string virtualPath) {
        // The path that comes in starts with ~/ and must first be made absolute
        string path = VirtualPathUtility.ToAbsolute(virtualPath);
        
        // Add your own modifications here before returning the path
        return path;
    }
}


#endregion T4MVC
#pragma warning restore 1591


