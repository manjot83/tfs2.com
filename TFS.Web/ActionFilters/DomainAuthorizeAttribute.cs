using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StructureMap;
using NHibernate;
using System.Security.Principal;
using System.Web.Security;
using TFS.Models.Users;

namespace TFS.Web.ActionFilters
{
    public class DomainAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var theSession = ObjectFactory.GetInstance<ISession>();
            var openAndcloseTransaction = !theSession.Transaction.IsActive;
            if (openAndcloseTransaction)
                theSession.BeginTransaction();
            var formsIdentity = filterContext.HttpContext.User.Identity as FormsIdentity;
            User user = null;
            if (formsIdentity != null)
                user = ObjectFactory.GetInstance<IUserRepository>().GetUser(formsIdentity.Ticket.Name);
            if (user != null)
            {
                var roles = user.Roles.ToArray();
                if (roles.Any())
                    filterContext.HttpContext.User = new GenericPrincipal(formsIdentity, roles);
            }
            if (openAndcloseTransaction)
                theSession.Transaction.Commit();
            base.OnAuthorization(filterContext);
        }
    }
}
