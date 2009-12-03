using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using TFS.Models.Validation;
using Iesi.Collections;
using TFS.Models.Users;
using Iesi.Collections.Generic;

namespace TFS.Models.Messages
{
    public class Message : BaseDomainObject
    {
        public Message()
        {
            SeenBy = new HashedSet<User>();
        }

        public virtual int? Id { get; private set; }

        [DomainEquality, Required, StringLength(100)]
        public virtual string Title { get; set; }

        [DomainEquality, Required, DateTimeKind(DateTimeKind.Utc)]
        public virtual DateTime ActiveFromDate { get; set; }

        [DomainEquality, Required, DateTimeKind(DateTimeKind.Utc)]
        public virtual DateTime ActiveToDate { get; set; }

        public virtual ISet<User> SeenBy { get; set; }

        public virtual void MarkSeenBy(User user)
        {
            if (!SeenBy.Contains(user))
                SeenBy.Add(user);
        }
    }
}
