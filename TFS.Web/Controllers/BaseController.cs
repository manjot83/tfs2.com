using TFS.Models;
using TFS.Models.Users;
using TFS.Web.Mvc;

namespace TFS.Web.Controllers {
    public abstract partial class BaseController : TransactionalController {

        private User currentUser;
        public IRepository Repository { get; private set; }
        public IApplicationSettings ApplicationSettings { get; private set; }

        public BaseController(IApplicationSettings applicationSettings, IRepository repository) {
            Repository = repository;
            ApplicationSettings = applicationSettings;
        }

        protected User CurrentUser {
            get {
                if (currentUser == null && User != null && User.Identity != null) {
                    currentUser = Repository.GetUserByUsername(User.Identity.Name);
                }
                return currentUser;
            }
        }

    }
}
