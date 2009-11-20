using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.Models;
using System.ComponentModel.DataAnnotations;
using TFS.Models.PersonnelRecords;

namespace TFS.Models.Users
{
    public class User : BaseDomainEntity, IKeyedModel
    {
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
