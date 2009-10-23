using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using TFS.Models;
using TFS.Web.ViewModels;
using System.Web.UI.WebControls;
using Centro.Extensions;
using Centro.Web.Mvc.ActionFilters;
using Centro.Web.Mvc;

namespace TFS.Web.Controllers
{
    [Authorize]
    public partial class UsersController : Controller
    {
        private readonly IUserRepository userRepository;

        public UsersController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public virtual ViewResult Index()
        {
            return List(null, null);
        }

        public virtual ViewResult List(string sortType, SortDirection? sortDirection)
        {
            if (string.IsNullOrEmpty(sortType))
                sortType = "name";
            if (sortDirection == null)
                sortDirection = SortDirection.Ascending;
            var viewModel = new SortedListViewModel<User>();
            viewModel.SortDirection = sortDirection ?? SortDirection.Ascending;
            viewModel.SortType = sortType;
            var users = userRepository.GetUsers();
            if (viewModel.IsCurrentSortType("name") && viewModel.SortDirection == SortDirection.Ascending)
                users = users.OrderBy(x => x.LastName);
            else if (viewModel.IsCurrentSortType("name"))
                users = users.OrderByDescending(x => x.LastName);
            else if (viewModel.IsCurrentSortType("username") && viewModel.SortDirection == SortDirection.Ascending)
                users = users.OrderBy(x => x.Username);
            else if (viewModel.IsCurrentSortType("username"))
                users = users.OrderByDescending(x => x.Username);
            else if (viewModel.IsCurrentSortType("email") && viewModel.SortDirection == SortDirection.Ascending)
                users = users.OrderBy(x => x.Email);
            else if (viewModel.IsCurrentSortType("email"))
                users = users.OrderByDescending(x => x.Email);
            else if (viewModel.IsCurrentSortType("status") && viewModel.SortDirection == SortDirection.Ascending)
                users = users.OrderBy(x => x.Disabled);
            else if (viewModel.IsCurrentSortType("status"))
                users = users.OrderByDescending(x => x.Disabled);
            viewModel.Items = users;
            return View(Views.List, viewModel);
        }

        public virtual ViewResult Edit(string username)
        {
            throw new NotImplementedException();
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public virtual ViewResult Create()
        {
            return View(new UserViewModel());
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [RequireTransaction]
        public virtual ActionResult Create(UserViewModel user)
        {
            user.Validate(ModelState, string.Empty);
            if (!user.PasswordConfirmed())
                ModelState.AddModelError("password", "Passwords must match.");
            if (ModelState.IsValid && userRepository.GetUser(user.Username) != null)
                ModelState.AddModelError("username", "Username must be unique.");
            if (!ModelState.IsValid)
                return View(user);
            var newUser = userRepository.CreateUser(user.Username, user.FirstName, user.LastName, user.DisplayName);
            userRepository.ResetPasswordAsAdmin(newUser, user.Password);
            return RedirectToAction(MVC.Users.List());
        }
    }
}
