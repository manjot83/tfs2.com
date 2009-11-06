using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Centro.DomainModel;
using System.ComponentModel.DataAnnotations;
using TFS.Models.PersonnelRecords;

namespace TFS.Models
{
    public class User : BaseEntity, IKeyedModel
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
