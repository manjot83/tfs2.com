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
            var closeTransaction = theSession.Transaction.IsActive;
            if (!theSession.Transaction.IsActive)
                theSession.BeginTransaction();
            var formsIdentity = (FormsIdentity)filterContext.HttpContext.User.Identity;
            var user = ObjectFactory.GetInstance<IUserRepository>().GetUser(formsIdentity.Ticket.Name);
            if (user != null)
            {
                var roles = user.Roles.ToArray();
                filterContext.HttpContext.User = new GenericPrincipal(formsIdentity, roles);
            }
            if (closeTransaction)
                theSession.Transaction.Commit();
            base.OnAuthorization(filterContext);
        }
    }
}
