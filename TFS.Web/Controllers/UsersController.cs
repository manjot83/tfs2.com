using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using TFS.Models;
using TFS.Web.ViewModels;
using TFS.Web.ActionFilters;
using TFS.Models.Users;

namespace TFS.Web.Controllers
{
    [Authorize]
    public partial class UsersController : Controller
    {
        private readonly UserManager userManager;

        public UsersController(UserManager userManager)
        {
            this.userManager = userManager;
        }

        [RequireTransaction]
        public virtual ViewResult Index()
        {
            return List(null, null, null, null);
        }

        [RequireTransaction]
        public virtual ViewResult List(string sortType, SortDirection? sortDirection, int? page, int? itemsPerPage)
        {
            if (string.IsNullOrEmpty(sortType))
                sortType = "name";
            var viewModel = new SortedListViewModel<User>()
            {
                SortDirection = sortDirection ?? SortDirection.Ascending,
                SortType = sortType,
                PagingEnabled = true,
                CurrentPage = page.HasValue ? page.Value : 1,
                ItemsPerPage = itemsPerPage.HasValue ? itemsPerPage.Value : SortedListViewModel<User>.DefaultItemsPerPage,
            };
            var users = userManager.UserRepository.GetAllUsers();
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
            viewModel.Items = users.Skip(viewModel.ItemsPerPage * (viewModel.CurrentPage - 1)).Take(viewModel.ItemsPerPage).ToList();
            return View(Views.List, viewModel);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        [RequireTransaction]
        public virtual ViewResult Edit(string username)
        {
            var user = userManager.UserRepository.GetUser(username);
            var viewModel = new UserViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                DisplayName = user.DisplayName,
                Username = user.Username,
                Disabled = user.Disabled,
            };
            return View(viewModel);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [RequireTransaction]
        public virtual ActionResult Edit(UserViewModel user)
        {
            user.Validate(ModelState, string.Empty);
            if (!ModelState.IsValid)
                return View(user);
            var userEntity = userManager.UserRepository.GetUser(user.Username);
            userEntity.FirstName = user.FirstName;
            userEntity.LastName = user.LastName;
            userEntity.DisplayName = user.DisplayName;
            userEntity.Disabled = user.Disabled;
            return RedirectToAction(MVC.Users.List());
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
            if (ModelState.IsValid && userManager.UserRepository.GetUser(user.Username) != null)
                ModelState.AddModelError("username", "Username must be unique.");
            if (!ModelState.IsValid)
                return View(user);
            var newUser = userManager.CreateUser(user.Username, user.FirstName, user.LastName, user.DisplayName);
            return RedirectToAction(MVC.Users.List());
        }
    }
}
