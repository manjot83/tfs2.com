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
    public abstract class Message : BaseDomainObject
    {
        public Message()
        {
            MessageStatusForUsers = new HashedSet<MessageStatus>();
        }

        public abstract MessageType MessageType { get; }

        public virtual Guid? Id { get; private set; }

        [DomainEquality, Required, StringLength(100)]
        public virtual string Title { get; set; }

        [DomainEquality, Required, DateTimeKind(DateTimeKind.Utc)]
        public virtual DateTime ActiveFromDate { get; set; }

        [DomainEquality, Required, DateTimeKind(DateTimeKind.Utc)]
        public virtual DateTime ActiveToDate { get; set; }

        [Required]
        public virtual string Content { get; set; }

        public virtual ISet<MessageStatus> MessageStatusForUsers { get; set; }

        public virtual void MarkSeenBy(User user)
        {
            if (!MessageStatusForUsers.Any(x => x.User == user))
            {
                var status = new MessageStatus
                {
                    Message = this,
                    User = user,
                    SeenAtDate = DateTime.UtcNow,
                };
                MessageStatusForUsers.Add(status);
            }
        }
    }
}
