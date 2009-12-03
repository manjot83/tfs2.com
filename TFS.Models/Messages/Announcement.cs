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
        [Required]
        public virtual User CreateBy { get; set; }

        [Required]
        public virtual string Content { get; set; }

        [Required]
        public virtual bool Urgent { get; set; }
    }
}
