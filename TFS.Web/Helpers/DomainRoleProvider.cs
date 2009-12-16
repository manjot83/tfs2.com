using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using TFS.Models;
using TFS.Models.Users;

namespace TFS.Web.Helpers
{
    public class DomainRoleProvider : RoleProvider
    {
        public override string[] GetRolesForUser(string username)
        {
            var container = HttpContext.Current.ApplicationInstance as ICanResolveDependencies;
            if (container == null)
                throw new InvalidOperationException("HttpApplication must implemented ICanResolveDependencies");

            var unitOfWork = container.Resolve<IUnitOfWork>();
            unitOfWork.Begin();
            try
            {
                string[] roles = new string[0];
                var user = container.Resolve<IUserRepository>().GetUser(username);
                if (user != null)
                    roles = user.Roles.ToArray();
                unitOfWork.Finish();
                return roles;
            }
            catch (Exception)
            {
                unitOfWork.Abort();
                throw;
            }
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            return GetRolesForUser(username).Contains(roleName);
        }

        #region Not Implemented Members
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
