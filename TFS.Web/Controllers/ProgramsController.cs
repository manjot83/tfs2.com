using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using TFS.Models.Programs;
using TFS.Web.ViewModels;
using TFS.Web.ActionFilters;

namespace TFS.Web.Controllers
{
    [DomainAuthorize]
    public partial class ProgramsController : Controller
    {
        private readonly IProgramsManager programsManager;

        public ProgramsController(IProgramsManager programsManager)
        {
            this.programsManager = programsManager;
        }

        [RequireTransaction]
        public virtual ViewResult Manage()
        {
            var viewModel = new ManageProgramsViewModel();
            viewModel.ActivePositions = programsManager.GetAllPositions();
            return View(viewModel);
        }

        [RequireTransaction]
        public virtual RedirectToRouteResult AddNewPosition(string title)
        {
            programsManager.CreateNewPosition(title);
            return RedirectToRoute(MVC.Programs.Manage());
        }

    }
}
