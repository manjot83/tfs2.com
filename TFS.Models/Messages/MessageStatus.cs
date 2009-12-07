using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.Models.Users;
using System.ComponentModel.DataAnnotations;
using TFS.Models.Validation;

namespace TFS.Models.Messages
{
    public class MessageStatus :BaseDomainObject
    {
        [Required, DomainEquality]
        public virtual User User { get; set; }
        [Required, DomainEquality]
        public virtual Message Message { get; set; }
        [DomainEquality, DateTimeKind(DateTimeKind.Utc)]
        public virtual DateTime? SeenAtDate { get; set; }
    }
}
