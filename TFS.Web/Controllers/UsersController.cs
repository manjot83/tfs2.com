using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using TFS.Models;
using TFS.Web.ViewModels;
using TFS.Models.Users;
using AutoMapper;
using System.Collections.Generic;

namespace TFS.Web.Controllers
{
    [Authorize(Roles = RoleNames.UserManager)]
    public partial class UsersController : BaseController
    {
        private readonly IUserRepository userRepository;

        public UsersController(IApplicationSettings applicationSettings, IUserRepository userRepository)
            :base(applicationSettings, userRepository)
        {
            this.userRepository = userRepository;
        }

        public virtual ViewResult Index()
        {
            return List(null, null, null, null, null);
        }

        public virtual ViewResult List(string sortType, SortDirection? sortDirection, int? page, int? itemsPerPage, bool? showAll)
        {
            if (string.IsNullOrEmpty(sortType))
                sortType = "name";
            var viewModel = new SortedListViewModel<UserViewModel>()
            {
                ShowAll = showAll.HasValue && showAll.Value,
                SortDirection = sortDirection ?? SortDirection.Ascending,
                SortType = sortType,
                PagingEnabled = true,
                CurrentPage = page.HasValue ? page.Value : 1,
                ItemsPerPage = itemsPerPage.HasValue ? itemsPerPage.Value : SortedListViewModel<User>.DefaultItemsPerPage,
            };
            IEnumerable<User> users = null;
            if (viewModel.ShowAll)
                users = userRepository.GetAllUsers();
            else
                users = userRepository.GetAllActiveUsers();
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
            users = users.ToList();
            viewModel.TotalItems = users.Count();
            viewModel.SetItems(Mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(users));
            return View(Views.List, viewModel);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public virtual ViewResult Edit(string username)
        {
            var user = userRepository.GetUser(username);
            var viewModel = Mapper.Map<User, UserViewModel>(user);
            return View(viewModel);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult Edit(UserViewModel userViewModel)
        {
            this.Validate(userViewModel, string.Empty);
            if (!ModelState.IsValid)
                return View(userViewModel);
            var user = userRepository.GetUser(userViewModel.Username);
            Mapper.Map<UserViewModel, User>(userViewModel, user);
            return RedirectToAction(MVC.Users.List());
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public virtual ViewResult Create()
        {
            return View(new UserViewModel());
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult Create(UserViewModel userViewModel)
        {
            this.Validate(userViewModel, string.Empty);
            if (ModelState.IsValid && userRepository.GetUser(userViewModel.Username) != null)
                ModelState.AddModelError("username", "Username must be unique.");
            if (!ModelState.IsValid)
                return View(userViewModel);
            userRepository.CreateUser(userViewModel.Username, userViewModel.FirstName, userViewModel.LastName, userViewModel.DisplayName);
            return RedirectToAction(MVC.Users.List());
        }
    }
}
