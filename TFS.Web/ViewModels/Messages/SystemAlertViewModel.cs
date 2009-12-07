using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using TFS.Models.Messages;

namespace TFS.Web.ViewModels.Messages
{
    public class SystemAlertViewModel : MessageViewModel
    {
        [Required]
        public string Content { get; set; }

        public override MessageType MessageType
        {
            get { return MessageType.SystemAlert; }
        }
    }
}
