using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.Models.Users;
using System.ComponentModel.DataAnnotations;

namespace TFS.Models.Messages
{
    public class Announcement : Message
    {
        public override MessageType MessageType { get { return MessageType.Announcement; } }

        [Required]
        public virtual User CreatedBy { get; set; }

        [Required]
        public virtual string Content { get; set; }

        [Required]
        public virtual bool Urgent { get; set; }
    }
}
