using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using TFS.Models.Site;
using Centro.Web.Mvc.ActionFilters;

namespace TFS.Web.Controllers
{
    public partial class SiteController : Controller
    {
        private const string URI_HOME = "/home";
        private const string URI_SERVICES = "/services";
        private const string URI_PROGRAMS = "/programs";
        private const string URI_EXPERIENCE = "/experience";
        private const string URI_CONTACT = "/contact";
        private readonly ISiteRepository siteRepository;

        public SiteController(ISiteRepository siteRepository)
        {
            this.siteRepository = siteRepository;
        }

        [RequireTransaction]
        public virtual RedirectToRouteResult Index()
        {
            return this.RedirectToAction(MVC.Site.Actions.Home);
        }

        [RequireTransaction]
        public virtual ViewResult Home()
        {
            var page = siteRepository.GetPage(URI_HOME);
            return View(MVC.Site.Views.SitePage, page);
        }

        [RequireTransaction]
        public virtual ViewResult Services()
        {
            var page = siteRepository.GetPage(URI_SERVICES);
            return View(MVC.Site.Views.SitePage, page);
        }

        [RequireTransaction]
        public virtual ViewResult Programs()
        {
            var page = siteRepository.GetPage(URI_PROGRAMS);
            return View(MVC.Site.Views.SitePage, page);
        }

        [RequireTransaction]
        public virtual ViewResult Experience()
        {
            var page = siteRepository.GetPage(URI_EXPERIENCE);
            return View(MVC.Site.Views.SitePage, page);
        }

        [RequireTransaction]
        public virtual ViewResult Contact()
        {
            var page = siteRepository.GetPage(URI_CONTACT);
            return View(MVC.Site.Views.SitePage, page);
        }
    }
}
