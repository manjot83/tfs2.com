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
    public static TFS.Web.Controllers.ImagesController Images = new T4MVC_ImagesController();
    public static TFS.Web.Controllers.ProgramsController Programs = new T4MVC_ProgramsController();
    public static TFS.Web.Controllers.SecurityController Security = new T4MVC_SecurityController();
    public static TFS.Web.Controllers.SiteController Site = new T4MVC_SiteController();
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
            public readonly string GenerateSideBar = "GenerateSideBar";
        }


        static readonly ViewNames s_views = new ViewNames();
        [CompilerGenerated]
        public ViewNames Views { get { return s_views; } }
        [CompilerGenerated]
        public class ViewNames {
            public readonly string Index = "Index";
        }
    }
}
namespace TFS.Web.Controllers {
    public partial class ImagesController {

        [CompilerGenerated]
        protected ImagesController(Dummy d) { }

        protected RedirectToRouteResult RedirectToAction(ActionResult result) {
            var callInfo = (IT4MVCActionResult)result;
            return RedirectToRoute(callInfo.RouteValues);
        }

        [NonAction]
        public ActionResult StaticImage() {
            return new T4MVC_ActionResult(Name, Actions.StaticImage);
        }


        [CompilerGenerated]
        public readonly string Name = "Images";

        static readonly ActionNames s_actions = new ActionNames();
        [CompilerGenerated]
        public ActionNames Actions { get { return s_actions; } }
        [CompilerGenerated]
        public class ActionNames {
            public readonly string StaticImage = "StaticImage";
        }


        static readonly ViewNames s_views = new ViewNames();
        [CompilerGenerated]
        public ViewNames Views { get { return s_views; } }
        [CompilerGenerated]
        public class ViewNames {
        }
    }
}
namespace TFS.Web.Controllers {
    public partial class ProgramsController {

        [CompilerGenerated]
        protected ProgramsController(Dummy d) { }

        protected RedirectToRouteResult RedirectToAction(ActionResult result) {
            var callInfo = (IT4MVCActionResult)result;
            return RedirectToRoute(callInfo.RouteValues);
        }

        [NonAction]
        public ActionResult AddNewPosition() {
            return new T4MVC_ActionResult(Name, Actions.AddNewPosition);
        }


        [CompilerGenerated]
        public readonly string Name = "Programs";

        static readonly ActionNames s_actions = new ActionNames();
        [CompilerGenerated]
        public ActionNames Actions { get { return s_actions; } }
        [CompilerGenerated]
        public class ActionNames {
            public readonly string Manage = "Manage";
            public readonly string AddNewPosition = "AddNewPosition";
        }


        static readonly ViewNames s_views = new ViewNames();
        [CompilerGenerated]
        public ViewNames Views { get { return s_views; } }
        [CompilerGenerated]
        public class ViewNames {
            public readonly string Manage = "Manage";
        }
    }
}
namespace TFS.Web.Controllers {
    public partial class SecurityController {

        [CompilerGenerated]
        protected SecurityController(Dummy d) { }

        protected RedirectToRouteResult RedirectToAction(ActionResult result) {
            var callInfo = (IT4MVCActionResult)result;
            return RedirectToRoute(callInfo.RouteValues);
        }

        [NonAction]
        public ActionResult LogOn() {
            return new T4MVC_ActionResult(Name, Actions.LogOn);
        }


        [CompilerGenerated]
        public readonly string Name = "Security";

        static readonly ActionNames s_actions = new ActionNames();
        [CompilerGenerated]
        public ActionNames Actions { get { return s_actions; } }
        [CompilerGenerated]
        public class ActionNames {
            public readonly string LogOn = "LogOn";
            public readonly string LogOff = "LogOff";
        }


        static readonly ViewNames s_views = new ViewNames();
        [CompilerGenerated]
        public ViewNames Views { get { return s_views; } }
        [CompilerGenerated]
        public class ViewNames {
            public readonly string LogOn = "LogOn";
        }
    }
}
namespace TFS.Web.Controllers {
    public partial class SiteController {

        [CompilerGenerated]
        protected SiteController(Dummy d) { }

        protected RedirectToRouteResult RedirectToAction(ActionResult result) {
            var callInfo = (IT4MVCActionResult)result;
            return RedirectToRoute(callInfo.RouteValues);
        }


        [CompilerGenerated]
        public readonly string Name = "Site";

        static readonly ActionNames s_actions = new ActionNames();
        [CompilerGenerated]
        public ActionNames Actions { get { return s_actions; } }
        [CompilerGenerated]
        public class ActionNames {
            public readonly string Index = "Index";
            public readonly string Home = "Home";
            public readonly string Services = "Services";
            public readonly string Programs = "Programs";
            public readonly string Experience = "Experience";
            public readonly string Contact = "Contact";
        }


        static readonly ViewNames s_views = new ViewNames();
        [CompilerGenerated]
        public ViewNames Views { get { return s_views; } }
        [CompilerGenerated]
        public class ViewNames {
            public readonly string SitePage = "SitePage";
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
            public readonly string DashboardSideBar = "DashboardSideBar";
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

        public override System.Web.Mvc.ViewResult GenerateSideBar() {
            var callInfo = new T4MVC_ViewResult("Dashboard", Actions.GenerateSideBar);
            return callInfo;
        }

    }
    [CompilerGenerated]
    public class T4MVC_ImagesController: TFS.Web.Controllers.ImagesController {
        public T4MVC_ImagesController() : base(Dummy.Instance) { }

        public override System.Web.Mvc.ActionResult StaticImage(System.Guid id) {
            var callInfo = new T4MVC_ActionResult("Images", Actions.StaticImage);
            callInfo.RouteValues.Add("id", id);
            return callInfo;
        }

    }
    [CompilerGenerated]
    public class T4MVC_ProgramsController: TFS.Web.Controllers.ProgramsController {
        public T4MVC_ProgramsController() : base(Dummy.Instance) { }

        public override System.Web.Mvc.ViewResult Manage() {
            var callInfo = new T4MVC_ViewResult("Programs", Actions.Manage);
            return callInfo;
        }

        public override System.Web.Mvc.RedirectToRouteResult AddNewPosition(string title) {
            var callInfo = new T4MVC_RedirectToRouteResult("Programs", Actions.AddNewPosition);
            callInfo.RouteValues.Add("title", title);
            return callInfo;
        }

    }
    [CompilerGenerated]
    public class T4MVC_SecurityController: TFS.Web.Controllers.SecurityController {
        public T4MVC_SecurityController() : base(Dummy.Instance) { }

        public override System.Web.Mvc.ViewResult LogOn(System.Uri returnUrl) {
            var callInfo = new T4MVC_ViewResult("Security", Actions.LogOn);
            callInfo.RouteValues.Add("returnUrl", returnUrl);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult LogOn(string userName, string password, bool rememberMe, System.Uri returnUrl) {
            var callInfo = new T4MVC_ActionResult("Security", Actions.LogOn);
            callInfo.RouteValues.Add("userName", userName);
            callInfo.RouteValues.Add("password", password);
            callInfo.RouteValues.Add("rememberMe", rememberMe);
            callInfo.RouteValues.Add("returnUrl", returnUrl);
            return callInfo;
        }

        public override System.Web.Mvc.RedirectToRouteResult LogOff() {
            var callInfo = new T4MVC_RedirectToRouteResult("Security", Actions.LogOff);
            return callInfo;
        }

    }
    [CompilerGenerated]
    public class T4MVC_SiteController: TFS.Web.Controllers.SiteController {
        public T4MVC_SiteController() : base(Dummy.Instance) { }

        public override System.Web.Mvc.RedirectToRouteResult Index() {
            var callInfo = new T4MVC_RedirectToRouteResult("Site", Actions.Index);
            return callInfo;
        }

        public override System.Web.Mvc.ViewResult Home() {
            var callInfo = new T4MVC_ViewResult("Site", Actions.Home);
            return callInfo;
        }

        public override System.Web.Mvc.ViewResult Services() {
            var callInfo = new T4MVC_ViewResult("Site", Actions.Services);
            return callInfo;
        }

        public override System.Web.Mvc.ViewResult Programs() {
            var callInfo = new T4MVC_ViewResult("Site", Actions.Programs);
            return callInfo;
        }

        public override System.Web.Mvc.ViewResult Experience() {
            var callInfo = new T4MVC_ViewResult("Site", Actions.Experience);
            return callInfo;
        }

        public override System.Web.Mvc.ViewResult Contact() {
            var callInfo = new T4MVC_ViewResult("Site", Actions.Contact);
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

[CompilerGenerated]
public class T4MVC_ActionResult : System.Web.Mvc.ActionResult, IT4MVCActionResult {
    public T4MVC_ActionResult(string controller, string action): base()  {
        this.InitMVCT4Result(controller, action);
    }
     
    public override void ExecuteResult(System.Web.Mvc.ControllerContext context) { }
    
    public string Controller { get; set; }
    public string Action { get; set; }
    public RouteValueDictionary RouteValues { get; set; }
}

[CompilerGenerated]
public class T4MVC_RedirectToRouteResult : System.Web.Mvc.RedirectToRouteResult, IT4MVCActionResult {
    public T4MVC_RedirectToRouteResult(string controller, string action): base(" ", null)  {
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
        [CompilerGenerated]
        public static class @internal {
            public static string Url() { return T4MVCHelpers.ProcessVirtualPath("~/Content/internal"); }
            public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath("~/Content/internal/" + fileName); }
            public static readonly string default_css = Url("default.css");
            [CompilerGenerated]
            public static class @icons {
                public static string Url() { return T4MVCHelpers.ProcessVirtualPath("~/Content/internal/icons"); }
                public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath("~/Content/internal/icons/" + fileName); }
                public static readonly string book_png = Url("book.png");
                public static readonly string group_png = Url("group.png");
                public static readonly string vcard_png = Url("vcard.png");
                public static readonly string world_png = Url("world.png");
            }
        
            [CompilerGenerated]
            public static class @images {
                public static string Url() { return T4MVCHelpers.ProcessVirtualPath("~/Content/internal/images"); }
                public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath("~/Content/internal/images/" + fileName); }
                public static readonly string calendarSelector_png = Url("calendarSelector.png");
            }
        
            [CompilerGenerated]
            public static class @template {
                public static string Url() { return T4MVCHelpers.ProcessVirtualPath("~/Content/internal/template"); }
                public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath("~/Content/internal/template/" + fileName); }
                public static readonly string bg_gif = Url("bg.gif");
                public static readonly string bgcontainer_gif = Url("bgcontainer.gif");
                public static readonly string bgfooter_gif = Url("bgfooter.gif");
                public static readonly string bgheader_gif = Url("bgheader.gif");
                public static readonly string bgnavigation_gif = Url("bgnavigation.gif");
                public static readonly string bgul_gif = Url("bgul.gif");
                public static readonly string li_gif = Url("li.gif");
                public static readonly string quote_gif = Url("quote.gif");
                public static readonly string sidenavh1_gif = Url("sidenavh1.gif");
            }
        
        }
    
        [CompilerGenerated]
        public static class @public {
            public static string Url() { return T4MVCHelpers.ProcessVirtualPath("~/Content/public"); }
            public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath("~/Content/public/" + fileName); }
            [CompilerGenerated]
            public static class @banners {
                public static string Url() { return T4MVCHelpers.ProcessVirtualPath("~/Content/public/banners"); }
                public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath("~/Content/public/banners/" + fileName); }
                public static readonly string aircrew_login_gif = Url("aircrew_login.gif");
                public static readonly string contact_gif = Url("contact.gif");
                public static readonly string experience_gif = Url("experience.gif");
                public static readonly string programs_gif = Url("programs.gif");
                public static readonly string services_gif = Url("services.gif");
                public static readonly string welcome_gif = Url("welcome.gif");
            }
        
            [CompilerGenerated]
            public static class @headers {
                public static string Url() { return T4MVCHelpers.ProcessVirtualPath("~/Content/public/headers"); }
                public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath("~/Content/public/headers/" + fileName); }
                public static readonly string header01_jpg = Url("header01.jpg");
                public static readonly string header02_jpg = Url("header02.jpg");
                public static readonly string header03_jpg = Url("header03.jpg");
                public static readonly string header04_jpg = Url("header04.jpg");
                public static readonly string header05_jpg = Url("header05.jpg");
            }
        
            public static readonly string imagerollover_css = Url("imagerollover.css");
            public static readonly string layout_css = Url("layout.css");
            [CompilerGenerated]
            public static class @login {
                public static string Url() { return T4MVCHelpers.ProcessVirtualPath("~/Content/public/login"); }
                public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath("~/Content/public/login/" + fileName); }
                public static readonly string index_r3_c1_jpg = Url("index_r3_c1.jpg");
                public static readonly string loginlayout_r1_c1_jpg = Url("loginlayout_r1_c1.jpg");
                public static readonly string loginlayout_r2_c1_jpg = Url("loginlayout_r2_c1.jpg");
                public static readonly string loginlayout_r3_c1_jpg = Url("loginlayout_r3_c1.jpg");
                public static readonly string loginlayout_r3_c2_jpg = Url("loginlayout_r3_c2.jpg");
                public static readonly string loginlayout_r3_c3_jpg = Url("loginlayout_r3_c3.jpg");
                public static readonly string loginlayout_r4_c1_jpg = Url("loginlayout_r4_c1.jpg");
                public static readonly string spacer_gif = Url("spacer.gif");
                public static readonly string submit_gif = Url("submit.gif");
            }
        
            [CompilerGenerated]
            public static class @rollovers {
                public static string Url() { return T4MVCHelpers.ProcessVirtualPath("~/Content/public/rollovers"); }
                public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath("~/Content/public/rollovers/" + fileName); }
                public static readonly string contact_gif = Url("contact.gif");
                public static readonly string contact_rollover_gif = Url("contact_rollover.gif");
                public static readonly string experience_gif = Url("experience.gif");
                public static readonly string experience_rollover_gif = Url("experience_rollover.gif");
                public static readonly string home_gif = Url("home.gif");
                public static readonly string home_rollover_gif = Url("home_rollover.gif");
                public static readonly string logon_gif = Url("logon.gif");
                public static readonly string logon_rollover_gif = Url("logon_rollover.gif");
                public static readonly string programs_gif = Url("programs.gif");
                public static readonly string programs_rollover_gif = Url("programs_rollover.gif");
                public static readonly string services_gif = Url("services.gif");
                public static readonly string services_rollover_gif = Url("services_rollover.gif");
            }
        
            public static readonly string tags_css = Url("tags.css");
            [CompilerGenerated]
            public static class @template {
                public static string Url() { return T4MVCHelpers.ProcessVirtualPath("~/Content/public/template"); }
                public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath("~/Content/public/template/" + fileName); }
                public static readonly string content_bg_gif = Url("content_bg.gif");
                public static readonly string footer_gif = Url("footer.gif");
                public static readonly string item_jpg = Url("item.jpg");
                public static readonly string item_hover_jpg = Url("item_hover.jpg");
                public static readonly string spacer_gif = Url("spacer.gif");
            }
        
        }
    
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


