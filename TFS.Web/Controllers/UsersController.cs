using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using TFS.Models;
using TFS.Web.ViewModels;
using System.Web.UI.WebControls;

namespace TFS.Web.Controllers
{
    public partial class UsersController : Controller
    {
        private readonly IUserRepository userRepository;

        public UsersController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public virtual ActionResult Index()
        {
            return RedirectToAction(MVC.Users.List());
        }

        public virtual ViewResult List(UserSortType? sortType, SortDirection? sortDirection)
        {
            var users = userRepository.GetUsers();
            return View(users);
        }

        public virtual ViewResult Edit(string username)
        {
            throw new NotImplementedException();
        }

    }
}
