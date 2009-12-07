using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TFS.Models.Messages
{
    public class SystemAlert : Message
    {
        [Required]
        public virtual string Content { get; set; }
    }
}
