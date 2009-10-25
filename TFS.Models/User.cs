using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Centro.DomainModel;

namespace TFS.Models
{
    public class User : BaseEntity
    {
        public virtual int Id { get; private set; }
        
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string DisplayName { get; set; }
        public virtual string Email { get; set; }
        public virtual string Username { get; set; }
        public virtual bool Disabled { get; set; }

        public virtual void SetDefaultEmailAddress(string username)
        {
            if (username.ToUpper().EndsWith("@TFS2.COM"))
                Email = username;
            else
                Email = username + "@tfs2.com";
        }
    }
}
