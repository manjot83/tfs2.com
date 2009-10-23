using System.Web.Mvc;
using StructureMap;
using TFS.Models;

namespace TFS.Web.Controllers
{
    public static class ControllerExtensions
    {
        public static User GetCurrentUser(this Controller controller)
        {
            if (controller.User != null &&
                controller.User.Identity != null)
                return ObjectFactory.GetInstance<IUserRepository>().GetUser(controller.User.Identity.Name);
            return null;
        }
    }
}
