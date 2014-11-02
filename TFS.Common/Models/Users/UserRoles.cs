using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using TFS.Extensions;

namespace TFS.Models.Users
{
    public class UserRoles : BaseDomainObject
    {
        [Required, DomainEquality]
        public virtual bool UserManager { get; set; }

        [Required, DomainEquality]
        public virtual bool PersonnelManager { get; set; }

        [Required, DomainEquality]
        public virtual bool ProgramManager { get; set; }

        [Required, DomainEquality]
        public virtual bool FlightLogManager { get; set; }

        [Required, DomainEquality]
        public virtual bool PayrollAdmin { get; set; }

        public virtual bool IsInRole(string role)
        {
            if (Enum.GetNames(typeof(Roles)).Any(x => x.Matches(role)))
                return IsInRole((Roles)Enum.Parse(typeof(Roles), role, true));
            throw new ArgumentException(string.Format("Invalid role: {0}", role), "role");
        }

        public virtual bool IsInRole(Roles role)
        {
            switch (role)
            {
                case TFS.Models.Users.Roles.UserManager:
                    return UserManager;
                case TFS.Models.Users.Roles.PersonnelManager:
                    return PersonnelManager;
                case TFS.Models.Users.Roles.ProgramManager:
                    return ProgramManager;
                case TFS.Models.Users.Roles.FlightLogManager:
                    return FlightLogManager;
                case TFS.Models.Users.Roles.PayrollUsers:
                    return true;
                case TFS.Models.Users.Roles.PayrollAdmins:
                    return PayrollAdmin;
                default:
                    return false;
            }
        }

        public virtual string[] ToArray()
        {
            var roles = new List<string>();
            roles.Add(Roles.PayrollUsers.ToString());
            if (UserManager)
                roles.Add(Roles.UserManager.ToString());
            if (PersonnelManager)
                roles.Add(Roles.PersonnelManager.ToString());
            if (ProgramManager)
                roles.Add(Roles.ProgramManager.ToString());
            if (FlightLogManager)
                roles.Add(Roles.FlightLogManager.ToString());
            if (PayrollAdmin)
                roles.Add(Roles.PayrollAdmins.ToString());
            return roles.ToArray();
        }
    }
}
