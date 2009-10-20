using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using TFS.Models.Programs;
using TFS.Web.ViewModels;

namespace TFS.Web.Controllers
{
    [Authorize]
    public partial class ProgramsController : Controller
    {
        private readonly IProgramsRepository programsRepository;

        public ProgramsController(IProgramsRepository programsRepository)
        {
            this.programsRepository = programsRepository;
        }

        public virtual ViewResult Manage()
        {
            var viewModel = new ManageProgramsViewModel();
            viewModel.ActivePositions = programsRepository.GetAllPositions();
            return View(viewModel);
        }

        public virtual RedirectToRouteResult AddNewPosition(string title)
        {
            programsRepository.CreateNewPosition(title);
            return RedirectToRoute(MVC.Programs.Manage());
        }

    }
}
