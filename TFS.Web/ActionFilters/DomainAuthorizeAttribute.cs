using System;
using System.Linq;
using System.Security.Principal;
using System.Web.Mvc;
using System.Web.Security;
using TFS.Models;
using TFS.Models.Users;

namespace TFS.Web.ActionFilters
{
    public class DomainAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var container = filterContext.HttpContext.ApplicationInstance as ICanResolveDependencies;
            if (container == null)
                throw new InvalidOperationException("HttpApplication must implemented ICanResolveDependencies");

            var unitOfWork = container.Resolve<IUnitOfWork>();
            unitOfWork.Begin();

            var formsIdentity = filterContext.HttpContext.User.Identity as FormsIdentity;
            User user = null;
            if (formsIdentity != null)
                user = container.Resolve<IUserRepository>().GetUser(formsIdentity.Ticket.Name);
            if (user != null)
            {
                var roles = user.Roles.ToArray();
                if (roles.Any())
                    filterContext.HttpContext.User = new GenericPrincipal(formsIdentity, roles);
            }
            
            base.OnAuthorization(filterContext);
        }
    }
}
