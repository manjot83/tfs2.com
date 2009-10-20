using System.Web.Mvc;
using StructureMap;
using TFS.Models;

namespace TFS.Web.Controllers
{
    public static class ControllerExtensions
    {
        private static User currentUser;

        public static User GetCurrentUser(this Controller controller)
        {
            if (currentUser == null)
            {
                if (controller.User != null &&
                    controller.User.Identity != null)
                    currentUser = ObjectFactory.GetInstance<IUserRepository>().GetUser(controller.User.Identity.Name);
            }
            return currentUser;
        }
    }
}
