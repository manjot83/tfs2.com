using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using TFS.Models.Users;

namespace TFS.Models.Messages
{
    public class UserAlert : Message
    {
        public override MessageType MessageType { get { return MessageType.UserAlert; } }

        [Required, DomainEquality]
        public virtual User User { get; set; }
    }
}
