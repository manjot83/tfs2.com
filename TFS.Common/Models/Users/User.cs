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
    public class User : BaseDomainObject, IKeyedModel
    {
        public User()
        {
            Roles = new UserRoles();
        }

        public virtual Guid? Id { get; private set; }

        [Required, StringLength(50)]
        public virtual string FirstName { get; set; }
        [Required, StringLength(50)]
        public virtual string LastName { get; set; }
        [Required, StringLength(100)]
        public virtual string DisplayName { get; set; }
        [Required, StringLength(50)]
        public virtual string Email { get; set; }
        [Required, StringLength(255)]
        public virtual string Title { get; set; }
        [Required]
        public virtual int RateGroup { get; set; }
        [DomainEquality]
        [Required, StringLength(50)]
        public virtual string Username { get; set; }
        public virtual bool Disabled { get; set; }

        [Required]
        public virtual UserRoles Roles { get; set; }

        public virtual bool IsInRole(string role)
        {
            return Roles.IsInRole(role);
        }

        public virtual bool IsInRole(Roles role)
        {
            return Roles.IsInRole(role);
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
