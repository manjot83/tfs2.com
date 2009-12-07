using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TFS.Models.Messages
{
    public class SystemAlert : Message
    {
        public override MessageType MessageType { get { return MessageType.SystemAlert; } }

        [Required]
        public virtual string Content { get; set; }
    }
}
