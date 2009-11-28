using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TFS.Models.Users
{
    public class UserRoles : BaseDomainObject
    {
        [Required]
        [DomainEquality]
        public virtual bool UserManager { get; set; }

        [Required]
        [DomainEquality]
        public virtual bool PersonnelManager { get; set; }

        [Required]
        [DomainEquality]
        public virtual bool ProgramManager { get; set; }

        [Required]
        [DomainEquality]
        public virtual bool FlightLogManager { get; set; }

        public virtual string[] ToArray()
        {
            var roles = new List<string>();
            if (UserManager)
                roles.Add(Roles.UserManager.ToString());
            if (PersonnelManager)
                roles.Add(Roles.PersonnelManager.ToString());
            if (ProgramManager)
                roles.Add(Roles.ProgramManager.ToString());
            if (FlightLogManager)
                roles.Add(Roles.FlightLogManager.ToString());
            return roles.ToArray();
        }
    }
}
