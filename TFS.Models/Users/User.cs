using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.Models;
using System.ComponentModel.DataAnnotations;
using TFS.Models.PersonnelRecords;
using TFS.Extensions;

namespace TFS.Models.Users
{
    public class User : BaseDomainEntity, IKeyedModel
    {
        public User()
        {
            Roles = new UserRoles();
        }

        public virtual int? Id { get; private set; }

        [Required, StringLength(50)]
        public virtual string FirstName { get; set; }
        [Required, StringLength(50)]
        public virtual string LastName { get; set; }
        [Required, StringLength(100)]
        public virtual string DisplayName { get; set; }
        [Required, StringLength(50)]
        public virtual string Email { get; set; }
        [DomainEquality]
        [Required, StringLength(50)]
        public virtual string Username { get; set; }
        public virtual bool Disabled { get; set; }

        [Required]
        public virtual UserRoles Roles { get; set; }

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
                    return Roles.UserManager;
                case TFS.Models.Users.Roles.PersonnelManager:
                    return Roles.PersonnelManager;
                case TFS.Models.Users.Roles.ProgramManager:
                    return Roles.ProgramManager;
                case TFS.Models.Users.Roles.FlightLogManager:
                    return Roles.FlightLogManager;
                default:
                    return false;
            }
        }

        public virtual Person Person { get; set; }

        public virtual void SetDefaultEmailAddress(string username)
        {
            if (username.ToUpper().EndsWith("@TFS2.COM"))
                Email = username;
            else
                Email = username + "@tfs2.com";
        }

        public virtual string FileByName()
        {
            return LastName + ", " + FirstName;
        }

        string IKeyedModel.Id
        {
            get { return Username; }
        }

        string IKeyedModel.DisplayText
        {
            get { return DisplayName; }
        }
    }
}
