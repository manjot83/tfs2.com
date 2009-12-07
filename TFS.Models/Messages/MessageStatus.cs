using System;
using System.ComponentModel.DataAnnotations;
using TFS.Models.Users;
using TFS.Models.Validation;

namespace TFS.Models.Messages
{
    public class MessageStatus : BaseDomainObject
    {
        [Required, DomainEquality]
        public virtual User User { get; set; }

        [Required, DomainEquality]
        public virtual Message Message { get; set; }

        [Required, DomainEquality, DateTimeKind(DateTimeKind.Utc)]
        public virtual DateTime? SeenAtDate { get; set; }
    }
}
